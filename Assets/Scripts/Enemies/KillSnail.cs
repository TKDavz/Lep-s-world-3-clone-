using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KillSnail : MonoBehaviour
{

    public bool destroy = true;
    public GameObject diedEffect;
    public GameObject lethalArea;

    public float hidingTime = 5f;
    public float delayDestroyEffect = 2f;

    public int numberOfTimesTrampled = 2;
    private int numberOfTimes;
    public Animator snailAnimator;

    public GameObject enemy;
    public GameObject itemDrop;

    public MonoBehaviour[] unenabledScript;

    private bool isDied = false;
    private Vector3 positonEnemy;
    private Quaternion rotationEnemy;


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        numberOfTimes = numberOfTimesTrampled;
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("number" + numberOfTimes);
            if (destroy)
            {
                if (enemy != null)
                {
                   
                    if (numberOfTimes <= 0)
                    {
                        // Lưu lại giá trị transform của enemy trước khi hủy đối tượng
                        Transform transformEnemy = enemy.transform;
                        positonEnemy = new Vector3(transformEnemy.position.x, transformEnemy.position.y, transformEnemy.position.z);
                        rotationEnemy = new Quaternion(transformEnemy.rotation.x, transformEnemy.rotation.y, transformEnemy.rotation.z, transformEnemy.rotation.w);

                        enemy.transform.position = new Vector3(100, 100, 100);
                        enemy.SetActive(false);
                        isDied = true;


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
                    else
                    {

                        isDied = false;
                        if (lethalArea != null)
                        {
                            lethalArea.SetActive(false);
                        }
                        numberOfTimes--;
                        Invoke("UnHide", hidingTime);
                        if (snailAnimator != null)
                        {
                            snailAnimator.SetBool("isCrawling", false);
                            snailAnimator.SetBool("intoTheShell", true);
                            snailAnimator.SetBool("isStay", true);
                        }
                        if (unenabledScript != null)
                        {
                            foreach (MonoBehaviour script in unenabledScript)
                            {
                                script.enabled = false;
                            }
                        }
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

    private void UnHide()
    {
        if (!isDied)
        {

            if (unenabledScript != null)
            {
                foreach (MonoBehaviour script in unenabledScript)
                {
                    script.enabled = true;
                }
            }
            if (snailAnimator != null)
            {
                snailAnimator.SetBool("isCrawling", true);
                snailAnimator.SetBool("isStay", false);
                snailAnimator.SetBool("intoTheShell", false);
            }
            if (lethalArea != null)
            {
                lethalArea.SetActive(true);
            }
            numberOfTimes = numberOfTimesTrampled;
        }
    }
}