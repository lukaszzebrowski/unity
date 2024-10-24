using UnityEngine;

public class jump : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f; // Si³a skoku
    public float gravity = -9.81f; // Wartoœæ grawitacji

    private Vector3 velocity; // Prêdkoœæ w osi Y (u¿ywana do skoku i grawitacji)
    private bool isGrounded; // Czy gracz jest na ziemi
    public Transform groundCheck; // Punkt sprawdzaj¹cy, czy gracz dotyka ziemi
    public float groundDistance = 0.4f; // Promieñ kuli sprawdzaj¹cej ziemiê
    public LayerMask groundMask; // Maskowanie warstwy ziemi

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pobieramy Rigidbody gracza
    }

    void Update()
    {
        // Sprawdzamy, czy gracz dotyka ziemi
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset prêdkoœci w dó³, gdy gracz dotyka ziemi
        }

        // Ruch w poziomie
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.position += new Vector3(moveX, 0, moveZ);

        // Skakanie
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Obliczamy prêdkoœæ skoku
        }

        // Grawitacja
        velocity.y += gravity * Time.deltaTime;

        // Przesuwanie gracza w osi Y
        transform.position += new Vector3(0, velocity.y * Time.deltaTime, 0);
    }
}
