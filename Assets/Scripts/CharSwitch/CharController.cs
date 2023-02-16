using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
   [SerializeField] private MoveController moveController;
   
   public void Enable(bool temp)
   {
      moveController.Enable(temp);
   }
}
