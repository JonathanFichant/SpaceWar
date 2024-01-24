using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Transform player;
    public float maxApproachDistance = 15f;
    public float minShootDistance = 5f;
    public float approachSpeed = 5f;
    public float slowApproachSpeed = 2f;
    public float retreatSpeed = 3f;
    public GameObject missile;
    public float cdShoot = 1f;
    public float timerShoot;
    public bool isShooting = false;
    //public GameObject ObjectPlayer;

    void Start()
    {
        timerShoot = 0f;
        GameObject ObjectPlayer = GameObject.Find("parentShip");
        player = ObjectPlayer.transform;

    }

    void Update()
    {
        Vector3 playerPosition = player.position;

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

        float distanceToPlayer = Vector3.Distance(enemyPosition, playerPosition);

        if (distanceToPlayer > maxApproachDistance) // traque à 15+
        {
            Debug.Log("detect joueur");

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
        transform.Rotate(Vector3.forward, 90f);
    }
    void Shot()
    {
        if (isShooting == false)
        {
            isShooting = true;
            Transform canonTransform = transform.Find("Canon");

            Instantiate(missile, canonTransform.position, transform.rotation * Quaternion.Euler(0, 0, -90f));
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            Life lifeScript = gameObject.GetComponent<Life>();
            lifeScript.LoseLife();
        }

    }
}
