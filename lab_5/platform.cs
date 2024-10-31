using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float elevatorSpeed = 2f; // Pr�dko�� platformy
    private bool isRunning = false; // Czy platforma jest w ruchu
    public float distance = 6.6f; // Dystans, na jaki porusza si� platforma
    private float startPosition; // Pocz�tkowa pozycja platformy (na osi Z)
    private float endPosition; // Ko�cowa pozycja platformy (na osi Z)

    void Start()
    {
        // Ustalenie pozycji pocz�tkowej i ko�cowej
        startPosition = transform.position.z;
        endPosition = startPosition + distance;
    }

    void Update()
    {
        if (isRunning)
        {
            // Przesuwanie platformy wzd�u� osi Z
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);

            // Zmiana kierunku, gdy platforma osi�gnie pozycj� ko�cow� lub pocz�tkow�
            if (transform.position.z >= endPosition)
            {
                elevatorSpeed = -Mathf.Abs(elevatorSpeed); // Ruch do ty�u
            }
            else if (transform.position.z <= startPosition)
            {
                elevatorSpeed = Mathf.Abs(elevatorSpeed); // Ruch do przodu
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed� na wind�.");
            isRunning = true; // Platforma zaczyna si� porusza�, gdy gracz na ni� wejdzie
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Platforma porusza si�, dop�ki gracz na niej pozostaje
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed� z windy.");
            isRunning = false; // Platforma zatrzymuje si�, gdy gracz z niej zejdzie
        }
    }
}
