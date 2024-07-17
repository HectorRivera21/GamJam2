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
    //Animation anim;
    // ^ and other animation comments require the animation component but it looks weird idk so i just used this janky way
    void Start()
    {
        //anim = GetComponent<Animation>();
        setTerminalPosition();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            setTerminalPosition();
        }
        if(isMoving){
            //anim.Play();
            moveToTerminal();
        } //else{
        //     anim.Stop();
        // }
    }    
    //gets the position of whatever terminal is next and flips trhe sprite
    void setTerminalPosition()
    {
        Quaternion newRotation = transform.rotation;
        
        if (currIndex == 0)
        {
            targetPosition = Lterminal.transform.position;
            currIndex++;
            newRotation.y = 180;
        }
        else
        {
            targetPosition = Rterminal.transform.position;
            currIndex--;
            newRotation.y = 0;
        }
        isMoving = true;
        transform.rotation = newRotation;
    }
    //move to the terminals
    void moveToTerminal()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if ((Vector2)transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
    //go up the stairs
    void OnTriggerEnter2D(Collider2D collision)
     {
        Vector2 newPosition = transform.position;
        newPosition.y += 0.5f;
        transform.position =newPosition;
     }
}
