using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement2D : MonoBehaviour
{
    public Transform groundCenter; // Trung tâm của mặt đất hình tròn
    public float forceMultiplier = 10f; // Hệ số tăng cường lực

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Tính toán Vector từ vị trí hiện tại đến trung tâm của mặt đất
        Vector2 direction = groundCenter.position - transform.position;

        // Áp dụng lực hướng tâm lên nhân vật
        rb.AddForce(direction.normalized * forceMultiplier);
    }
}
