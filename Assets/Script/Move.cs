using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float acceleration;
    public float speedRotation;
    public float currentSpeed;
    public float maxSpeed;
    public float cdDash;
    public bool dashAvailable;
    private float timerDash;
    private Rigidbody rb;
    public Vector3 vel;

    void Start()
    {
        acceleration = 3f;
        speedRotation = 120f;
        maxSpeed = 10f;
        cdDash = 3f;
        dashAvailable = true;
        timerDash = cdDash;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Rotate();
        MoveForward();
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        //Dash();
        //RecoveryDash();


        vel = rb.velocity; // corriger la vitesse max
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A))) // Q
        {
            //rotation du vaisseau sens anti horaire
            transform.Rotate(0, 0, speedRotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            //rotation du vaisseau sens horaire
            transform.Rotate(0, 0, -speedRotation * Time.deltaTime);
        }
    }

    void MoveForward()
    {
        if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W))) //Z
        {
            //Poussée avant du vaisseau
            rb.AddForce(transform.up*acceleration, ForceMode.Force);
            
            //rb.velocity += transform.up * acceleration;
        }
    }
    /*
    void Dash() // dash avant si pas de direction appuyée ?
    {
        if (Input.GetKey(KeyCode.LeftShift) && dashAvailable == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A))) // Q
            {
                dashAvailable = false;
                rb.AddForce(transform.right * -1, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
            {

                dashAvailable = false;
                rb.AddForce(transform.right, ForceMode.Force);
            }
        }
    }

    void RecoveryDash()
    {
        if (dashAvailable == false)
        {
            timerDash -= Time.deltaTime;
            if (timerDash <= 0)
            {
                dashAvailable = true;
                timerDash = cdDash;
            }
        }
    }
    */
}

