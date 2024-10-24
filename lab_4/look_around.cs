using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player; // Referencja do obiektu gracza
    public float mouseSensitivity = 100f; // Czu�o�� myszy

    private float xRotation = 0f; // Bie��cy k�t nachylenia kamery w osi X

    void Start()
    {
        // Zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Pobieramy warto�ci ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Obracamy gracza wok� osi Y (obr�t poziomy)
        player.Rotate(Vector3.up * mouseXMove);

        // Aktualizacja k�ta nachylenia kamery w osi X (g�ra-d�)
        xRotation -= mouseYMove; // Odejmujemy, bo ruch myszy w g�r� powoduje negatywn� rotacj�
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ograniczamy rotacj� do zakresu -90 i +90 stopni

        // Zastosowanie ograniczonej rotacji do kamery
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
