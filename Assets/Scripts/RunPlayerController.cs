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
    
    GameObject playerChecker;

    public Action PlayerDie;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runEffects = GetComponent<ParticleSystem>();
        playerChecker = transform.GetChild(0).gameObject;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerDie?.Invoke();
        runEffects.Stop();
       
    }
}
