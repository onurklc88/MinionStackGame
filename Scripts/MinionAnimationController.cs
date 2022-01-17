using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAnimationController : MonoBehaviour
{
    private bool isGrounded;
    public bool isDead;
    private Animator anim;
    public GameObject blocker;
    public bool minionIsTaken = false;


    public static MinionAnimationController minionScript;

    
    void Start()
    {
        minionScript = this;
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {

        bottomMinionCheck();
        animationController();
        StuckBlock();



       


    }

    

    public void bottomMinionCheck()
    {


       

        RaycastHit rayHit;

        if(Physics.Raycast(transform.position, -transform.up, out rayHit, 0.5f))
        {
            //Debug.Log(rayHit.transform.gameObject.name);
         

        }
     
        //minion'dan g�nderdi�im ray ground'a �arp�p �arpmad���n� kontrol ediyorum
         if (rayHit.transform.gameObject.tag == "Ground")
        {
           
            isGrounded = true;

          }
        else
        {
            isGrounded = false;
           
        }
        
        

    }

  

    public void StuckBlock()
    {

        RaycastHit StuckBlocker;
        
        //burdaki ray'de ise oyuncunun z�plamadan stacklemesine engel oluyorum
        if(Physics.Raycast(blocker.transform.position, blocker.transform.forward, out StuckBlocker, 0.5f))
        {

            Debug.Log(StuckBlocker.transform.gameObject.name);
        }

        if (StuckBlocker.transform.gameObject.layer == 6)
        {

            StuckBlocker.transform.gameObject.SetActive(false);

        }

        if(StuckBlocker.transform.gameObject.name == "minion"){

            StuckBlocker.transform.gameObject.SetActive(false);
        }

    }





    
    private void OnTriggerEnter(Collider other)
    {

        //minion obstacle �arparsa animasyon oynat�p �ld�rmek i�in trigger kulland�m
       if(other.gameObject.tag == "Obstacle")
        {

            isDead = true;

        } 

      

    }

    public void animationController()
    {

        //e�er minion zemine dokunuyorsa ve player taraf�ndan stacklendiyse ko�ma animasyonu true d�n�yor
        if (isGrounded == true && minionIsTaken == true)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }



        //�l�m animasyonu
        if (isDead == true)
        {
            anim.SetBool("run", false);
            anim.SetBool("minionDead", true);
            Destroy(gameObject, 0.5f);

        }


    }
   


    private void OnDrawGizmos()
    {
        //ray testi i�in kulland���m gizmo
        Gizmos.color = Color.blue;
        Vector3 direction = transform.TransformDirection(-transform.up) * 0.5f;
        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), direction);
        Gizmos.color = Color.red;
        Vector3 direct = blocker.transform.TransformDirection(Vector3.forward) * 0.5f;
        Gizmos.DrawRay(blocker.transform.position, direct);
    }

}
