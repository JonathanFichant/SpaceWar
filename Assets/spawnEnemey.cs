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
        // Vérifiez s'il y a au moins un élément dans la liste
        if (enemiShipPrefabs.Count > 0)
        {
            // Générer des coordonnées x et y aléatoires
            float randomX = Random.Range(-20f, 20f);
            float randomY = Random.Range(-10f, 10f);

            // Créer une position aléatoire en fonction des coordonnées générées
            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

            // Sélectionner aléatoirement un élément de la liste
            int randomIndex = Random.Range(0, enemiShipPrefabs.Count);
            GameObject selectedPrefab = enemiShipPrefabs[randomIndex];

            // Instancier l'objet sélectionné à la position aléatoire avec une rotation par défaut
            Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
        }
    }
}
