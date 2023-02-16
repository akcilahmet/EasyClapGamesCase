using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private bool isEnable=false;
    [Header("Move")] 
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float moveSpeed;
    
    [Header("Rot")] [Space(5)]
    public float turnSmoothTime = .1f;
    private float turnSmoothVelocity=5;
    
    [Header("Joystick")] [Space(5)] 
    [SerializeField] private DynamicJoystick joystick;
    
    [Header("Camera")] [Space(5)] 
    [SerializeField] private CinemachineVirtualCamera cmCam;
    
    private Rigidbody rb;

    private void Start()
    {
        if(rb==null) 
            rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isEnable) return;
        Rotation(Direction());
    }

    private void FixedUpdate()
    {
        if (!isEnable) return;
        Move();
    }

    #region Rotation

    void Rotation(Vector3 direction)
    {
        if (DirectionMagnitude() >= .01f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation=Quaternion.Euler(0f,angle,0f);
        }
    }

    #endregion
    
    #region Move

    void Move()
    {
        if (DirectionMagnitude() >= .2f)
        {
            Vector3 temp = new Vector3(Direction().x * MoveSmoothSpeed() * Time.deltaTime, rb.velocity.y,
                Direction().z * MoveSmoothSpeed() * Time.deltaTime);
            rb.velocity =temp;

        }
        if (DirectionMagnitude() < .1f)
        {
            ResetVelocity();
        }

    }

    #endregion
    
    #region Calculator

    float DirectionMagnitude()
    {
        return MoveCalculator.DirectionMagnitude(joystick);
    }

    Vector3 Direction()
    {
        return MoveCalculator.DirectionCalculate(joystick);
    }

    #endregion

    #region Reset

    void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
    }

    #endregion

    #region SmoothSpeed

    float MoveSmoothSpeed()
    {
        moveSpeed = MoveCalculator.ConvertToFloat(0, maxMoveSpeed, 0, 1, DirectionMagnitude());
        
        
        moveSpeed = Mathf.Clamp(moveSpeed, minMoveSpeed, maxMoveSpeed);
        return moveSpeed;
    }


    #endregion

    public void Enable(bool temp)
    {
        isEnable = temp;
        if (!isEnable)
        {
            ResetVelocity();
            cmCam.Priority = 0;
        }
        else
        {
            cmCam.Priority = 1;
        }
           
    }

}
