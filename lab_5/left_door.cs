using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoor : MonoBehaviour
{
    public float doorSpeed = 2f; // Pr�dko�� otwierania drzwi
    public float distance = 2f; // Odleg�o�� otwarcia drzwi
    private float closedPosition; // Pozycja zamkni�ta drzwi
    private float openPosition; // Pozycja otwarta drzwi
    public float waitTime = 3f; // Czas oczekiwania przed zamkni�ciem
    private bool isOpening = false; // Czy drzwi si� otwieraj�

    void Start()
    {
        closedPosition = transform.position.x; // Ustal pozycj� zamkni�t�
        openPosition = closedPosition - distance; // Ustal pozycj� otwart� (w lewo)
    }

    void Update()
    {
        if (isOpening && transform.position.x <= openPosition)
        {
            isOpening = false; // Zatrzymaj ruch po osi�gni�ciu pozycji otwartej
            StartCoroutine(CloseDoor()); // Rozpocznij czekanie przed zamkni�ciem
        }

        if (isOpening)
        {
            // Przesu� drzwi w lewo
            Vector3 move = Vector3.left * doorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(waitTime); // Poczekaj okre�lon� liczb� sekund

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
            Debug.Log("Drzwi otwieraj� si� w lewo.");
            isOpening = true; // Rozpocznij otwieranie drzwi
        }
    }
}
