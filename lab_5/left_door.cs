using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoor : MonoBehaviour
{
    public float doorSpeed = 2f; // Prêdkoœæ otwierania drzwi
    public float distance = 2f; // Odleg³oœæ otwarcia drzwi
    private float closedPosition; // Pozycja zamkniêta drzwi
    private float openPosition; // Pozycja otwarta drzwi
    public float waitTime = 3f; // Czas oczekiwania przed zamkniêciem
    private bool isOpening = false; // Czy drzwi siê otwieraj¹

    void Start()
    {
        closedPosition = transform.position.x; // Ustal pozycjê zamkniêt¹
        openPosition = closedPosition - distance; // Ustal pozycjê otwart¹ (w lewo)
    }

    void Update()
    {
        if (isOpening && transform.position.x <= openPosition)
        {
            isOpening = false; // Zatrzymaj ruch po osi¹gniêciu pozycji otwartej
            StartCoroutine(CloseDoor()); // Rozpocznij czekanie przed zamkniêciem
        }

        if (isOpening)
        {
            // Przesuñ drzwi w lewo
            Vector3 move = Vector3.left * doorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(waitTime); // Poczekaj okreœlon¹ liczbê sekund

        // Po czasie oczekiwania zamknij drzwi
        while (transform.position.x < closedPosition)
        {
            transform.Translate(Vector3.right * doorSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi otwieraj¹ siê w lewo.");
            isOpening = true; // Rozpocznij otwieranie drzwi
        }
    }
}
