using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sussyAnim : MonoBehaviour
{
    public GameObject Lterminal;
    public GameObject Rterminal;
    public float speed = 10f;
    int currIndex;
    private Vector2 targetPosition;
    private bool isMoving;
    private bool flipZ;
    
    void Start()
    {
        //anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            setTerminalPosition();
        }
        if(isMoving){
            moveToTerminal();
        }
    }
    
    void setTerminalPosition()
    {
        if (currIndex == 0)
        {
            targetPosition = Lterminal.transform.position;
            currIndex++;
        }
        else
        {
            targetPosition = Rterminal.transform.position;
            currIndex--;
        }
        isMoving = true;
    }

    void moveToTerminal()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if ((Vector2)transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 newPosition = transform.position;
        newPosition.y -= 0.35f;
        transform.position =newPosition;
        Debug.Log("Collision with stairs detected. Moving down.");
    }
}
