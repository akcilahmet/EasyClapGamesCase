using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
   [SerializeField] private TMP_Text playerOneTxt;
   [SerializeField] private TMP_Text playerTwoTxt;
   public static CanvasController Instance { get; private set; }
   private void Awake()
   {
      Instance = this;
       
   }
   
   public void PlayerOneTextUpdate(int score,int addScore)
   {
      StartCoroutine(ScoreUpdate(score,addScore,playerOneTxt));
   } 
   public void PlayerTwoTextUpdate(int score,int addScore)
   {
      StartCoroutine(ScoreUpdate(score,addScore,playerTwoTxt));
   }
   
   IEnumerator ScoreUpdate(int score,int addScore,TMP_Text scoreTxt)
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
