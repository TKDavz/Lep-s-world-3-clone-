using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour
{
    public float destroyDelay = 0.1f; // Thời gian delay trước khi khối bị hủy (tính bằng giây)

    public GameObject effectBrokenBlock; // Prefab của hiệu ứng bạn tạo
    public GameObject newGameObject; // Game object mới bạn muốn sinh ra
    public float flyingForceOfNewGameObject = 150f;

    void Start()
    {

    }

    private void Update()
    {

    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("aaaaaaaa" + collision.gameObject.tag);
    //    if (collision.gameObject.CompareTag("TopHeadPlayer"))
    //    {

    //        // Kiểm tra hướng va chạm (y > 0 đại diện cho va chạm từ phía dưới)
    //        if (collision.GetContact(0).normal.y > 0)
    //        {
    //            Invoke("DestroyBlock", destroyDelay);
    //            ApplyEffect();
    //            SpawnGameObject();
    //        }

    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("TopHeadPlayer"))
        {
            // Kiểm tra hướng va chạm (y > 0 đại diện cho va chạm từ phía dưới)
            if (other.transform.up.y > 0)
            {
                Invoke("DestroyBlock", destroyDelay);
                ApplyEffect();
                SpawnGameObject();
            }
        }
    }

    private void ApplyEffect()
    {
        // Áp dụng hiệu ứng tại đây
        // Ví dụ:
        // Instantiate(effectPrefab, transform.position, Quaternion.identity);
        if (effectBrokenBlock != null)
        {
            GameObject hieuUng = Instantiate(effectBrokenBlock,
                                        gameObject.transform.position,
                                        gameObject.transform.localRotation);
            Destroy(hieuUng, 5);
        }
    }

    private void SpawnGameObject()
    {
        if (newGameObject != null)
        {
            // Sinh ra game object mới tại vị trí hiện tại của khối
            GameObject newGameObjectClone = Instantiate(newGameObject, transform.position, Quaternion.identity);

            Rigidbody2D rigid = newGameObjectClone.GetComponent<Rigidbody2D>();


            if (rigid != null)
            {
                rigid.bodyType = RigidbodyType2D.Dynamic;
                rigid.AddForce(Vector2.up * flyingForceOfNewGameObject);
            }


        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
    }

}

