using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 100;
    Rigidbody rb;
    AudioSource ras;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ras = GetComponent<AudioSource>();
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
            if(!ras.isPlaying)
            {
                ras.Play();
            }
            rb.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
        } else 
        {
            ras.Stop();
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

