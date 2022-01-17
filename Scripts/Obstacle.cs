using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //
    private Animator anim;
    public GameObject GOScreen;
    private gameOverScreen GOScript;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider obstacle)
    {

        //engellere küp layer'ý deðerse stack sayýsýný azaltýyorum
        if(obstacle.gameObject.layer == 6)
        {
          
            if (ComboStackBar.effectScript.collectedStacks >= 0)
            {
                ComboStackBar.effectScript.wholeStack(-1f);
            }

            

             Destroy(obstacle.gameObject, 0.3f);
       
        }

        

        if (obstacle.gameObject.tag == "Player")
        {

            //eðer oyuncu yeterince stack toplayamazsa son duvarda game over ekraný veriyorum
            GOScreen.SetActive(true);
            obstacle.gameObject.SetActive(false);


        }



       


        }

    



}
