using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBlock : MonoBehaviour
{
    private Vector2 initialPosition;
    private bool isBouncing = false;

    public float bounceHeight = 0.5f;
    public float bounceDuration = 0.2f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isBouncing)
        {

            Debug.Log("Value y: " + collision.GetContact(0).normal.y);
            Debug.Log("Value x: " + collision.GetContact(0).normal.x);

            // Kiểm tra hướng va chạm (y > 0 đại diện cho va chạm từ phía dưới)
            if (collision.GetContact(0).normal.y > 0)
            {
                StartCoroutine(Bounce());
            }
        }
    }


    private IEnumerator Bounce()
    {
        isBouncing = true;

        // Lưu vị trí ban đầu của khối gạch
        Vector2 startPos = initialPosition;

        // Tính toán vị trí mới để nảy lên
        Vector2 endPos = startPos + new Vector2(0f, bounceHeight);

        float time = 0f;

        while (time < bounceDuration)
        {
            // Tính toán tiến trình di chuyển từ 0 đến 1
            float t = time / bounceDuration;

            // Di chuyển khối gạch dọc theo đường cong nảy lên (có thể sử dụng các phương thức khác nhau như Lerp, Slerp, hoặc Ease)
            transform.position = Vector2.Lerp(startPos, endPos, t);

            time += Time.deltaTime;
            yield return null;
        }

        time = 0f;

        while (time < bounceDuration)
        {
            // Tính toán tiến trình di chuyển từ 0 đến 1
            float t = time / bounceDuration;

            // Di chuyển khối gạch dọc theo đường cong nảy lên (có thể sử dụng các phương thức khác nhau như Lerp, Slerp, hoặc Ease)
            // Đặt khối gạch về vị trí ban đầu
            transform.position = Vector2.Lerp(endPos, startPos, t);

            time += Time.deltaTime;
            yield return null;
        }


        isBouncing = false;
    }
}

