using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float speed = 20f;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime; // ���� �̵�
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject); // ȭ�� ������ ������ ����

    }
}