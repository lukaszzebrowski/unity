using UnityEngine;

public class square_move : MonoBehaviour
{
    public float speed = 5f;
    private float distance = 10f;
    private int currentEdge = 0; // 0 - prawo, 1 - góra, 2 - lewo, 3 - dó³
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = Vector3.zero;

        switch (currentEdge)
        {
            case 0:
                direction = Vector3.right;
                if (transform.position.x >= startPosition.x + distance)
                {
                    currentEdge++;
                    RotateCube();
                }
                break;
            case 1:
                direction = Vector3.forward;
                if (transform.position.z >= startPosition.z + distance)
                {
                    currentEdge++;
                    RotateCube();
                }
                break;
            case 2:
                direction = Vector3.left;
                if (transform.position.x <= startPosition.x)
                {
                    currentEdge++;
                    RotateCube();
                }
                break;
            case 3:
                direction = Vector3.back;
                if (transform.position.z <= startPosition.z)
                {
                    currentEdge = 0;
                    RotateCube();
                }
                break;
        }

        transform.position += direction * step;
    }

    void RotateCube()
    {
        transform.Rotate(0, 90, 0); // Obrót o 90 stopni w osi Y
    }

}
