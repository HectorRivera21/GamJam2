using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteor : MonoBehaviour
{   
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 10.5f;
    private int scoreValue = 100;
    public int meteor_health = 100;
    private Player ship;
    
    void Start(){
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            ship = playerObject.GetComponent<Player>();
            if (ship == null)
            {
                Debug.LogError("Player object does not have a Player component.");
            }
        }
        else
        {
            Debug.LogError("Player object not found.");
        }
        
    }
    void Update()
    {
        Debug.Log(target.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    void TakeDamage(int damage)
    {
        meteor_health -= damage;
        if(meteor_health <= 0)
        {
            DestroyMeteor();
        }
    }
   
    void DestroyMeteor()
    {
        if(gameObject != null){
          Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != null){
            if (collision.gameObject.tag == "bullet")
            {
                TakeDamage(100);
                GameManager.Instance.AddScore(scoreValue);
            }
            else if (collision.gameObject.tag == "Player")
            {
                DestroyMeteor();
                ship.PlayerTakeDamage(10);
                GameManager.Instance.AddScore(-100);
            }
        }
    }
    
}