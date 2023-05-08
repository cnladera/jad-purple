using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Default Movement Speed")]
    public float moveSpeed = 600f;
    float movement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    //If the object collides with a
    //collider with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }
}
