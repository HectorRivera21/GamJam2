using System.Collections;
using System.Collections.Generic;
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
    public float angle;  // Current angle of the barrel
    public float initialAngle;  // Initial angle of the barrel

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
        float radians = (angle + initialAngle) * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
        transform.position = (Vector2)centerPoint.position + offset;
          //transform.eulerAngles = new Vector3(0, 0, angle); // Set Z rotation directly using angle
       transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    public void SetAngle(float newAngle)
    {   
        float clampedAngle = Mathf.Clamp(newAngle, -90f, 90f);
        angle = newAngle;
        UpdatePosition();
        
    }
}
