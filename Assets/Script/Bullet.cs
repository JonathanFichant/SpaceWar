using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private float speedBullet;
    public float timerDestruction;

    void Start()
    {
        speedBullet = 900;
        timerDestruction = 2.5f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speedBullet * Time.deltaTime;
        Destroy(gameObject, timerDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
