using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawd�, czy obiekt, z kt�rym gracz si� zderzy�, ma tag "obiekt"
        if (collision.gameObject.CompareTag("obiekt"))
        {
            Debug.Log("Gracz zderzy� si� z przeszkod�: " + collision.gameObject.name);
        }
    }
}
