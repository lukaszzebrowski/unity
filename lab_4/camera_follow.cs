using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform target; // Obiekt, za którym kamera ma pod¹¿aæ (np. gracz)
    public Vector3 offset; // Odleg³oœæ kamery od obiektu (mo¿na ustawiæ w Inspektorze)
    public float smoothSpeed = 0.125f; // P³ynnoœæ ruchu kamery

    void LateUpdate()
    {
        // Pozycja, na któr¹ kamera powinna siê przemieœciæ
        Vector3 desiredPosition = target.position + offset;

        // P³ynne przemieszczanie kamery (interpolacja)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Ustawienie nowej pozycji kamery
        transform.position = smoothedPosition;

        // Kamera patrzy na obiekt
        transform.LookAt(target);
    }
}
