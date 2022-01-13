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

        //e�er oyuncu jumpPoint noktas�nda Input girerse 
        if (Input.GetMouseButtonDown(0) && PerfectJump == true)
        {
            //combo de�eri yazd�r�yorum
            ComboStackBar.effectScript.ComboCount(1f);

            //bar y�kselmesi i�in anl�k stack de�eri yazd�r�yorum
            ComboStackBar.effectScript.wholeStack(currentStack);

            //Efekt ekran�n� Coroutine kullanarak g�steriyorum
            StartCoroutine(EffectActive());

           
        }


    }
    



    private void OnTriggerEnter(Collider jumpPoint)
    {
        //karakter jumpPoint objesindeyken PerfectJump boolu true oluyor
        PerfectJump = true;


        if ((jumpPoint.gameObject.tag == "Player" && PerfectJump == true) || (jumpPoint.gameObject.layer == 6 && PerfectJump == true))
        {
          
             //enum kullanarak inspector'dan se�ti�im stacklere g�re currentStack de�eri belirliyorum
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
        //jump point noktas�n� �sklan�nca bool false d�n�yor
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




