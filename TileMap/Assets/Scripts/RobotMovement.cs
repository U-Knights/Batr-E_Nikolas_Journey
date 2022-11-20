// Rotate an object around its Y (upward) axis in response to
// left/right controls.
using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour
{
    [SerializeField] public float movement;
    [SerializeField] public float speed;
    public Rigidbody2D circle;
    private float angularDragValue = 0;
    private float linearDragValue = 0;
    [Range(1, 100)]
    [SerializeField] public int angularDragMultiplier = 0;
    [Range(1, 100)]
    [SerializeField] public int linearDragMultiplier = 0;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [Range(1, 100)]
    [SerializeField] public float energy = 50;
    [SerializeField] public Vector2 speedo;

    void Start()
    {
        angularDragValue = circle.angularDrag;
        linearDragValue = circle.drag;
    }

    private void Update()
    {
        speedo = circle.velocity;
        if (Mathf.Abs(Input.GetAxis("Horizontal"))>0) 
        {
            energy = energy - (Mathf.Abs(circle.angularVelocity+1f)/100000f);
        } 
        bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
        }

        movement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(Input.GetAxis("Horizontal"))<0.5 && IsGrounded() && energy>0f)
        {
            circle.angularVelocity = 0f;
            circle.angularDrag = angularDragValue*angularDragMultiplier;
            circle.drag = linearDragValue*linearDragMultiplier;
        }
        else 
        {
            circle.angularDrag = angularDragValue;
            circle.drag = linearDragValue;
            if (energy>0f)
            {
            circle.velocity = ChangeX(speedo, movement*speed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Capsule")
            energy = 100f;
    }

    void FixedUpdate()
    {
        if (energy>0f)
        {
            circle.AddTorque(-movement * speed * Time.fixedDeltaTime);
        }
    }
    public static Vector2 ChangeX(Vector2 v, float x)
     {
         return new Vector2(x, v.y);
     }
}