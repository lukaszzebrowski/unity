using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f; // Prêdkoœæ windy
    private bool isRunning = false; // Czy winda jest w ruchu
    public float distance = 6.6f; // Odleg³oœæ, na jak¹ winda siê porusza
    private bool isRunningUp = true; // Czy winda porusza siê w górê
    private bool isRunningDown = false; // Czy winda porusza siê w dó³
    private float downPosition; // Pozycja dolna windy
    private float upPosition; // Pozycja górna windy
    public float waitTime = 3f; // Czas oczekiwania na górze przed powrotem

    void Start()
    {
        upPosition = transform.position.y + distance; // Ustal pozycjê górn¹
        downPosition = transform.position.y; // Ustal pozycjê doln¹
    }

    void Update()
    {
        if (isRunningUp && transform.position.y >= upPosition)
        {
            isRunning = false; // Zatrzymaj ruch na górze
            StartCoroutine(WaitAndMoveDown()); // Rozpocznij czekanie przed powrotem na dó³
        }
        else if (isRunningDown && transform.position.y <= downPosition)
        {
            isRunning = false; // Zatrzymaj ruch na dole
        }

        if (isRunning)
        {
            // Porusz windê w górê lub w dó³
            Vector3 move = transform.up * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private IEnumerator WaitAndMoveDown()
    {
        yield return new WaitForSeconds(waitTime); // Poczekaj okreœlon¹ liczbê sekund

        // Po czasie oczekiwania ustaw ruch w dó³
        isRunningDown = true;
        isRunningUp = false;
        elevatorSpeed = -Mathf.Abs(elevatorSpeed); // Prêdkoœæ w dó³
        isRunning = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");

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
            Debug.Log("Player zszed³ z windy.");
        }
    }
}
