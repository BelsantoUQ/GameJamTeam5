using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SimpleSpawn : MonoBehaviour
{
    [Header("Prefab Obstacles")]

    [SerializeField] private GameObject[] spawnPrefab;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private Transform father;


    void Start()
    {
        InvokeRepeating("RandomSpawn", 1, 1.3f);
    }

    void RandomSpawn()
    {
        int indexSpawn = Random.Range(0, spawnPrefab.Length);
        GameObject prefabToSpawn = spawnPrefab[indexSpawn];
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPos.transform.position , new Quaternion(0, Random.Range(0, 180), 0, 0) );
        spawnedObject.transform.SetParent(father.transform);
    }
}

