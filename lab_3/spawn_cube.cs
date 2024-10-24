using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_cube : MonoBehaviour
{
    public GameObject cubePrefab;
    public int cubeCount = 10;
    public float planeSize = 10f;

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-planeSize / 2, planeSize / 2),
                0.5f,
                Random.Range(-planeSize / 2, planeSize / 2)
            );

            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }
}