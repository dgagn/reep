using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Cash : MonoBehaviour
{
    public TextMeshProUGUI text;

    public int cash;
    public void GiveCash(int amount)
    {
        cash += amount;
        text.SetText($"{cash:C0}");
    }

    public void TakeCash(int amount)
    {
        cash -= amount;
        text.SetText($"{cash:C0}");
    }
}
