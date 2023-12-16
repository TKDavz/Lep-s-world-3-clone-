using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    public bool destroy = true;
    public GameObject diedEffect;
    public float delayDestroyEffect = 3f;

    public GameObject enemy;
    public GameObject itemDrop;

    private Vector3 positonEnemy;
    private Quaternion rotationEnemy;


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(itemDrop.name);

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (destroy)
            {
                if (enemy != null)
                {
                    // Lưu lại giá trị transform của enemy trước khi hủy đối tượng
                    Transform transformEnemy = enemy.transform;
                    positonEnemy = new Vector3(transformEnemy.position.x, transformEnemy.position.y, transformEnemy.position.z);
                    rotationEnemy = new Quaternion(transformEnemy.rotation.x, transformEnemy.rotation.y, transformEnemy.rotation.z, transformEnemy.rotation.w);

                    enemy.transform.position = new Vector3(100, 100, 100);
                    enemy.SetActive(false);


                    if (diedEffect != null)
                    {
                        GameObject effectClone = Instantiate(diedEffect,
                                    positonEnemy,
                                    rotationEnemy);
                        ParticleSystem particle = effectClone.GetComponent<ParticleSystem>();
                        ParticleSystemRenderer particleRenderer = particle.GetComponent<ParticleSystemRenderer>();
                        particleRenderer.flip = new Vector3(enemy.transform.localScale.x > 0 ? 0 : 1, 0, 0);

                        //effectClone.transform.localScale = new Vector2(enemy.transform.localScale.x, effectClone.transform.localScale.y); 

                        Destroy(effectClone, delayDestroyEffect);
                        Invoke("DropItem", delayDestroyEffect);

                    }
                }
            }
        }
    }


    private void DropItem()
    {
        if (itemDrop != null)
        {
            // Lưu ý rằng transformEnemy không được sử dụng ở đây, mà đã được truyền qua Invoke
            GameObject itemClone = Instantiate(itemDrop,
                                    positonEnemy,
                                    rotationEnemy);

            Destroy(enemy);

        }
    }
}