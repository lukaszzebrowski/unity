using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy obiekt, z którym gracz siê zderzy³, ma tag "obiekt"
        if (collision.gameObject.CompareTag("obiekt"))
        {
            Debug.Log("Gracz zderzy³ siê z przeszkod¹: " + collision.gameObject.name);
        }
    }
}
