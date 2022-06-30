using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : Player
{

    private CharacterController _controller;
    private Vector3 direction;
    private Animator busAnimator;

    private int desiredLane = 1; //0: left line, 1: middle line, 2 right lane;
    public float laneDistance = 4;// the distance between two lanes;
    
    void Start()
    {
        
        _controller = GetComponent<CharacterController>();
        busAnimator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        busAnimator.SetTrigger("start");
    }


    void Update()
    {
        
        direction.x = forwardSpeed;
        
        //gather the inputps on which lane we should be
        if (SwipeManager.swipeRight)
        {
        
           
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
            else  busAnimator.SetTrigger("turnRight");
        }
        if (SwipeManager.swipeLeft)
        {
            
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
            else busAnimator.SetTrigger("turnLeft");
        }
        SwitchLane();
       
    }



    private void FixedUpdate()
    {
        _controller.Move(direction * Time.fixedDeltaTime);
    }

    public void SwitchLane()
    {
        Vector3 targetPosition = transform.position.x * transform.right + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            
            targetPosition += Vector3.forward * laneDistance;
        }else if (desiredLane == 2)
        {
            targetPosition += Vector3.back * laneDistance;
        }
        
        //Calculate where we should be in the future
        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            _controller.Move(moveDir);
        }
        else
        {
            _controller.Move(diff);
        }

    }


}
