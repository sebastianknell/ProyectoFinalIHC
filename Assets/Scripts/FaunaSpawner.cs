using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animal Class with prefab and probability
[Serializable]
public class Animal
{
    public GameObject prefab;
    public int probability;
}

public class FaunaSpawner : MonoBehaviour
{
    // List with objects to spawn and their probability
    [SerializeField] private List<Animal> animals;
    [SerializeField] private Terrain terrain;
    private System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects() {
        TerrainData terrainData = terrain.terrainData;

        foreach (Animal animal in animals)
        {
            GameObject obj = animal.prefab;
            int probability = animal.probability;
          
            for (int i = 0; i < probability; i++)
            {
                // Random position inside terrain
                Vector3 randomPosition = new Vector3(
                    rnd.Next(0, (int)terrainData.size.x),
                    0,
                    rnd.Next(0, (int)terrainData.size.z)
                );

                // Get height of terrain at random position
                float height = terrain.SampleHeight(randomPosition);

                // Instantiate object
                Instantiate(obj, new Vector3(
                    randomPosition.x,
                    // Terrain height + default offset
                    height + rnd.Next(40),
                    randomPosition.z
                ), obj.transform.rotation);
            }
        }
    }
}