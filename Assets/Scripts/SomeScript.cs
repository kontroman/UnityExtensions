using DevotionEntertainment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomeScript : KontromanMono
{
    int five = 5;

    private void Start()
    {
        PlayerPrefs.SetInt("Five", five);

        SPlayerPrefs.SetInt("NewFive", five);
    }
}
