using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetup : CharacterType
{
    [SerializeField] private PlayerType type;
    [SerializeField] private CharSO charSo;
    [SerializeField] private List<Renderer> renderers;

    private void Awake()
    {
        Setup();
    }

    private void Start()
    {
        if (type == PlayerType.playerOne)
        {
            CanvasController.Instance.PlayerOneTextSetup(charSo.score);
        } 
        if (type == PlayerType.playerTwo)
        {
            CanvasController.Instance.PlayerTwoTextSetup(charSo.score);

        }
    }

    void Setup()
    {
       
        foreach (var VARIABLE in renderers)
        {
            VARIABLE.material.color = charSo.characterColor;
        }
    }

    public CharSO GetCharSO()
    {
        return charSo;
    }
}
