using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboStackBar : MonoBehaviour
{
    
    public float collectedStacks = 0;
    public float PerfectTiming;

    private float maxStack = 15f;
    private float lerpSpeed = 1f;

    public Text collectedStack;
    public Image maxStackBar;

    public static ComboStackBar effectScript;
    private void Awake()
    {
        effectScript = this;
    }
    void Start()
    {
        
    }
    void Update()
    {

        
        collectedStack.text = PerfectTiming + " X" + "Perfect!";
        
        maxStackBarFiller();
        ColorChanger();


    }


    //anl�k toplanan stack verisini burda tutuyorum
    public void wholeStack(float a)
    {
       
        collectedStacks += a;


    }
    

    //oyuncunun perfect timinglerini burda tutuyorum
    public void ComboCount(float a)
    {

        PerfectTiming += a;


    }


    void maxStackBarFiller()
    {
        //stack bar toplana stack ve max stack oran�yla doldurdum
        maxStackBar.fillAmount = Mathf.Lerp(maxStackBar.fillAmount, (collectedStacks / maxStack), lerpSpeed);


    }

    void ColorChanger()
    {
       //Stack bar renk de�i�imi
        Color healthColor = Color.Lerp(Color.red, Color.green, (collectedStacks / maxStack));
        maxStackBar.color = healthColor;
    }



  

}
