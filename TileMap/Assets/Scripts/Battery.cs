using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public RobotMovement robotMovement;

    private void OnTriggerEnter(Collider other) 
    {
        robotMovement.energy = 100f;
        Debug.Log("AAAA");
    }
    private void OnTriggerStay(Collider other) {
        
    }
    private void OnTriggerExit(Collider other) {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
