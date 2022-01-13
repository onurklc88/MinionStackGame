using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    public GameObject Character;
    private CharacterControllerScript CharacterScript;


    private void Start()
    {

        CharacterScript = Character.GetComponent<CharacterControllerScript>();
    }


    private void OnTriggerEnter(Collider wall)
    {
        //skor yazd�rma k�sm�nda oyuncu z�playamamas� i�in jump force'u triggerla s�f�rlad�m.
        if(wall.gameObject.tag == "Player" || wall.gameObject.layer == 6)
        {
            CharacterScript.jumpForce = 0f;
        }
      
    }
}
