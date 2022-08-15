using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Controls Player;
    public Transform Finish;
    public Slider Slider;
    private float _startZ;
    public Text txt;

    private void Start()
    {
        _startZ = Player.transform.position.z;
    }
    private void Update()
    {     
        float currentZ = Player.transform.position.z;
        float finishY = Finish.position.z;
       float t = Mathf.InverseLerp(_startZ, finishY, currentZ);
        Slider.value = t;
        txt.text = "Health: " + Player.Health.ToString();
    }
}
