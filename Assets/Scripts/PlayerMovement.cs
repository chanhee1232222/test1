using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //플레이어 관련
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireRate = 0.5f;          //0.5초당 총알 발사 가능
    private float nextFireTime = 0f;

    public Transform playerStartPosition;   //플레이어 시작위치

    void Start()
    {
        transform.position = playerStartPosition.position;
        animator = GetComponent<Animator>();
        animator.Play("Stop Up"); //시작했을 때 위를 보고 있기
    }
    void Update()
    {
        //플레이어 이동
        float moveX = Input.GetAxisRaw("Horizontal");

        movement = new Vector2(moveX, 0).normalized;
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= nextFireTime)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

        #region 플레이어 이동 애니메이션 실행
        //플레이어 상하좌우 이동 애니메이션 실행
        if (Input.GetKey(KeyCode.A))                                            //A키를 눌렀을 때 왼쪽으로 이동 애니메이션
        {
            animator.Play("Run Left");
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            animator.Play("Stop Up");
        }
        else if (Input.GetKey(KeyCode.D))                                       //D키를 눌렀을 때 오른쪽으로 이동 애니메이션
        {
            animator.Play("Run Right");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.Play("Stop Up");
        }
        #endregion
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}