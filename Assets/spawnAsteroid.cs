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
            // Générer des coordonnées x et y aléatoires
            float randomX = Random.Range(-20f, 20f);
            float randomY = Random.Range(-10f, 10f);

            // Créer une position aléatoire en fonction des coordonnées générées
            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

            // Sélectionner aléatoirement un élément de la liste
            int randomIndex = Random.Range(0, asteroidPrefabs.Count);
            GameObject selectedPrefab = asteroidPrefabs[randomIndex];

            // Instancier l'objet sélectionné à la position aléatoire avec une rotation par défaut
            Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
        }
    }
}
