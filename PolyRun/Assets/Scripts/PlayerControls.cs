using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Default Jumping Power")]
    public float jumpPower = 6f;
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    float posX = 0.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();

        posX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));
        }

        if (transform.position.x < posX)
        {
            GameOver();
        }

    }
    //with this object's collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.collider.tag == "Enemy")
        {
            GameOver();
        }

        
    }

    //with this object's collider
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //with this object's collider
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    //Game over function
    void GameOver()
    {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }

    //when a collider on another object is touching
    //this object's trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If triggers tag equals coin
        if (collision.tag == "Coin")
        {
            GameObject.Find("GameController").GetComponent<GameController>().IncrementScore();

            Destroy(collision.gameObject);
        }
    }
        
}