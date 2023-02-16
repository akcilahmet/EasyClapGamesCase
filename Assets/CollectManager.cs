using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TMP_Text scoreTxt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collect"))
        {
            CollectiblesType collectiblesType = other.gameObject.GetComponent<CollectiblesType>();
            if (collectiblesType.type == CollectiblesType.CollectType.cube)
            {
                StartCoroutine(ScoreUpdate(collectiblesType.score));
                
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
               // ScoreUpdate(collectiblesType.score);
               StartCoroutine(ScoreUpdate(collectiblesType.score));
                
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
    
    
    IEnumerator ScoreUpdate(int addScore)
    {
        for (int j = 1; j <= addScore; j++)
        {
            score += 1;
            if (score < 10)
            {
                scoreTxt.text = "0" + score.ToString();
            }
            else
            {
                scoreTxt.text = score.ToString();
            }
            yield return new WaitForSeconds(.05f);
        }
    }
}
