using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform player;
    public float maxApproachDistance = 15f;
    public float minShootDistance = 5f;
    public float approachSpeed = 5f;
    public float slowApproachSpeed = 2f;
    public float retreatSpeed = 3f;
    public GameObject missile;
    public float cdShoot = 1f;
    public float timerShoot;
    public bool isShooting = false;

    void Start()
    {
        timerShoot = 0f ;
    }

    void Update()
    {

        if (isShooting)
        {
            timerShoot += Time.deltaTime;
        }
        if (timerShoot >= cdShoot)
        {
            isShooting = false;
            timerShoot = 0f;
        }

        Vector3 enemyPosition = transform.position;
        Vector3 playerPosition = player.position;

        float distanceToPlayer = Vector3.Distance(enemyPosition, playerPosition);

        if (distanceToPlayer > maxApproachDistance) // traque à 15+
        {
            transform.Translate(Vector3.Normalize(playerPosition - enemyPosition) * approachSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer > minShootDistance) //inférieur à 15 mais supérieur à 5
        {
            transform.Translate(Vector3.Normalize(playerPosition - enemyPosition) * slowApproachSpeed * Time.deltaTime);

            Shot();
        }
        else if (distanceToPlayer <= minShootDistance)//inférieur ou égal à 5
        {
            transform.Translate(Vector3.Normalize(enemyPosition - playerPosition) * retreatSpeed * Time.deltaTime);
            Shot();
        }
        transform.up = playerPosition - enemyPosition;
        Debug.Log(distanceToPlayer);
    }
    void Shot()
    {
        if (isShooting == false)
        {
            isShooting = true;
            Instantiate(missile, transform.position, transform.rotation);
        }
        
    }

}
