using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteor : MonoBehaviour
{   
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 8.5f;
    public int meteor_health = 100;
<<<<<<< Updated upstream

    
    void Start()
=======
    private Player ship;
    void TakeDamage(int damage)
>>>>>>> Stashed changes
    {
        //do nothin
    }
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
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
<<<<<<< Updated upstream
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
=======
    void DestroyMeteor()
    {
        if(gameObject != null){
        Debug.Log("destroy meteoer");
        Destroy(gameObject);
        //GameManager.Instance.AddScore(scoreValue);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != null){
            Debug.Log(collision);
            if (collision.gameObject.tag == "bullet")
            {
                Debug.Log("bullet");
                TakeDamage(100);
            }
            else if (collision.gameObject.tag == "Player")
            {
                DestroyMeteor();
                ship.PlayerTakeDamage(10);
                Debug.Log("player");
                
            }
        }
>>>>>>> Stashed changes
    }
}