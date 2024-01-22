using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float acceleration;
    public float speedRotation;
    public float currentSpeed;
    public float maxSpeed;
    private Rigidbody rb;
    public Vector3 vel;

    void Start()
    {
        acceleration = 1f;
        speedRotation = 1.5f;
        maxSpeed = 10f; 
        rb = GetComponent<Rigidbody>();
    }

    // rajouter boost latéral droite ou gauche : addforce


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A))) // Q
        {
            //rotation du vaisseau sens anti horaire
            transform.Rotate(0, 0, speedRotation);
        }
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D))) 
        {
            //rotation du vaisseau sens horaire
            transform.Rotate(0, 0, -speedRotation);
        }
        if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W))) //Z
        {
            //Poussée avant du vaisseau
            rb.AddForce(transform.up, ForceMode.Force);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            currentSpeed += acceleration * Time.deltaTime;
        }

        vel = rb.velocity; // corriger la vitesse max
    }
}
