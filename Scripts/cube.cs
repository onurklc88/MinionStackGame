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

        //parent olan küp alýndýysa minyonun koþma animasyonu devreye girebilmesi için bool'u true yapýyorum
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
