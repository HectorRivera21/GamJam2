using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class turret_barrel : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public Transform centerPoint;  // Central point around which the barrel rotates
    public float radius = 10f;  // Radius of the circle
    //turns the barrel not where its at on the circle
    public float angle;  // Current angle of the barrel
    public float initialAngle;  // Initial angle of the barrel,
    public float minAimAngle; // Minimum angle for aiming
    public float maxAimAngle;  // Maximum angle for aiming 

    void Start()
    {
        
        UpdatePosition();
    }


    

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void UpdatePosition()
    {   
        // does the math to make sure the turret turns around the circle
        float radians = (angle + initialAngle) * Mathf.Deg2Rad;
        // calculates the offset from center point
        Vector2 offset = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
        // updates the position of turret so firepoint is correctly places
        transform.position = (Vector2)centerPoint.position + offset;
        //determines how the TURRET is rotated
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void SetAngle(float newAngle)
    {   
        angle = newAngle;
        UpdatePosition();
        
    }
}
