using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMove : MonoBehaviour
{
    public bool avoidTheVoid = true;
    public bool onTheGround = false;
    public float speed = 5f;

    private bool isFalling = false;
    private float timeSinceLastGrounded = 0f;
    private float timeThreshold = 0.2f;

    private bool isRight = false;

    Rigidbody2D rigid;

    public float raycastDistance = 0.1f;
    private TilemapCollider2D tilemapCollider;

    private void Awake()
    {
        tilemapCollider = FindObjectOfType<TilemapCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (onTheGround)
        //{
        //    // Phát ra một raycast để kiểm tra phía trước
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, isRight ? Vector2.right : Vector2.left, 0.5f);

        //    // Nếu raycast chạm vào collider khác
        //    if (hit.collider != null && !hit.collider.CompareTag("Player"))
        //    {
        //        // Xử lý logic khi gặp vực hoặc vật cản
        //        Debug.Log("Phía trước không có đường");

        //        // Đổi hướng di chuyển
        //        isRight = !isRight;
        //    }
        //    else
        //    {
        //        // Di chuyển bình thường
        //        transform.Translate(Time.deltaTime * speed * (isRight ? 1f : -1f), 0, 0);
        //        Vector2 v = transform.localScale;
        //        v.x *= (isRight && v.x > 0) || (!isRight && v.x < 0) ? -1 : 1;
        //        transform.localScale = v;
        //    }
        //}

        // Kiểm tra xem có mặt đất phía trước không
        //Vector2 raycastOrigin = transform.position;
        //Vector2 raycastDirection = Vector2.down;

        //RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance, tilemapCollider);

        //// Nếu tia chạm vào tilemap (mặt đất) thì có thể tiếp tục đi tiếp
        //if (hit.collider != null)
        //{
            // Xử lý khi phía trước là mặt đất
        //    Debug.Log("Ground ahead!");
        //}
        //else
        //{
        //    // Xử lý khi phía trước là vực hoặc không có gì cả
        //    Debug.Log("There is a gap ahead!");
        //}
        //// Nếu tia chạm vào tilemap (mặt đất) thì có thể tiếp tục đi tiếp
        //if (hit.collider != null && hit.collider.CompareTag("Ground"))
        //{
            // Xử lý khi phía trước là mặt đất
            Debug.Log("Ground ahead!");

            if (!onTheGround)
            {
                if (isFalling)
                {
                    timeSinceLastGrounded += Time.deltaTime;
                    if (timeSinceLastGrounded >= timeThreshold)
                    {
                        // Đối tượng đã thoát khỏi mặt đất trong 0.2 giây và không trở lại mặt đất.
                        // Thực hiện các hành động phù hợp ở đây.
                        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, 0);
                        rigid.freezeRotation = true;
                    }
                }
                else
                {
                    isFalling = true;
                    timeSinceLastGrounded = 0f;
                }
            }
            else
            {
                isFalling = false;
                timeSinceLastGrounded = 0f;

                transform.Translate(Time.deltaTime * speed * (isRight ? 1f : -1f), 0, 0);
                Vector2 v = transform.localScale;
                v.x *= (isRight && v.x > 0) || (!isRight && v.x < 0) ? -1 : 1;
                transform.localScale = v;
            }
        //}
        //else
        //{
        //    // Xử lý khi phía trước là vực hoặc không có gì cả
        //    Debug.Log("There is a gap ahead!");
        //    isRight = !isRight;
        //}

  
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObj = collision.gameObject;

        if (gameObj.CompareTag("Player"))
        {
            // Xử lý logic khi va chạm với Player
            Debug.Log("Va chạm với Player");

           
        }
        else
        {
            
            // Xử lý logic khi va chạm với vật thể khác
            if (gameObj.CompareTag("Ground"))
            {
                onTheGround = true;
                rigid.freezeRotation = false;
            }

            if (gameObj.CompareTag("MapWall") || gameObj.CompareTag("Wall") || gameObj.CompareTag("Enemy"))
            {
                isRight = !isRight;
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onTheGround = true;
            rigid.freezeRotation = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            onTheGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

}
