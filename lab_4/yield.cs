using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class yield : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;

    // Obiekt do generowania
    public GameObject block;

    // Liczba obiekt�w do wygenerowania (mo�na ustawi� w Inspektorze)
    public int numberOfObjects = 10;

    // Lista materia��w (mo�na przypisa� materia�y w Inspektorze)
    public Material[] materials;

    private Bounds platformBounds;

    void Start()
    {
        // Pobieramy obiekt, na kt�rym jest osadzony skrypt i sprawdzamy jego wymiary
        Renderer platformRenderer = GetComponent<Renderer>();
        if (platformRenderer != null)
        {
            platformBounds = platformRenderer.bounds;
        }
        else
        {
            Debug.LogError("Platforma nie ma komponentu Renderer.");
            return;
        }

        // Generowanie losowych pozycji w obr�bie platformy
        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = UnityEngine.Random.Range(platformBounds.min.x, platformBounds.max.x);
            float randomZ = UnityEngine.Random.Range(platformBounds.min.z, platformBounds.max.z);
            Vector3 randomPosition = new Vector3(randomX, platformBounds.max.y + 0.5f, randomZ); // Ustawienie kostek nad platform�
            positions.Add(randomPosition);
        }

        // Wy�wietlenie wygenerowanych pozycji w konsoli
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        // Uruchomienie Coroutine do generowania obiekt�w
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        // Zaktualizowane w razie potrzeby
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywo�ano coroutine");
        foreach (Vector3 pos in positions)
        {
            // Instancjonowanie obiektu
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);

            // Losowy materia�
            if (materials.Length > 0)
            {
                Renderer blockRenderer = newBlock.GetComponent<Renderer>();
                if (blockRenderer != null)
                {
                    Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                    blockRenderer.material = randomMaterial;
                }
            }

            objectCounter++;
            yield return new WaitForSeconds(this.delay);
        }
    }
}

