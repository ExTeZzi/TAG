using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelClick : MonoBehaviour
{
    public Text num;
    public void SelectButton()
    {
        num.GetComponent<Text>().text = GetComponentInChildren<Text>().text;

    }
}
