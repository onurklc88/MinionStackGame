using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameOverScreen : MonoBehaviour
{
    public float TotalScore;
    public Text score;
    

    
    void Start()
    {
        
    }

    
    void Update()
    {
        score.text = TotalScore + "" ;
    }


    public void RestartButton()
    {
        
        SceneManager.LoadScene("Level1");

    }


    public void TotalPoints(float a)
    {
        //final state ald���m�z verileri total score'a yazd�rd�m
        TotalScore += a;


    }


}
