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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runEffects = GetComponent<ParticleSystem>();
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
        Debug.Log(isJump);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            runEffects.Play();
        }
    }

    void Die()
    {

    }
}
