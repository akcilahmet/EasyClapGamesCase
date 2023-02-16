using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
   [SerializeField] private TMP_Text playerOneTxt;
   [SerializeField] private TMP_Text playerTwoTxt;
   private int playerOneScore;
   private int playerTwoScore;
   
   public static CanvasController Instance { get; private set; }
   private void Awake()
   {
      Instance = this;
       
   }

   #region GameStartTextUpdate

   public void PlayerOneTextSetup(int score)
   {
      ScoreSetup(score,playerOneTxt);
   }
   public void PlayerTwoTextSetup(int score)
   {
      ScoreSetup(score,playerTwoTxt);
   }

   void ScoreSetup(int score,TMP_Text scoreText)
   {
      if (score < 10)
      {
         scoreText.text = "0" + score.ToString();
      }
      else
      {
         scoreText.text = score.ToString();
      }
   }

   #endregion

   #region ScoreRealTimeUpdate
   public void PlayerOneTextUpdate(int score,int addScore)
   {
      StartCoroutine( ScoreUpdate(score, addScore, playerOneTxt));
   } 
   public void PlayerTwoTextUpdate(int score,int addScore)
   {
      StartCoroutine( ScoreUpdate(score, addScore, playerTwoTxt));

   }
   
   IEnumerator ScoreUpdate(int score,int addScore,TMP_Text scoreTxt)
   {
      for (int i = 1; i <= addScore; i++)
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
   

   #endregion
  
  
}
