using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f; // Prêdkoœæ poruszania siê
    private float distance = 10f; // Dystans do przejœcia
    private bool moveForward = true; // Flaga do zmiany kierunku
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (moveForward)
        {
            transform.position += new Vector3(step, 0, 0);
            if (transform.position.x >= startPosition.x + distance)
            {
                moveForward = false;
            }
        }
        else
        {
            transform.position -= new Vector3(step, 0, 0);
            if (transform.position.x <= startPosition.x)
            {
                moveForward = true;
            }
        }
    }
}
