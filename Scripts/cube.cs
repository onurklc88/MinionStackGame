using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
   
    public static cube cubeScript;
   
    void Start()
    {
        cubeScript = this;
    }

    
    void Update()
    {

        //parent olan k�p al�nd�ysa minyonun ko�ma animasyonu devreye girebilmesi i�in bool'u true yap�yorum
        if (transform.parent != null)
        {
              foreach (Transform eachChild in transform)
            {
                if (eachChild.name == "minion")
                {
                    eachChild.transform.gameObject.GetComponent<MinionAnimationController>().minionIsTaken = true;


                }
            }
        }
    }
}
