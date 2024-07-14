using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 8.5f;
    public int meteor_health = 100;

    
    void Start()
    {
        //do nothing
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}