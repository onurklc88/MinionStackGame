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
        //final state aldýðýmýz verileri total score'a yazdýrdým
        TotalScore += a;


    }


}
