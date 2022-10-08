using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Vector3 startPosition;
    float repeatWidth;
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x * 0.5f;
    }
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
