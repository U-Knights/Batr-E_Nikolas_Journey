using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDMovement : MonoBehaviour
{
    public int movementSpeed = 5;
    public bool rotated = false;

    public int jump = 3;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        jump = 5;
    }
    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal")*speed; 

        if(Input.GetKey("d")){
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey("a")){
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        // if(Input.GetKeyDown("space")){
        //     rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        // }
    }
}