using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemey : MonoBehaviour
{

    public List<GameObject> enemiShipPrefabs = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnEnemiShip", 0f, 10f);
    }

    void SpawnEnemiShip()
    {
        // V�rifiez s'il y a au moins un �l�ment dans la liste
        if (enemiShipPrefabs.Count > 0)
        {
            // G�n�rer des coordonn�es x et y al�atoires
            float randomX = Random.Range(-20f, 20f);
            float randomY = Random.Range(-10f, 10f);

            // Cr�er une position al�atoire en fonction des coordonn�es g�n�r�es
            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

            // S�lectionner al�atoirement un �l�ment de la liste
            int randomIndex = Random.Range(0, enemiShipPrefabs.Count);
            GameObject selectedPrefab = enemiShipPrefabs[randomIndex];

            // Instancier l'objet s�lectionn� � la position al�atoire avec une rotation par d�faut
            Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
        }
    }
}
