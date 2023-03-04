using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [Header("Rigidbody")]
    public Rigidbody2D rb;
    [Header("Default Down Speed")]
    public float downSpeed = 20f;
    [Header("Default Movement Speed")]
    public float movementSpeed = 10f;
    [Header("Default Directional Movement Speed")]
    public float movement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        if (movementSpeed < 0) 
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        else 
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    
    //Fixedupdate called every fixed frame-rate frame
    void FixedUpdate()
    {

        Vector2 velocity = rb.velocity;

        velocity.x = movement;

        rb.velocity = velocity;

    }

    //Collision function
    private void OnCollisionEnter2D(Collision2D collision)
}
