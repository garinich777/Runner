using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMSpawn : MonoBehaviour
{
    int spawnSpeed;
    float spawnDelay;
    Vector3 nextTileSpawn;
    Queue<Transform> childs;
    void Start()
    {
        spawnSpeed = GetComponent<SpeedControl>().speed;
        childs = new Queue<Transform>();
        foreach (Transform child in transform)
            childs.Enqueue(child);
        
        nextTileSpawn.z = 450;
        spawnDelay = 90f / spawnSpeed; 
        StartCoroutine(SpawnTitle());
    }

    private void Update()
    {
        spawnSpeed = GetComponent<SpeedControl>().speed;
        spawnDelay = 90f / (spawnSpeed);
    }

    IEnumerator SpawnTitle()
    {
        yield return new WaitForSeconds(spawnDelay);
        Transform child = childs.Dequeue();
        child.position = nextTileSpawn;
        childs.Enqueue(child);
        nextTileSpawn.z += 90;
        StartCoroutine(SpawnTitle());
    }
}
