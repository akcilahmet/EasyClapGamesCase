using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CollectManager : CharacterType
{
    [SerializeField] private PlayerType type;
    [SerializeField] private CharacterSetup characterSetup;
  
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collect"))
        {
            CollectiblesType collectiblesType = other.gameObject.GetComponent<CollectiblesType>();
            if (collectiblesType.type == CollectiblesType.CollectType.cube)
            {
                ScoreUpdate(collectiblesType.score);
                
               
                Destroy(other.gameObject);

            } 
            if (collectiblesType.type == CollectiblesType.CollectType.sphere)
            {
                ScaleAdd(collectiblesType.scale);
                
                Destroy(other.gameObject);

            }
            if (collectiblesType.type == CollectiblesType.CollectType.cylinder)
            {
               
                ScoreUpdate(collectiblesType.score);
              
                
                ScaleDecrease(collectiblesType.scale);
                Destroy(other.gameObject);
            }
        }
    }

    void ScaleAdd(float addScale)
    {
        transform.DOScale(transform.localScale + new Vector3(addScale, addScale, addScale), .15f).SetEase(Ease.OutBack);
    }

    void ScaleDecrease(float decreaseScale)
    {
        transform.DOScale(transform.localScale + new Vector3(-decreaseScale, -decreaseScale, -decreaseScale), .15f).SetEase(Ease.OutBack);

    }

    void ScoreUpdate(int addScore)
    {
        CanvasScoreUpdate(addScore);
        characterSetup.GetCharSO().score += addScore;
      
    } 
    void CanvasScoreUpdate(int addScore)
    {
        if (type == PlayerType.playerOne)
        {
            CanvasController.Instance.PlayerOneTextUpdate( characterSetup.GetCharSO().score,addScore);
            
        }

        if (type == PlayerType.playerTwo)
        {
            CanvasController.Instance.PlayerTwoTextUpdate( characterSetup.GetCharSO().score,addScore);
            
        }
    }
    
  
}
