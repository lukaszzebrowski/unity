using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f; // Pr�dko�� windy
    private bool isRunning = false; // Czy winda jest w ruchu
    public float distance = 6.6f; // Odleg�o��, na jak� winda si� porusza
    private bool isRunningUp = true; // Czy winda porusza si� w g�r�
    private bool isRunningDown = false; // Czy winda porusza si� w d�
    private float downPosition; // Pozycja dolna windy
    private float upPosition; // Pozycja g�rna windy
    public float waitTime = 3f; // Czas oczekiwania na g�rze przed powrotem

    void Start()
    {
        upPosition = transform.position.y + distance; // Ustal pozycj� g�rn�
        downPosition = transform.position.y; // Ustal pozycj� doln�
    }

    void Update()
    {
        if (isRunningUp && transform.position.y >= upPosition)
        {
            isRunning = false; // Zatrzymaj ruch na g�rze
            StartCoroutine(WaitAndMoveDown()); // Rozpocznij czekanie przed powrotem na d�
        }
        else if (isRunningDown && transform.position.y <= downPosition)
        {
            isRunning = false; // Zatrzymaj ruch na dole
        }

        if (isRunning)
        {
            // Porusz wind� w g�r� lub w d�
            Vector3 move = transform.up * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private IEnumerator WaitAndMoveDown()
    {
        yield return new WaitForSeconds(waitTime); // Poczekaj okre�lon� liczb� sekund

        // Po czasie oczekiwania ustaw ruch w d�
        isRunningDown = true;
        isRunningUp = false;
        elevatorSpeed = -Mathf.Abs(elevatorSpeed); // Pr�dko�� w d�
        isRunning = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed� na wind�.");

            if (transform.position.y >= upPosition)
            {
                isRunningDown = true;
                isRunningUp = false;
                elevatorSpeed = -Mathf.Abs(elevatorSpeed);
            }
            else if (transform.position.y <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true; // Rozpocznij ruch windy
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed� z windy.");
        }
    }
}
