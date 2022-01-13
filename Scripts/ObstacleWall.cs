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
        //skor yazdýrma kýsmýnda oyuncu zýplayamamasý için jump force'u triggerla sýfýrladým.
        if(wall.gameObject.tag == "Player" || wall.gameObject.layer == 6)
        {
            CharacterScript.jumpForce = 0f;
        }
      
    }
}
