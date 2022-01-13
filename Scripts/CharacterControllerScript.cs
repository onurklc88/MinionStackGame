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

     
        //rigidbody kullanarak karaktere sabit yönde hýz verdim
        rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, rb.velocity.z);

        //karakter koþarken jump animasyon boolu false verdim
        animator.SetBool("isJumping", false);


          //eðer input alýndýysa ve canJump boolu true ise rb ile karakteri zýplatýyorum
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

        //karakterin kendi yükseliðinden büyük objeleri zýplamadan almasýný istemediðimden karakterin merkezinden ray yolladým
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), transform.forward, out hit, 0.8f))
        {

            //ilk önce en üstteki kutumu onu denetletiyorum
            if (hit.transform.gameObject.tag == "TopPoint")
            {
                Destroy(hit.transform.gameObject);
            }

            //eðer ray'in çarptýðý obje en üstteki kutu deðilse en üstüyle beraber destroyluyorum
            if (hit.transform.gameObject.layer == 6)
            {
                Destroy(hit.transform.parent.gameObject);
               
            }
            
            
           


         }    
    }





    public void OnTriggerEnter(Collider cube)
    {
        //Eðer oyuncu top point taglý objeye dokunursa bu toplayabileceði max yükseklik olacak deðilse sadece alttaki objeler ile yükselecek
        if (cube.gameObject.CompareTag("TopPoint"))
        {

           //Transform ve objenin bizle gelebilmesi için child yaptýðým atamalar
            cube.gameObject.transform.position = new Vector3(transform.position.x, cube.gameObject.transform.position.y, -10);
            cube.gameObject.transform.parent = parents;
           
            //ardýndan karakterin yükseklik atamalarý
            transform.position = new Vector3(transform.position.x, transform.position.y + cube.gameObject.transform.position.y, -10);
            
            //trigger olarak kullandýðým top pointi sýradan bir child haline dönüþtürdüm
            cube.gameObject.tag = "Untagged";
            cube.gameObject.GetComponent<BoxCollider>().isTrigger = false;


        }

        

    }

    private IEnumerator Canjump()
    {
        //oyuncu sürekli zýplamamasý için belli bir süre parametresi kullandým
        canJump = false;
        yield return new WaitForSeconds(2f);
        canJump = true;


    }



    private void OnDrawGizmos()
    {
        //ray testi için kullandýðým gizmo
        Gizmos.color = Color.blue;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 0.7f;
        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), direction);
    }


}
