using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
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
