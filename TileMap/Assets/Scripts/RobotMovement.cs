// Rotate an object around its Y (upward) axis in response to
// left/right controls.

using System;
using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour, IChargeable
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
    //Linh
    public SpriteRenderer nikola;
    
    private HealthBar bar;

    void Start()
    {
        angularDragValue = circle.angularDrag;
        linearDragValue = circle.drag;
        bar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    private void Update()
    {
        if (!Pause.paused){
            speedo = circle.velocity;
            
            if (Mathf.Abs(Input.GetAxis("Horizontal"))>0) 
            {
                energy = energy - (Mathf.Abs(circle.angularVelocity+1f)/100000f);
            }
            bool IsGrounded()
            {
                return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
            }

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    if (nikola != null) nikola.flipX = false;
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    if (nikola != null) nikola.flipX = true;
                }

                if (Mathf.Abs(Input.GetAxis("Horizontal"))>0) 
                {
                    energy = Mathf.Clamp(energy - (Mathf.Abs(circle.angularVelocity+1f)/100000f), 0, 100);
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
        bar.SetHealth(energy);
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
     
     public void recharge(float amount) {
        energy = Mathf.Clamp(energy += amount, 0, 100);

        //Debug.Log(this.name + " energy: " + energy);

    }
    public float decharge(float amount)
    {
        float oldEnergy = energy;
        // If the object is depleted, difference will be 0
        energy = Mathf.Clamp(energy -= amount, 0, 100);
        return oldEnergy - energy; // pass the decharged amount
    }
}