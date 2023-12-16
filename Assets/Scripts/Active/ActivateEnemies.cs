using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{
    public float activationDistance = 10f;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null) // Kiểm tra xem enemy có tồn tại hay không
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance <= activationDistance)
                {
                    enemy.SetActive(true);
                }
                else
                {
                    enemy.SetActive(false);
                }
            }
        }
    }
}
