using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float moveSpeed = 1f;
    

    private void Awake()
    {
       
    }
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hp Down");
        }
    }
}
