using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        //where we destroy Hectors incoming mobs
        Destroy(gameObject);
        //where we check if we hit enemy
        //also dmg enemy

    }
}
