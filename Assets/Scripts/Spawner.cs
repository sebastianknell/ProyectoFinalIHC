using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> listObjs;
    public int totalSpawns;
    void Start()
    {
        System.Random rnd = new System.Random();
        int px, py, pz;
        int numObject;
        for (int i = 0; i < totalSpawns; i++) {
            // Random initial position
            px = rnd.Next(0, 200);
            py = rnd.Next(0, 40);
            pz = rnd.Next(0, 200);
            // Random object from list
            numObject = rnd.Next(0, listObjs.Count);
            Instantiate(listObjs[numObject], new Vector3(px, py, pz), listObjs[0].transform.rotation);
        }
    }
}
