using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class turret_1 : MonoBehaviour
{
    public turret_barrel tb;
    public float minAimAngle = -45f; // Minimum angle for aiming
    public float maxAimAngle = 45f; // Maximum angle for aiming
    private float initialRotationZ;

    void Start()
    {
        initialRotationZ = transform.localEulerAngles.z;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tb.Fire();
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePosition);
    }

    void Aim(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Convert targetAngle to the range [-180, 180] for proper clamping
        if (targetAngle > 180f) targetAngle -= 360f;
        if (targetAngle < -180f) targetAngle += 360f;

        // Calculate current angle relative to the turret's initial rotation
        float relativeAngle = Mathf.DeltaAngle(initialRotationZ, targetAngle);

        // Clamp the relative angle within the specified range
        float clampedRelativeAngle = Mathf.Clamp(relativeAngle, minAimAngle, maxAimAngle);

        // Apply the clamped angle to the turret
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, initialRotationZ + clampedRelativeAngle));
    }
   
}
