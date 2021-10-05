using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMov : MonoBehaviour
{
    public int zSpeed;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -zSpeed);
    }

    void Update()
    {
        if (transform.position.y < -1)
            Destroy(gameObject);
    }
}
