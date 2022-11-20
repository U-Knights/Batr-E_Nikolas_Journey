using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHorizontal : MonoBehaviour
{
    public Transform elevatorH;
    public Transform downposH;
    public Transform upperposH;

    public float speed;
    bool iselevatordown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= downposH.position.x) {
                iselevatordown = true;
        }
        else if (transform.position.x >= upperposH.position.x) {
                iselevatordown = false;
        }
        if(iselevatordown) {
            transform.position = Vector2.MoveTowards(transform.position, upperposH.position, speed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, downposH.position, speed * Time.deltaTime);
        }
    }
}
