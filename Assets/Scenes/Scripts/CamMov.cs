using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMov : MonoBehaviour
{
    int zSpeed;
    public GameManager gameManager;

    void Update()
    {
        zSpeed = gameManager.GetComponent<SpeedControl>().speed;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, zSpeed);
    }
}
