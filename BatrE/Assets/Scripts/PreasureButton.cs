using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasureButton : MonoBehaviour
{
    public Vector3 originalPos;
    bool moveBack = false;
    public GameObject door;
    public GameObject doorReverted;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        if (doorReverted!=null) doorReverted.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (transform.position.y > originalPos.y-0.025f) {
            transform.Translate(0f, -0.01f, 0f);
            if (door!=null) door.SetActive(false);           
            if (doorReverted!=null) doorReverted.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        moveBack = true;
        if (door!=null) door.SetActive(true);
        if (doorReverted!=null) doorReverted.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveBack) {
            if (transform.position.y < originalPos.y) {
                transform.Translate(0f, 0.01f, 0f);
            }
            else moveBack = false;
        }
    }
}
