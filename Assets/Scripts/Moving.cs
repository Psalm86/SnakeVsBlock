using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public Controls Player;
    public Vector3 MoveCamera;
    public float Speed;
    private void Update()
    {

        Vector3 targetPosition = Player.transform.position + MoveCamera;
        transform.position = Vector3.MoveTowards(transform.position,targetPosition,Speed);
       
    }
}
