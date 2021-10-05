using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject[] cars;
    public GameManager gameManager;
    Vector3 nextCarSpawn;
    int spawnSpeed;
    int spawnCounter;

    void Start()
    {
        spawnSpeed = gameManager.GetComponent<SpeedControl>().speed;
        spawnCounter = 1000 / spawnSpeed;
        nextCarSpawn.z = 420;
        nextCarSpawn.y = 2;
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (spawnCounter != 0)
        {
            spawnCounter -= 1;
            return;
        }

        if (Time.fixedDeltaTime == 0.001f)
            spawnCounter = 10000 / spawnSpeed;
        else
            spawnCounter = 1000 / spawnSpeed;
        int carIndex = Random.Range(0, cars.Length);
        int rowIndex = Random.Range(0, 6) * 4 - 10;
        nextCarSpawn = Camera.main.transform.position;
        nextCarSpawn.z += 400;
        nextCarSpawn.x = rowIndex;
        nextCarSpawn.y = 3.5f;
        Instantiate(cars[carIndex], nextCarSpawn, Quaternion.AngleAxis(90, new Vector3(0f, 1f, 0f)));
    }
}
