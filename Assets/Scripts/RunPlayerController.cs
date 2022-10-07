using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayerController : MonoBehaviour
{
    public float jumpPower = 10f;
    Rigidbody rb;
    bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //�׶��忡 ���� �ؾ� ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector3.up * jumpPower;
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
