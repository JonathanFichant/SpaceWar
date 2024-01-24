using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{

    public List<GameObject> asteroidPrefabs = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("Asteroid", 0f, 10f);
    }

    void Asteroid()
    {


        if (asteroidPrefabs.Count > 0)
        {
            // G�n�rer des coordonn�es x et y al�atoires
            float randomX = Random.Range(-20f, 20f);
            float randomY = Random.Range(-10f, 10f);

            // Cr�er une position al�atoire en fonction des coordonn�es g�n�r�es
            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

            // S�lectionner al�atoirement un �l�ment de la liste
            int randomIndex = Random.Range(0, asteroidPrefabs.Count);
            GameObject selectedPrefab = asteroidPrefabs[randomIndex];

            // Instancier l'objet s�lectionn� � la position al�atoire avec une rotation par d�faut
            Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
        }
    }
}
