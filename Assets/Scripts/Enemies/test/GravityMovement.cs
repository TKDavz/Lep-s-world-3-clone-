using UnityEngine;

public class GravityMovement : MonoBehaviour
{
    public Transform center; // Trọng tâm

    private Rigidbody2D rb;

    public float forceMultiplier = 10f; // Hệ số tăng cường lực
    public float maxSpeed = 5f; // Tốc độ tối đa

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Tính toán Vector từ vị trí hiện tại đến trọng tâm
        Vector3 direction = center.position - transform.position;

        // Áp dụng lực vật lên nhân vật
        rb.AddForce(direction.normalized * forceMultiplier);

        // Giới hạn tốc độ tối đa
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        // Áp dụng lực quay lên nhân vật
        //rb.AddTorque(Vector3.Cross(transform.up, direction));
    }
}
