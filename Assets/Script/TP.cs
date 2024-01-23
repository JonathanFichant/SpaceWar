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
        Vector3 currentPosition = transform.position;
        Bounds objectBounds = GetComponent<Renderer>().bounds;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Vector3 screenBottomLeft = mainCamera.WorldToScreenPoint(objectBounds.min);
        Vector3 screenTopRight = mainCamera.WorldToScreenPoint(objectBounds.max);

        if (screenTopRight.y < 0 || screenBottomLeft.y > screenHeight)
        {
            // Sortie par le haut, inversez la coordonn�e Y
            currentPosition.y *= -1f;
        }

        if (screenBottomLeft.x < 0 || screenTopRight.x > screenWidth)
        {
            // Sortie par les c�t�s gauche ou droit, inversez la coordonn�e X
            currentPosition.x *= -1f;
        }

        // Appliquez la nouvelle position � l'objet
        transform.position = currentPosition;

    }

    void OnBecameInvisible()
    {
        // Appeler la fonction pour t�l�porter l'objet de l'autre c�t� de l'�cran
        TeleportToOppositeSide();
    }

    void TeleportToOppositeSide()
    {
        Vector3 currentPosition = transform.position;

        // Obtenir la largeur et la hauteur de la cam�ra
        float camWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        float camHeight = Camera.main.orthographicSize * 2;

        // Calculer la nouvelle position de l'objet de l'autre c�t� de l'�cran
        Vector3 newPosition = currentPosition;

        if (currentPosition.x > Camera.main.transform.position.x + camWidth / 2)
        {
            // L'objet sort � droite, le t�l�porter � gauche
            newPosition.x -= camWidth;
        }
        else if (currentPosition.x < Camera.main.transform.position.x - camWidth / 2)
        {
            // L'objet sort � gauche, le t�l�porter � droite
            newPosition.x += camWidth;
        }

        if (currentPosition.y > Camera.main.transform.position.y + camHeight / 2)
        {
            // L'objet sort vers le haut, le t�l�porter vers le bas
            newPosition.y -= camHeight;
        }
        else if (currentPosition.y < Camera.main.transform.position.y - camHeight / 2)
        {
            // L'objet sort vers le bas, le t�l�porter vers le haut
            newPosition.y += camHeight;
        }

        // Appliquer la nouvelle position � l'objet
        transform.position = newPosition;
    }
}
