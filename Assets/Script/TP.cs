using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    void OnBecameInvisible()
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
}
