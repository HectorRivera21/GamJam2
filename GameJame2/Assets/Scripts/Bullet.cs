using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float screenHalfWidth;
    float screenHalfHeight;

    void Start()
    {
        Renderer bulletRenderer = GetComponent<Renderer>();

        // Get the actual width and height of the bullet sprite
        float halfBulletWidth = bulletRenderer.bounds.size.x / 2f;
        float halfBulletHeight = bulletRenderer.bounds.size.y / 2f;

        screenHalfWidth = (Camera.main.aspect * Camera.main.orthographicSize - halfBulletWidth)*1.5f;
        screenHalfHeight = (Camera.main.orthographicSize - halfBulletHeight)*1.5f;
    }

    void Update()
    {
        if (transform.position.x < -175 || transform.position.x > screenHalfWidth ||
           transform.position.y < -175 || transform.position.y > screenHalfHeight)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("meteor"))
        {
            Destroy(gameObject);
        }
    }
}