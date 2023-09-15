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
    [SerializeField] private float rateOfSpawn = 1.66f;
    private float timeforDestro = 8;


    void Start()
    {
        InvokeRepeating("RandomSpawn", 1, rateOfSpawn);
    }

    

    void RandomSpawn()
    {
        int indexSpawn = Random.Range(0, spawnPrefab.Length);
        GameObject prefabToSpawn = spawnPrefab[indexSpawn];
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPos.transform.position , spawnPos.transform.rotation);
        spawnedObject.transform.SetParent(father.transform);
    }

    private void Update(GameObject spawnedObject)
    {
        float timetoDestro = timeforDestro - (1 * Time.deltaTime);
        if (timetoDestro == 0)
        {
            Destroy(spawnedObject);
        }
    }
}

