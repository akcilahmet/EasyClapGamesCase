using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetup : MonoBehaviour
{
    [SerializeField] private CharSO charSo;
    [SerializeField] private List<Renderer> renderers;

    private void Awake()
    {
        Setup();
    }

    void Setup()
    {
        foreach (var VARIABLE in renderers)
        {
            VARIABLE.material.color = charSo.characterColor;
        }
    }
}
