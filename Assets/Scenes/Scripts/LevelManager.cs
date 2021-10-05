using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public PlayerType playerType;

    public void Restart()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        SceneManager.LoadScene("SampleScene");
    }

    public void FlyStart()
    {
        playerType = PlayerType.FLY;
        Restart();
    }

    public void TankStart()
    {
        playerType = PlayerType.TANK;
        Restart();
    }

    public void TheWorldStart()
    {
        playerType = PlayerType.THEWORLD;
        Restart();
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        SceneManager.LoadScene("Start");
    }
}
