using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float elevatorSpeed = 2f; // Prêdkoœæ platformy
    private bool isRunning = false; // Czy platforma jest w ruchu
    public float distance = 6.6f; // Dystans, na jaki porusza siê platforma
    private float startPosition; // Pocz¹tkowa pozycja platformy (na osi Z)
    private float endPosition; // Koñcowa pozycja platformy (na osi Z)

    void Start()
    {
        // Ustalenie pozycji pocz¹tkowej i koñcowej
        startPosition = transform.position.z;
        endPosition = startPosition + distance;
    }

    void Update()
    {
        if (isRunning)
        {
            // Przesuwanie platformy wzd³u¿ osi Z
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);

            // Zmiana kierunku, gdy platforma osi¹gnie pozycjê koñcow¹ lub pocz¹tkow¹
            if (transform.position.z >= endPosition)
            {
                elevatorSpeed = -Mathf.Abs(elevatorSpeed); // Ruch do ty³u
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
            Debug.Log("Player wszed³ na windê.");
            isRunning = true; // Platforma zaczyna siê poruszaæ, gdy gracz na ni¹ wejdzie
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Platforma porusza siê, dopóki gracz na niej pozostaje
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
            isRunning = false; // Platforma zatrzymuje siê, gdy gracz z niej zejdzie
        }
    }
}
