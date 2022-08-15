using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform Head;
    public float CircleDiameter;
    private List<Transform> snakeCircle = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();


    private void Awake()
    {
        positions.Add(Head.position);
    }
    private void Update()
    {
        float distance = (Head.transform.position - positions[0]).magnitude;
        if (distance > CircleDiameter)
        {
            Vector3 direction = (Head.transform.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }
        for (int i = 0; i < snakeCircle.Count; i++)
        {
            snakeCircle[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }
    public void AddCircle()
    {
        Transform circle = Instantiate(Head, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircle.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        Destroy(snakeCircle[0].gameObject);
        snakeCircle.RemoveAt(0);
        positions.RemoveAt(1);
    }

}
