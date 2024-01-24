using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    private Camera mainCamera;
    private float borneX = 25.5f;
    private float borneY = 14.7f;
    private float tpX = 25f;
    private float tpY = 14f;

    void Start()
    {
        mainCamera = Camera.main;
     
    }

    void Update()
    {
        Teleportation();
        //IsObjectVisible();
    }

    /*void IsObjectVisible()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float cameraLeftBound = mainCamera.transform.position.x - cameraWidth / 2;
        float cameraRightBound = mainCamera.transform.position.x + cameraWidth / 2;
        float cameraBottomBound = mainCamera.transform.position.y - cameraHeight / 2;
        float cameraTopBound = mainCamera.transform.position.y + cameraHeight / 2;
        Vector3 objectPosition = transform.position;

        if (transform.position.x <= cameraLeftBound || transform.position.x > cameraRightBound)
        {
            objectPosition.x *= -1;

            // Appliquer la nouvelle position à l'objet
            transform.position = objectPosition;
        }

        if (transform.position.y <= cameraBottomBound || transform.position.y > cameraTopBound)
        {
            objectPosition.y *= -1;

            // Appliquer la nouvelle position à l'objet
            transform.position = objectPosition;
        }

    }
    */

    void Teleportation()
    {
        if (transform.position.x > borneX)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = -tpX;
            transform.position = newPosition;
        }
        if (transform.position.x < -borneX)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = tpX;
            transform.position = newPosition;
        }
        if (transform.position.y > borneY)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = -tpY;
            transform.position = newPosition;
        }
        if (transform.position.y < -borneY)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = tpY;
            transform.position = newPosition;
        }


    }


    //14.7 14
    //25.5 25
}
