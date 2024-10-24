using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float moveSpeed = 10f; // Prêdkoœæ poruszania siê kamery
    public float mouseSensitivity = 100f; // Czu³oœæ myszy
    public float maxLookAngle = 90f; // Maksymalny k¹t patrzenia w górê i w dó³

    private float rotationX = 0f; // K¹t rotacji w osi X (góra/dó³)
    private float rotationY = 0f; // K¹t rotacji w osi Y (lewo/prawo)

    void Update()
    {
        // Obs³uga ruchu kamery klawiszami WASD
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Ruch w lewo/prawo (A/D)
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Ruch w przód/ty³ (W/S)

        // Ruch kamery
        transform.Translate(moveX, 0, moveZ);

        // Obs³uga obracania kamery mysz¹
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Aktualizacja k¹tów rotacji (Y: lewo/prawo, X: góra/dó³)
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxLookAngle, maxLookAngle); // Ograniczenie k¹ta patrzenia w górê i w dó³

        // Obrót kamery
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
