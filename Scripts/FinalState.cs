using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalState : MonoBehaviour
{

    public GameObject GOScreen;
    private gameOverScreen GOScript;

    
    void Start()
    {
        GOScreen.SetActive(false);
        GOScript = GOScreen.GetComponent<gameOverScreen>();
    }

   
    void Update()
    {
        
    }

  
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            //skor yazd�r�rken cube layer� trigger� tetiklerse total pointe eklettim.
            GOScript.TotalPoints(1f);
             Destroy(other.gameObject);

        }

        if(other.gameObject.tag == "Player")
            {
            
            //e�er karakter trigger� tetiklerse bu son skor ekleyecek obje olarak belirdim
            GOScript.TotalPoints(1f);

            //game over ekran�na burda a�t�rd�m
            GOScreen.SetActive(true);
            other.gameObject.SetActive(false);


        }


    }
}
