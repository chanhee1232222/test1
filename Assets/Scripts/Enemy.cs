using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Vector2 moveDirection = Vector2.down;
    private Animator animator;
    public GameObject explosionEffect;
    public int dieScore = 0;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Easy Enemy");
        speed = Random.Range(1f, 3f);

    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        
        if (other.CompareTag("End Line"))
        {
            Destroy(gameObject);
            Debug.Log("Gmae Over");
        }
    }


}
