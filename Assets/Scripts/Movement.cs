using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 100;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            adjustMovement(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            adjustMovement(-rotationThrust);
        } 
    }

    void adjustMovement(float moveInput)
    {
        rb.freezeRotation = true;
        transform.Rotate(moveInput * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }
}

