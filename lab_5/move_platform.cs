using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_platform : MonoBehaviour
{
    // Lista punktów (waypointów), które platforma ma odwiedziæ
    public List<Vector3> waypoints = new List<Vector3>();

    public float speed = 2f; // Prêdkoœæ poruszania platformy
    private int currentWaypointIndex = 0; // Indeks bie¿¹cego punktu docelowego
    private bool isReversing = false; // Czy platforma zawraca

    void Start()
    {
        // Sprawdzenie, czy mamy jakiekolwiek waypointy
        if (waypoints.Count == 0)
        {
            Debug.LogWarning("Brak zdefiniowanych waypointów!");
        }
    }

    void Update()
    {
        // Jeœli nie mamy waypointów, to nie ma co robiæ
        if (waypoints.Count == 0) return;

        // Poruszaj platformê w kierunku bie¿¹cego waypointu
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        // Pobierz bie¿¹cy waypoint
        Vector3 targetPosition = waypoints[currentWaypointIndex];

        // Przesuwaj platformê w kierunku bie¿¹cego waypointu
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // SprawdŸ, czy dotarliœmy do waypointu
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // PrzejdŸ do nastêpnego punktu lub zawróæ, jeœli dotarliœmy do koñca
            if (!isReversing)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = waypoints.Count - 2; // PrzejdŸ do przedostatniego punktu
                    isReversing = true;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1; // PrzejdŸ do drugiego punktu
                    isReversing = false;
                }
            }
        }
    }

    // Metoda rysuj¹ca linie miêdzy waypointami w edytorze Unity
    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Count == 0) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
        }

        // Rysuj liniê powrotn¹, jeœli platforma zawraca
        if (isReversing)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(waypoints[waypoints.Count - 1], waypoints[waypoints.Count - 2]);
        }
    }
}
