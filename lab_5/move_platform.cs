using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_platform : MonoBehaviour
{
    // Lista punkt�w (waypoint�w), kt�re platforma ma odwiedzi�
    public List<Vector3> waypoints = new List<Vector3>();

    public float speed = 2f; // Pr�dko�� poruszania platformy
    private int currentWaypointIndex = 0; // Indeks bie��cego punktu docelowego
    private bool isReversing = false; // Czy platforma zawraca

    void Start()
    {
        // Sprawdzenie, czy mamy jakiekolwiek waypointy
        if (waypoints.Count == 0)
        {
            Debug.LogWarning("Brak zdefiniowanych waypoint�w!");
        }
    }

    void Update()
    {
        // Je�li nie mamy waypoint�w, to nie ma co robi�
        if (waypoints.Count == 0) return;

        // Poruszaj platform� w kierunku bie��cego waypointu
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        // Pobierz bie��cy waypoint
        Vector3 targetPosition = waypoints[currentWaypointIndex];

        // Przesuwaj platform� w kierunku bie��cego waypointu
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Sprawd�, czy dotarli�my do waypointu
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Przejd� do nast�pnego punktu lub zawr��, je�li dotarli�my do ko�ca
            if (!isReversing)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = waypoints.Count - 2; // Przejd� do przedostatniego punktu
                    isReversing = true;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1; // Przejd� do drugiego punktu
                    isReversing = false;
                }
            }
        }
    }

    // Metoda rysuj�ca linie mi�dzy waypointami w edytorze Unity
    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Count == 0) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
        }

        // Rysuj lini� powrotn�, je�li platforma zawraca
        if (isReversing)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(waypoints[waypoints.Count - 1], waypoints[waypoints.Count - 2]);
        }
    }
}
