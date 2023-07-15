using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Trash Class with prefab and probability
[Serializable]
public class Trash
{
    public GameObject prefab;
    public int probability;
}

public class TrashSpawner : MonoBehaviour
{
    // List with objects to spawn and their probability
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Terrain terrain;
    [SerializeField] private List<Trash> listObjs;
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects() {
        TerrainData terrainData = terrain.terrainData;
        foreach (Trash trash in listObjs)
        {
            GameObject obj = trash.prefab;
            int probability = trash.probability;
            var trashGrabHandler = obj.GetComponent<TrashGrabHandler>();
            trashGrabHandler.onGrabAction = gameManager.UpdatePoints;
          
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
                    // Terrain height + object height
                    height + obj.transform.localScale.y / 2,
                    randomPosition.z
                ), obj.transform.rotation);
            }
        }
    }
}