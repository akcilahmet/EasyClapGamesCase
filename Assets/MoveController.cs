using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("Move")] 
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float moveSpeed;
    
    [Header("Rot")] [Space(5)]
    public float turnSmoothTime = .1f;
    private float turnSmoothVelocity=5;
    
    [Header("Joystick")] [Space(5)] 
    [SerializeField] private DynamicJoystick joystick;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Rotation(Direction());
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region Rotation

    void Rotation(Vector3 direction)
    {
        if (DirectionMagnitude() >= .1f)
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
        if (DirectionMagnitude() >= .1f)
        {

            rb.velocity = Direction() * MoveSmoothSpeed()*Time.deltaTime;

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
    

}