using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public int Value;
    public TextMeshPro ValueText;

    void Start()
    {
        Value = Random.Range(1, 5);
        ValueText.SetText(Value.ToString());
    }
}
