using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player; // Referencja do obiektu gracza
    public float mouseSensitivity = 100f; // Czu³oœæ myszy

    private float xRotation = 0f; // Bie¿¹cy k¹t nachylenia kamery w osi X

    void Start()
    {
        // Zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Pobieramy wartoœci ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Obracamy gracza wokó³ osi Y (obrót poziomy)
        player.Rotate(Vector3.up * mouseXMove);

        // Aktualizacja k¹ta nachylenia kamery w osi X (góra-dó³)
        xRotation -= mouseYMove; // Odejmujemy, bo ruch myszy w górê powoduje negatywn¹ rotacjê
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ograniczamy rotacjê do zakresu -90 i +90 stopni

        // Zastosowanie ograniczonej rotacji do kamery
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
