using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform target; // Obiekt, za kt�rym kamera ma pod��a� (np. gracz)
    public Vector3 offset; // Odleg�o�� kamery od obiektu (mo�na ustawi� w Inspektorze)
    public float smoothSpeed = 0.125f; // P�ynno�� ruchu kamery

    void LateUpdate()
    {
        // Pozycja, na kt�r� kamera powinna si� przemie�ci�
        Vector3 desiredPosition = target.position + offset;

        // P�ynne przemieszczanie kamery (interpolacja)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Ustawienie nowej pozycji kamery
        transform.position = smoothedPosition;

        // Kamera patrzy na obiekt
        transform.LookAt(target);
    }
}
