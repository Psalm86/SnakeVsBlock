using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private SnakeTail Tail;
    public GameManager Gm;
    public Transform Head;
    public GameObject panel;
    public GameObject panelDead;
    private Vector3 _previousMousePosition;
    public float Speed;
    public float RotationSpeed;
    private int value;
    public int Health = 1;
    private bool CanMove = true;
    private bool canTick = true;
    public Vector3 moveVector = new Vector3(0, 0, 1);

    private void Start()
    {
        Tail = GetComponent<SnakeTail>();
    }
    void Update()
    {
        if (!CanMove)
            moveVector *= 0;
        else
            moveVector = new Vector3(0, 0, 1);

        moveVector = moveVector.normalized;
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            delta = delta.normalized;
            Vector3 newPosition = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + moveVector.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Speed * Time.deltaTime);       
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveVector, Speed * Time.deltaTime);

        _previousMousePosition = Input.mousePosition;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            value = collision.gameObject.GetComponent<Food>().Value;
            Health += value;
            Destroy(collision.gameObject);
            for (int i = 0; i < value; i++)
            {
                Tail.AddCircle();
            }
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Gm.OnPlayerWon();
            panel.SetActive(true);
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Block" && canTick)
        {
            value = collision.gameObject.GetComponent<Block>().Value;
            StartCoroutine(remover(value, collision));
            
        }

    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            CanMove = true;
        }
    }

    IEnumerator remover(int value, Collision collision)
    {
            canTick = false;
            CanMove = false;
            Health--;
            if (Health <= 0)
            {
                transform.position = Vector3.zero;
                panelDead.SetActive(true);
                Gm.OnPLayerDied();
                yield break;
            }
            Tail.RemoveCircle();
            collision.gameObject.GetComponent<Block>().Value--;
            if (value <= 1)
            {
                CanMove = true;
               Destroy(collision.gameObject);
            }
            yield return new WaitForSeconds(0.1f);
            canTick = true;     
    }

}
