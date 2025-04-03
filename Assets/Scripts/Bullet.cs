using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float speed = 20f;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime; // 위로 이동
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject); // 화면 밖으로 나가면 삭제

    }
}