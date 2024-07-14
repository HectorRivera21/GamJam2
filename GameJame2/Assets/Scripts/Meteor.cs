using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 8.5f;
    private int scoreValue = 100;
    public int meteor_health = 100;

    void TakeDamage(int damage)
    {
        meteor_health -= damage;
        if(meteor_health <= 0)
        {
            DestroyMeteor();
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    void DestroyMeteor()
    {
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DestroyMeteor();
    }
}