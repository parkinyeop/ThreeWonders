using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
    float jumpForce = 8;
    bool isJump = false;
    public ParticleSystem runEffects;
    public ParticleSystem dieEffects;

    public Action PlayerDie;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runEffects = GetComponent<ParticleSystem>();
        dieEffects.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
            runEffects.Stop();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            runEffects.Play();
        }
        if (collision.gameObject.CompareTag("Block"))
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerDie?.Invoke();
        runEffects.Stop();
        dieEffects.Play();
    }
}
