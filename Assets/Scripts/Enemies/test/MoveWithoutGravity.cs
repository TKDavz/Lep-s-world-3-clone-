using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithoutGravity : MonoBehaviour
{ 
    public Transform[] pivotPoints; // Các điểm neo trên khối game object
    public float movementSpeed = 3f; // Tốc độ di chuyển của nhân vật
    public float rotationSpeed = 5f; // Tốc độ quay của nhân vật

    private int currentPivotIndex = 0; // Chỉ số điểm neo hiện tại

    private void Start()
    {
        
    }

    private void Update()
    {
        // Di chuyển nhân vật đến điểm neo hiện tại
        transform.position = Vector3.MoveTowards(transform.position, pivotPoints[currentPivotIndex].position, movementSpeed * Time.deltaTime);

        // Quay nhân vật đến điểm neo hiện tại
        Quaternion targetRotation = Quaternion.LookRotation(pivotPoints[currentPivotIndex].position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Kiểm tra nếu nhân vật đã đến điểm neo hiện tại, sau đó chuyển đến điểm neo tiếp theo
        if (transform.position == pivotPoints[currentPivotIndex].position)
        {
            currentPivotIndex = (currentPivotIndex + 1) % pivotPoints.Length;
        }
    }
}

