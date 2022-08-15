using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public int Value;
    Color lerpedColor = Color.white;
    public TextMeshPro ValueText;

    private void Start()
    {
        ValueText.SetText(Value.ToString());
        Value = Random.Range(1,20);
    }
    private void Update()
    {
        ValueText.SetText(Value.ToString());
        lerpedColor = Color.Lerp(Color.white, Color.red, (float)Value / 20f);
        this.GetComponent<Renderer>().material.color = lerpedColor;
    }
    public  void PointCount()
    {
        Value--;
    }
}
