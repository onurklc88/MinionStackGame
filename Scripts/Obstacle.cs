using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  //
    public GameObject GOScreen;
    private gameOverScreen GOScript;

    void Start()
    {
      
    }

   
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider obstacle)
    {

        //engellere k�p layer'� de�erse stack say�s�n� azalt�yorum
        if(obstacle.gameObject.layer == 6)
        {
          
            if (ComboStackBar.effectScript.collectedStacks >= 0)
            {
                ComboStackBar.effectScript.wholeStack(-1f);
            }
            
            Destroy(obstacle.gameObject);
       
        }
        
           
        

        if (obstacle.gameObject.tag == "Player")
        {

            //e�er oyuncu yeterince stack toplayamazsa son duvarda game over ekran� veriyorum
            GOScreen.SetActive(true);
            obstacle.gameObject.SetActive(false);


        }

    }

    



}
