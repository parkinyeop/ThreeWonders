using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float moveSpeed = 1f;
    float xMin = -10f;
    public float accelator = 0.1f;

    private void Start()
    {
        RunPlayerController player = FindObjectOfType<RunPlayerController>();
        player.PlayerDie += Die;
        
    }
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        moveSpeed = moveSpeed + accelator * Time.deltaTime;

        if (transform.position.x < xMin)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player Hp Down");
        }
    }
    
    public void Die()
    {
        moveSpeed = 0;
        accelator = 0;
    }
}
