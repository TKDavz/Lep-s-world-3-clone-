using UnityEngine;
using System.Collections.Generic;

public class MultipleCenterMovement : MonoBehaviour
{
    public List<Transform> centers; // Danh sách các trung tâm
    public float forceMultiplier = 10f; // Hệ số tăng cường lực

    private Rigidbody2D rb;
    private int currentCenterIndex = 0; // Chỉ số trung tâm hiện tại

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Kiểm tra nếu danh sách trung tâm không rỗng
        if (centers.Count > 0)
        {
            // Lựa chọn trung tâm phù hợp từ danh sách
            Transform currentCenter = centers[currentCenterIndex];

            // Tính toán Vector từ vị trí hiện tại đến trung tâm
            Vector3 direction = currentCenter.position - transform.position;

            // Áp dụng lực hướng tâm lên vật thể
            rb.AddForce(direction.normalized * forceMultiplier);
        }
    }

    // Phương thức này có thể được gọi từ các sự kiện hoặc quy tắc để chuyển đến trung tâm tiếp theo trong danh sách
    public void SwitchToNextCenter()
    {
        currentCenterIndex = (currentCenterIndex + 1) % centers.Count;
    }
}
