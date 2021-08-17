using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{   
    [SerializeField]
    private string scene;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    [SerializeField]
    private float jump;

    [SerializeField]
    private BoxCollider2D boxCollider2D;

    [SerializeField]
    private float crouchoffsetx;

    [SerializeField]
    private float crouchoffsety;

    [SerializeField]
    private float crouchsizex;

    [SerializeField]
    private float crouchsizey;

    [SerializeField]
    private float offsetx;

    [SerializeField]
    private float offsety;

    [SerializeField]
    private float sizex;

    [SerializeField]
    private float sizey;

    private float vertical;

    [SerializeField]
    private LaserController laserController;

    private readonly float fallMultiplier = 5.5f;

    
    public Image[] healthimage;

    private int k;
    private readonly float t = 3f;
    private int flag;
    private bool tomove;
    private bool isground;
    private bool jetPack;
    public int jumpForce;
    public jetpackcontroller jetpackcontroller;
    public AudioSource audioSource;
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        k = 2;
        flag = 1;
        tomove = true;
        isground = true;
        Currentscene.currentscene = SceneManager.GetActiveScene().name;
        jetPack = false;
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        AnimatePlayer(horizontal);
        if(tomove==true)
        {
            MovePlayer(horizontal);
        }
        
        Downfall(transform.position);

        if (rb2d.velocity.y <= 3)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if(jetPack==true)
        {
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
               rb2d.AddForce(Vector2.up * jumpForce);
            }
            
            StartCoroutine(ImplementJetpack());
        }
    }

    IEnumerator ImplementJetpack()
    {
        jetpackcontroller.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        jetPack = false;
        jetpackcontroller.gameObject.SetActive(false);
        animator.Play("IdleWithGun");
        audioSource.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent<EnemyController1>() != null) || (collision.gameObject.GetComponent<EnemyController2>() != null))
        {

            animator.Play("Hurt");

            healthimage[k].enabled = false;

            if (k == 0)
            {
                if (flag == 1)
                {
                    animator.Play("Death");
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                    flag = 0;
                }
                StartCoroutine(Reloadscene());
            }
            else
            {
                k--;
            }

            if (collision.gameObject.CompareTag("ground"))
            {
                isground = true;
            }
        }

        else if (collision.gameObject.GetComponent<portioncontroller1>() != null)
        {
            while (k <= 1)
            {
                k++;
                healthimage[k].enabled = true;
            }
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Jetpack"))
        {
            animator.Play("Attack 0");
            jetPack = true;
            Destroy(collision.gameObject);
            audioSource.Play();
        }
    }

    
    IEnumerator Reloadscene()
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(scene);
    }



    private void Downfall(Vector2 vector2)
    {
        if (vector2.y <= -48.7)
        {
            animator.Play("Death");
            StartCoroutine(Reloadscene());
        }
    }


    void AnimatePlayer(float horizontal)
    {
        if(isground==true)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
      
        if(Input.GetKey(KeyCode.X))
        {
            tomove = false;
            animator.SetBool("Attack", true);
            
        }
        else
        {
            tomove = true;
            animator.SetBool("Attack", false);
            laserController.gameObject.SetActive(false);
        }

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (!(vertical > 0))
        {
            animator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            boxCollider2D.offset = new Vector2(crouchoffsetx, crouchoffsety);
            boxCollider2D.size = new Vector2(crouchsizex, crouchsizey);
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
            boxCollider2D.offset = new Vector2(offsetx, offsety);
            boxCollider2D.size = new Vector2(sizex, sizey);
        }
    }


    void MovePlayer(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (vertical > 0)
        {
            if (jetPack == false)
            {
                animator.SetBool("Jump", true);
                StartCoroutine(WaitJump());
            }
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            isground = true;
        }
    }


    IEnumerator WaitJump()
    {
        yield return new WaitForSeconds(0.1f);
        rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Force);
        animator.SetBool("Jump", false);
    }

    private void EnableLaser()
    {
        laserController.gameObject.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent<EnemyController1>() != null) || (collision.gameObject.GetComponent<EnemyController2>() != null))
        {
            animator.Play("IdleWithGun");
        }
        if (!(vertical > 0))
        {
            animator.SetBool("Jump", false);
        }
        if(collision.gameObject.CompareTag("ground"))
        {
            isground = false;
        }

    }
}
