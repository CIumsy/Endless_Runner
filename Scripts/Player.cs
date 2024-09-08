using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpforce;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    [SerializeField] UIController uicontroller;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPos;
    public int score;
    void Start()
    {
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        score += 1;

        checkForInput();
        isFalling();

        if(transform.position.y<-10)
        {
            uicontroller.ShowGameOverScreen();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        checkForGrounded();
        isJumping();
    }

    void isJumping()
    {
                if(jump==true)
        {
            jump=false;
            rb.AddForce(new Vector2(0,jumpforce), ForceMode2D.Impulse);
        }

    }
    void isFalling()
    {
        if(transform.position.y<lastYPos)
            anim.SetBool("Falling", true);
        else
            anim.SetBool("Falling", false);

        lastYPos = transform.position.y;
    }
    void checkForInput()
    {
        if(isGrounded==true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jump=true;
                anim.SetTrigger("Jump");
            }
        }
    }

    void checkForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if(hit.collider!=null)
        {
            if(hit.distance<0.1f)
            {
                isGrounded = true;
                anim.SetBool("IsGrounded", true);
            }
            else
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", false);
            }
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.cyan);
            // Debug.Log(hit.transform.name);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
            uicontroller.ShowGameOverScreen();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
            Destroy(collision.gameObject);
    }
} 
    
