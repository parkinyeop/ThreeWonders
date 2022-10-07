using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
    float jumpForce = 8;
    bool isJump = default;
    float xBound = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        float xPos = transform.position.x;

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
        }

        if (xPos >= xBound)
        {
            xPos = xBound;
        }
        else if (xPos <= -xBound)
        {
            xPos = -xBound;
        }
        else
        {
            transform.Translate(moveX * speed * Vector3.right * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isJump = false;
        }
    }
}
