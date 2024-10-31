using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_platform : MonoBehaviour
{
    public float launchForceMultiplier = 3f; // Wsp�czynnik si�y wyrzutu
    private float defaultJumpForce = 5f; // Przyk�adowa si�a skoku gracza (mo�esz dostosowa�)

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy obiekt, kt�ry wszed� na p�yt�, jest graczem
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed� na p�yt� naciskow�.");

            // Pobierz skrypt kontroluj�cy ruch gracza
            MoveWithCharacterController playerController = other.GetComponent<MoveWithCharacterController>();

            if (playerController != null)
            {
                // Oblicz si�� wyrzutu
                float launchForce = defaultJumpForce * launchForceMultiplier;

                // Wywo�aj metod�, kt�ra wyrzuci gracza w g�r�
                playerController.LaunchPlayer(launchForce);
            }
        }
    }
}
