using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsAdder : MonoBehaviour
{
    public GameObject PointsText;

    void Update()
    {
        PointsText.GetComponent<Text>().text = ((int)transform.position.z).ToString();
    }
}
