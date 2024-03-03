
using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTouchHandler : MonoBehaviour
{
    private Vector2 currentPos;
    private Vector2 prevPos;
    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;
    private Vector2 touchPosition;

    private bool MovedGate = false;
    private Animator player_animator;

    private Vector2 direction;
    private int lastSwipeDirection;

    public void Start()
    {
        player_animator = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    public void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    currentPos = touchPosition;
                    Debug.Log("Began Touch");
                    break;

                case TouchPhase.Moved:
                    currentPos = touch.position;
                    Debug.Log("Moved Touch");
                    break;
                case TouchPhase.Stationary:
                    // Character follows the touch.
                    Debug.Log("Stationary Touch");
                    break;

                case TouchPhase.Ended:
                    Debug.Log("Ended Touch");
                    break;
                case TouchPhase.Canceled:
                    // Stop character movement when the touch ends.
                    Debug.Log("Cancel Touch");
                    
                    break;
            }
            if (touch.phase == TouchPhase.Began)
            {
                prevPos = touch.position;
                currentPos = touch.position;
                MovedGate = false;

            }
            if (touch.phase == TouchPhase.Moved)
            {
                currentPos = touch.position;
                checkSwipe();
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                if(lastSwipeDirection ==1)
                {

                }
            }
            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                currentPos = touch.position;
                player_animator.SetInteger("AnimState", 0);
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        direction = currentPos - prevPos;
        if(!MovedGate)
        {
            MovedGate = true;
            if(horizontalValMove() > 0)
            {
                player_animator.SetInteger("AnimState", 1);

                player_animator.SetTrigger("Attack");

                lastSwipeDirection = 1;
            }
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(currentPos.y - prevPos.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(currentPos.x - prevPos.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        Debug.Log("Swipe UP");
    }

    void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");
    }

    void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
    }
}