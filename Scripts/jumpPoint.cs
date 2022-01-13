using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpPoint : MonoBehaviour
{
    public enum stacks { DOUBLE_STACK, TRIPLE_STACK, QUAD_STACK }
    
    public float currentStack;
    public stacks whichStack;
    public bool PerfectJump;

    public GameObject maxStackImage;
  
   private void Start()
    {
    
    }

    private void Update()
    {
       
        PerfectTiming();

    }

  
    public void PerfectTiming()
    {

        //eðer oyuncu jumpPoint noktasýnda Input girerse 
        if (Input.GetMouseButtonDown(0) && PerfectJump == true)
        {
            //combo deðeri yazdýrýyorum
            ComboStackBar.effectScript.ComboCount(1f);

            //bar yükselmesi için anlýk stack deðeri yazdýrýyorum
            ComboStackBar.effectScript.wholeStack(currentStack);

            //Efekt ekranýný Coroutine kullanarak gösteriyorum
            StartCoroutine(EffectActive());

           
        }


    }
    



    private void OnTriggerEnter(Collider jumpPoint)
    {
        //karakter jumpPoint objesindeyken PerfectJump boolu true oluyor
        PerfectJump = true;


        if ((jumpPoint.gameObject.tag == "Player" && PerfectJump == true) || (jumpPoint.gameObject.layer == 6 && PerfectJump == true))
        {
          
             //enum kullanarak inspector'dan seçtiðim stacklere göre currentStack deðeri belirliyorum
            if (whichStack == stacks.DOUBLE_STACK)
            {
                
                currentStack = 2f;
             
            }
            if (whichStack == stacks.TRIPLE_STACK)
            {
               
                currentStack = 3f;

            }

            if (whichStack == stacks.QUAD_STACK)
            {
                currentStack = 4f;
               
            }
        }
        else
        {
            PerfectJump = false;
        }
       
    }

      

      
    
    private void OnTriggerExit(Collider other)
    {
        //jump point noktasýný ýsklanýnca bool false dönüyor
       PerfectJump = false;

     }


   private IEnumerator EffectActive()
    {

        maxStackImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<jumpPoint>().enabled = false;
        maxStackImage.SetActive(false);


    }
}




