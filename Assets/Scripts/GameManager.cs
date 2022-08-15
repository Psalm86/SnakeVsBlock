using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Controls control;
    public GameObject Loss;
    public Moving cam;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPLayerDied()
    {
        if (CurrentState != State.Playing) 
            return;

        CurrentState = State.Loss;
        control.enabled = false;
        Debug.Log("Game Over");
        Loss.SetActive(true);
    }

    internal void OnPlayerWon()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        control.enabled = false;
        cam.enabled = false;
        Debug.Log("You Won!");
    }
    private void Update()
    {
        if(CurrentState == State.Won)
            control.transform.position = Vector3.MoveTowards(transform.position, transform.position + control.moveVector, control.Speed * Time.deltaTime);
    }
}
