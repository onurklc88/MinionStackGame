using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterControllerScript : MonoBehaviour
{

    
    public float speed = 3f;
    public float jumpForce = 10.0f;
    public bool canJump;
   
    public Rigidbody rb;
    private Animator animator;
    public Transform parents;


    void Start()
    {
        animator = GetComponent<Animator>();
        canJump = true;
    }


    void Update()
    {
        playerMovement();
        StuckFix();
    }

   

    public void playerMovement()
    {

     
        //rigidbody kullanarak karaktere sabit y�nde h�z verdim
        rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, rb.velocity.z);

        //karakter ko�arken jump animasyon boolu false verdim
        animator.SetBool("isJumping", false);


          //e�er input al�nd�ysa ve canJump boolu true ise rb ile karakteri z�plat�yorum
        if (Input.GetMouseButtonDown(0) && canJump == true)
        {
            animator.SetBool("isJumping", true);
            rb.velocity = Vector3.up * jumpForce;
            StartCoroutine(Canjump());


        }




    }






    public void StuckFix()
    {

        RaycastHit hit;

        //karakterin kendi y�kseli�inden b�y�k objeleri z�plamadan almas�n� istemedi�imden karakterin merkezinden ray yollad�m
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), transform.forward, out hit, 0.8f))
        {

            //ilk �nce en �stteki kutumu onu denetletiyorum
            if (hit.transform.gameObject.tag == "TopPoint")
            {
                Destroy(hit.transform.gameObject);
            }

            //e�er ray'in �arpt��� obje en �stteki kutu de�ilse en �st�yle beraber destroyluyorum
            if (hit.transform.gameObject.layer == 6)
            {
                Destroy(hit.transform.parent.gameObject);
               
            }
            
            
           


         }    
    }





    public void OnTriggerEnter(Collider cube)
    {
        //E�er oyuncu top point tagl� objeye dokunursa bu toplayabilece�i max y�kseklik olacak de�ilse sadece alttaki objeler ile y�kselecek
        if (cube.gameObject.CompareTag("TopPoint"))
        {

           //Transform ve objenin bizle gelebilmesi i�in child yapt���m atamalar
            cube.gameObject.transform.position = new Vector3(transform.position.x, cube.gameObject.transform.position.y, -10);
            cube.gameObject.transform.parent = parents;
           
            //ard�ndan karakterin y�kseklik atamalar�
            transform.position = new Vector3(transform.position.x, transform.position.y + cube.gameObject.transform.position.y, -10);
            
            //trigger olarak kulland���m top pointi s�radan bir child haline d�n��t�rd�m
            cube.gameObject.tag = "Untagged";
            cube.gameObject.GetComponent<BoxCollider>().isTrigger = false;


        }

        

    }

    private IEnumerator Canjump()
    {
        //oyuncu s�rekli z�plamamas� i�in belli bir s�re parametresi kulland�m
        canJump = false;
        yield return new WaitForSeconds(2f);
        canJump = true;


    }



    private void OnDrawGizmos()
    {
        //ray testi i�in kulland���m gizmo
        Gizmos.color = Color.blue;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 0.7f;
        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), direction);
    }


}
