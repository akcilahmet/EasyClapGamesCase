using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
                Debug.Log("cube");
                ScoreUpdate(5);
            } 
            if (collectiblesType.type == CollectiblesType.CollectType.sphere)
            {
                Debug.Log("sphere");
                ScaleAdd(collectiblesType.scale);
            }
            if (collectiblesType.type == CollectiblesType.CollectType.cylinder)
            {
                Debug.Log("cylinder");
                ScaleDecrease(collectiblesType.scale);
                ScoreUpdate(5);
            }
        }
    }

    void ScaleAdd(float addScale)
    {
        transform.DOScale(transform.localScale + new Vector3(addScale, addScale, addScale), .3f);
    }

    void ScaleDecrease(float decreaseScale)
    {
        transform.DOScale(transform.localScale + new Vector3(-decreaseScale, -decreaseScale, -decreaseScale), .3f);

    }

    void ScoreUpdate(int addScore)
    {
        
    }
}
