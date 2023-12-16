using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravitationalConstant = 6.674f; // Hằng số hấp dẫn
    public Rigidbody2D playerRigidbody; // Rigidbody2D của nhân vật

    private Rigidbody2D groundRigidbody; // Rigidbody2D của mặt đất

    private void Start()
    {
        groundRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = playerRigidbody.position - groundRigidbody.position;
        float distance = direction.magnitude;
        direction.Normalize();

        float forceMagnitude = (gravitationalConstant * groundRigidbody.mass * playerRigidbody.mass) / (distance * distance);
        Vector2 force = direction * forceMagnitude;

        playerRigidbody.AddForce(force);
    }
}
