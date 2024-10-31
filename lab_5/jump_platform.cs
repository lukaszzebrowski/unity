using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_platform : MonoBehaviour
{
    public float launchForceMultiplier = 3f; // Wspó³czynnik si³y wyrzutu
    private float defaultJumpForce = 5f; // Przyk³adowa si³a skoku gracza (mo¿esz dostosowaæ)

    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy obiekt, który wszed³ na p³ytê, jest graczem
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed³ na p³ytê naciskow¹.");

            // Pobierz skrypt kontroluj¹cy ruch gracza
            MoveWithCharacterController playerController = other.GetComponent<MoveWithCharacterController>();

            if (playerController != null)
            {
                // Oblicz si³ê wyrzutu
                float launchForce = defaultJumpForce * launchForceMultiplier;

                // Wywo³aj metodê, która wyrzuci gracza w górê
                playerController.LaunchPlayer(launchForce);
            }
        }
    }
}
