using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //public GameObject player;

    public Transform elevator;
    public Transform downpos;
    public Transform upperpos;

    public float speed;
    bool iselevatordown;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        other.transform.parent = elevator;
        }
    private void OnCollisionExit2D(Collision2D other) {
        other.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= downpos.position.y) {
                iselevatordown = true;
        }
        else if (transform.position.y >= upperpos.position.y) {
                iselevatordown = false;
        }
        if(iselevatordown) {
            transform.position = Vector2.MoveTowards(transform.position, upperpos.position, speed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, downpos.position, speed * Time.deltaTime);
        }
    }
    
}
