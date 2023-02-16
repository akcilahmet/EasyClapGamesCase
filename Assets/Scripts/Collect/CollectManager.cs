using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collect"))
        {
            CollectiblesType collectiblesType = other.gameObject.GetComponent<CollectiblesType>();
            if (collectiblesType.type == CollectiblesType.CollectType.cube)
            {
               
                Destroy(other.gameObject);

            } 
            if (collectiblesType.type == CollectiblesType.CollectType.sphere)
            {
                ScaleAdd(collectiblesType.scale);
                
                Destroy(other.gameObject);

            }
            if (collectiblesType.type == CollectiblesType.CollectType.cylinder)
            {
                ScaleDecrease(collectiblesType.scale);
                Destroy(other.gameObject);
            }
        }
    }

    void ScaleAdd(float addScale)
    {
        transform.DOScale(transform.localScale + new Vector3(addScale, addScale, addScale), .2f).SetEase(Ease.OutBack);
    }

    void ScaleDecrease(float decreaseScale)
    {
        transform.DOScale(transform.localScale + new Vector3(-decreaseScale, -decreaseScale, -decreaseScale), .2f).SetEase(Ease.OutBack);

    }
    
    
  
}
