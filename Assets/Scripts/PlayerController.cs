using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    public int speed;

    bool yerde = true;

    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Floor")
        {
            yerde = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            yerde = true;
        }
        if (collision.gameObject.tag == "Tranbolin")
        {
            rb.AddForce(Vector2.up * 750);
        }
    }


    void Update()
    {
        Move();

        Restart();

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("isMove", true);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isMove", false);
        }
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && yerde == true)
        {
            rb.AddForce(Vector2.up * 250);
            yerde = false;
            anim.SetTrigger("isJump");
        }

        if (horizontal>0)
        {
            gameObject.transform.localScale = new Vector2(6, 6);
        }
        if (horizontal<0)
        {
            gameObject.transform.localScale = new Vector2(-6, 6);
        }

        rb.velocity = new Vector2(horizontal * Time.deltaTime * speed, rb.velocity.y);

        Debug.Log(rb.velocity);
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
