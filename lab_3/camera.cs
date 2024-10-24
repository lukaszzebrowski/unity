using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float moveSpeed = 10f; // Pr�dko�� poruszania si� kamery
    public float mouseSensitivity = 100f; // Czu�o�� myszy
    public float maxLookAngle = 90f; // Maksymalny k�t patrzenia w g�r� i w d�

    private float rotationX = 0f; // K�t rotacji w osi X (g�ra/d�)
    private float rotationY = 0f; // K�t rotacji w osi Y (lewo/prawo)

    void Update()
    {
        // Obs�uga ruchu kamery klawiszami WASD
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Ruch w lewo/prawo (A/D)
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Ruch w prz�d/ty� (W/S)

        // Ruch kamery
        transform.Translate(moveX, 0, moveZ);

        // Obs�uga obracania kamery mysz�
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Aktualizacja k�t�w rotacji (Y: lewo/prawo, X: g�ra/d�)
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxLookAngle, maxLookAngle); // Ograniczenie k�ta patrzenia w g�r� i w d�

        // Obr�t kamery
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
