using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    private Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;
     
    }

    void Update()
    {
 
        IsObjectVisible();
    }

    void IsObjectVisible()
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

        /*Vector3 currentPosition = transform.position;
        Bounds objectBounds = GetComponent<Collider>().bounds;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Vector3 screenBottomLeft = mainCamera.WorldToScreenPoint(objectBounds.min);
        Vector3 screenTopRight = mainCamera.WorldToScreenPoint(objectBounds.max);
        //Vector3 screenBottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        //Vector3 screenTopRight = mainCamera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, mainCamera.nearClipPlane));

        if (screenTopRight.y < 0 || screenBottomLeft.y > screenHeight)
        {
            // Sortie par le haut, inversez la coordonnée Y
            currentPosition.y *= -1f;
        }

        if (screenBottomLeft.x < 0 || screenTopRight.x > screenWidth)
        {
            // Sortie par les côtés gauche ou droit, inversez la coordonnée X
            currentPosition.x *= -1f;
        }

        // Appliquez la nouvelle position à l'objet
        transform.position = currentPosition;
        */
    }

    /*void OnBecameInvisible()
    {
        // Appeler la fonction pour téléporter l'objet de l'autre côté de l'écran
        TeleportToOppositeSide();
    }

    void TeleportToOppositeSide()
    {
        Vector3 currentPosition = transform.position;

        // Obtenir la largeur et la hauteur de la caméra
        float camWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        float camHeight = Camera.main.orthographicSize * 2;

        // Calculer la nouvelle position de l'objet de l'autre côté de l'écran
        Vector3 newPosition = currentPosition;

        if (currentPosition.x > Camera.main.transform.position.x + camWidth / 2)
        {
            // L'objet sort à droite, le téléporter à gauche
            newPosition.x -= camWidth;
        }
        else if (currentPosition.x < Camera.main.transform.position.x - camWidth / 2)
        {
            // L'objet sort à gauche, le téléporter à droite
            newPosition.x += camWidth;
        }

        if (currentPosition.y > Camera.main.transform.position.y + camHeight / 2)
        {
            // L'objet sort vers le haut, le téléporter vers le bas
            newPosition.y -= camHeight;
        }
        else if (currentPosition.y < Camera.main.transform.position.y - camHeight / 2)
        {
            // L'objet sort vers le bas, le téléporter vers le haut
            newPosition.y += camHeight;
        }

        // Appliquer la nouvelle position à l'objet
        transform.position = newPosition;
    }
    */
}
