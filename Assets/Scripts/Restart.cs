using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text score;
    public Controls player;

    private void Start()
    {
        score.text = "Score: " + player.Health.ToString();
    }
}
