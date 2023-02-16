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
        Rotation(DirectionCalculate());
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

            rb.velocity = DirectionCalculate() * MoveSmoothSpeed()*Time.deltaTime;

        }
        if (DirectionCalculate().magnitude < .1f)
        {
            ResetVelocity();
        }

    }

    #endregion
    

    
    
    
    void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
    }
    
    float MoveSmoothSpeed()
    {
        moveSpeed = Calculate.ConvertToFloat(0, maxMoveSpeed, 0, 1, DirectionMagnitude());
        
        
        moveSpeed = Mathf.Clamp(moveSpeed, minMoveSpeed, maxMoveSpeed);
        return moveSpeed;
    }

    
    public Vector3 DirectionCalculate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
       
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        return direction;
        
        
    } 
    public float DirectionMagnitude()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
       
        float direction = new Vector3(horizontal, 0, vertical).magnitude;
        return direction;
        
    }

}
