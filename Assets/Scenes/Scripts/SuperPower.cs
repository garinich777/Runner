using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerType {FLY, TANK, THEWORLD }

class Player
{
    public GameManager gameManager;
    public GameObject Prefab;
    public bool ultIsReady = false;
    public int ultPercent = 0;
    public virtual void DoSuperPower() { }
    public virtual void EndSuperPower() { }
}

class FlyPlayer : Player
{
    public override void DoSuperPower()
    {
        Vector3 newVector = Prefab.transform.position;
        newVector.y = 10f;
        Prefab.transform.position = newVector;
        Prefab.GetComponent<Rigidbody>().isKinematic = true;
    }

    public override void EndSuperPower()
    {
        Vector3 newVector = Prefab.transform.position;
        newVector.y = 1.8f;
        Prefab.transform.position = newVector;
        Prefab.GetComponent<Rigidbody>().isKinematic = false;
    }
}

class TankPlayer : Player
{
    int oldSpeed;
    public override void DoSuperPower()
    {
        oldSpeed = gameManager.GetComponent<SpeedControl>().speed;
        gameManager.GetComponent<SpeedControl>().speed = 50;
        Prefab.GetComponent<Rigidbody>().isKinematic = true;
    }

    public override void EndSuperPower()
    {
        gameManager.GetComponent<SpeedControl>().speed = oldSpeed;
        Prefab.GetComponent<Rigidbody>().isKinematic = false;
    }
}

class TheWorldPlayer : Player
{
    int oldSpeed;
    public override void DoSuperPower()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }

    public override void EndSuperPower()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
}

public class SuperPower : MonoBehaviour
{
    Player player;
    bool ctrlIsPressed = false;
    public LevelManager levelManager;
    public GameManager gameManager;
    public GameObject UltText;
    public GameObject playerObject;
    public int ultTime;
    public PlayerType playerType;
    public bool isUlt = false;

    void Start()
    {
        playerType = levelManager.playerType;
        if (playerType == PlayerType.FLY)
            player = new FlyPlayer();
        else if (playerType == PlayerType.TANK)
            player = new TankPlayer();
        else if (playerType == PlayerType.THEWORLD)
            player = new TheWorldPlayer();

        player.Prefab = playerObject;
        player.gameManager = gameManager;
        StartCoroutine(Ult());
    }

    void Update()
    {
        if (player.ultIsReady && Input.GetKeyDown(KeyCode.LeftControl))
        {
            ctrlIsPressed = true;
        }
    }

    IEnumerator Ult()
    {
        yield return new WaitForSeconds(1);
        if (player.ultPercent == ultTime)        
            player.ultIsReady = isUlt = true;        
        else if(player.ultPercent == -1)
        {
            player.ultPercent = 0;
            ctrlIsPressed = false;
            player.ultIsReady = isUlt = false;
            player.EndSuperPower();
            isUlt = false;
        }        

        if (player.ultIsReady)
        {
            if(player.ultPercent == ultTime && ctrlIsPressed)
            {
                player.DoSuperPower();
            }
            if(ctrlIsPressed)
                player.ultPercent--;
        }
        else        
            player.ultPercent++;
        UltText.GetComponent<Text>().text = player.ultPercent.ToString();
        StartCoroutine(Ult());
    }
}
