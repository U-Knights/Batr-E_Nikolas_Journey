using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bewegung : MonoBehaviour
{
//     private CharacterController controller;
//     private Vector3 playerVelocity;
//     private bool groundedPlayer;
//     private float playerSpeed = 2.0f;
//     private float jumpHeight = 1.0f;
//     private float gravityValue = -9.81f;

//     private void Start()
//     {
//         controller = gameObject.AddComponent<CharacterController>();
//     }

//     void Update()
//     {
//         groundedPlayer = controller.isGrounded;
//         if (groundedPlayer && playerVelocity.y < 0)
//         {
//             playerVelocity.y = 0f;
//         }

//         Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//         controller.Move(move * Time.deltaTime * playerSpeed);

//         if (move != Vector3.zero)
//         {
//             gameObject.transform.forward = move;
//         }

//         // Changes the height position of the player..
//         if (Input.GetButtonDown("Jump") && groundedPlayer)
//         {
//             playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
//         }

//         playerVelocity.y += gravityValue * Time.deltaTime;
//         controller.Move(playerVelocity * Time.deltaTime);
//     }
// }
    public int movementSpeed = 10;
    public bool rotated = false;

    public int jump = 5;
    public Rigidbody rb;
    // public CharacterController controller;
    // public float speed = 10f;
    // float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        jump = 5;
        // controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal")*speed; 

        if(Input.GetKey("d")){
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey("a")){
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown("space")){
            rb.AddForce(Vector2.up * jump, ForceMode.Impulse);
        }
    }

    // void FixedUpdate(){
    //     controller.Move(horizontalMove*Time.fixedDeltaTime);
    // }
}
