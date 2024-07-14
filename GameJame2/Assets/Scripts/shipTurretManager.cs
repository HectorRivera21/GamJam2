using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipTurretManager : MonoBehaviour
{

    public List<turret_barrel> turrets;
    public Transform centerPoint;
    public float minAimAngle = -90f; // Minimum angle for aiming
    public float maxAimAngle = 90f;  // Maximum angle for aiming
    private int currentTurretIndex = 0;
    private float currentAngle = 0f;


    void Start()
    {

        float angleStep = 360f / turrets.Count;  // Angle step between each turret


        foreach (var turret in turrets)
        {
            Debug.Log(turret.transform.position);
            // Calculate position and angle for each turret around centerPoint
            turret.centerPoint = centerPoint;
            turret.initialAngle = NormalizeAngle(currentAngle);
            turret.SetAngle(turret.initialAngle);

            if(turret.transform.position.x > 0){
                Debug.Log(currentAngle);
                currentAngle += angleStep;
                Debug.Log(currentAngle);
            } else {
                Debug.Log(currentAngle);
                currentAngle -= angleStep;
                Debug.Log(currentAngle);
            }
        }

        SelectTurret(currentTurretIndex);  // Select the initial turret
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Press shift to switch between turrets
        {
            currentTurretIndex = (currentTurretIndex + 1) % turrets.Count;
            SelectTurret(currentTurretIndex);
        }

        if(Input.GetMouseButtonDown(0)){
            turrets[currentTurretIndex].Fire();
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePosition);
    }

    void SelectTurret(int index)
    {
        for (int i = 0; i < turrets.Count; i++)
        {
            turrets[i].enabled = (i == index);  // Enable the selected turret
            //turrets[i].SetAngle(turrets[i].angle); //maintain position of selected turret
            
        }
    }

    void Aim(Vector2 targetPosition)
    {   

    turret_barrel currentTurret = turrets[currentTurretIndex];

    // Calculate direction vector towards the target position
    Vector2 direction = targetPosition - (Vector2)currentTurret.centerPoint.position;

    // Calculate the angle in degrees from the direction vector
    float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    // Normalize the angle to ensure it's within -180 to 180 degrees range
    targetAngle = NormalizeAngle(targetAngle);

    // Calculate the difference between target angle and initial angle
    float angleDifference = targetAngle - currentTurret.initialAngle;

    // Clamp the angle difference within the allowed range
    float clampedDifference = Mathf.Clamp(angleDifference, minAimAngle, maxAimAngle);

    // Set the final angle for the turret barrel
    float clampedAngle = currentTurret.initialAngle + clampedDifference;
    currentTurret.SetAngle(clampedAngle);
    }

    float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
