using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float screenHalfWidth;
    float screenHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        float halfBulletWidth = transform.localScale.x / 2f;
        float halfBulletHeight = transform.localScale.y / 2f;

        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - halfBulletWidth;
        screenHalfHeight = Camera.main.orthographicSize - halfBulletHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenHalfWidth || transform.position.x > screenHalfWidth)
        {
            Destroy(gameObject);
        }
        
        if (transform.position.y < -screenHalfHeight || transform.position.y > screenHalfHeight)
        {
            Destroy(gameObject);
        }
         
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteor")
        {
            Destroy(gameObject);
            
        }
    }
}

