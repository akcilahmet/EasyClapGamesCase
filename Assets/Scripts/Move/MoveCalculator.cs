using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveCalculator 
{
    
    public static Vector3 DirectionCalculate(DynamicJoystick joystick)
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
       
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        return direction;
        
        
    } 
    public static float DirectionMagnitude(DynamicJoystick joystick)
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
       
        float direction = new Vector3(horizontal, 0, vertical).magnitude;
        return direction;
        
    }
    public static float ConvertToFloat(float outMin,float outMax,
        float inputMin, float inputMax, float power)
    {
        float diffOutRange = Mathf.Abs(outMin - outMax);
        float diffInputRange = Mathf.Abs(inputMin - inputMax);
        float factor = diffOutRange / diffInputRange;

        return  0 + (factor * (power - inputMin));
    }
    

}
