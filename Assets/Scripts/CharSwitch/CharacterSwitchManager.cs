using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CharacterSwitchManager : MonoBehaviour
{
    [SerializeField] private List<CharController> charControllers;
    
    private int index;

    private void Start()
    {
        charControllers[0].Enable(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charControllers[index % charControllers.Count].Enable(false);
            index++;
            charControllers[index % charControllers.Count].Enable(true);
        }
    }
}
