using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    int zSpeed;
    bool onGround = true;
    public GameManager gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && !(gameManager.GetComponent<SuperPower>().isUlt && gameManager.GetComponent<SuperPower>().playerType == PlayerType.TANK))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void Update()
    {
        Vector3 newPos;
        if (transform.position.y < 1.7576f)
        {
            onGround = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newPos = transform.position;
            newPos.x += -4;
            transform.position = newPos;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            newPos = transform.position; 
            newPos.x += 4;
            transform.position = newPos;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
            newPos = transform.position;
            if (newPos.y < 6 && onGround)
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 20f, 0),ForceMode.VelocityChange);
            else
            {
                onGround = false;
            } 
            transform.position = newPos;
        }
        if (transform.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        zSpeed = gameManager.GetComponent<SpeedControl>().speed;
    }

    private void FixedUpdate()
    {
        Vector3 newPos;
        newPos = transform.position;
        if (Time.fixedDeltaTime == 0.001f)
            newPos.z += zSpeed / 1000f;
        else
            newPos.z += zSpeed / 100f;
        transform.position = newPos;
        transform.rotation = Quaternion.identity;
    }
}
