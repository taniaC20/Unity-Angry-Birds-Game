using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplode : MonoBehaviour
{
   public float fieldOfImpact;
   public float force;
   private bool hitted=false;
   public LayerMask layerToHit;
   private Animator anim;
   public GameObject bombSound;
   private AudioSource bombSource;

//    public GameObject bombSound;

    void Start(){
       anim=GetComponent<Animator>();
       bombSource=bombSound.GetComponent<AudioSource>();
    }

   void Update(){
      
   }

   private IEnumerator KillOnAnimationEnd() {
        anim.SetBool("isDestroyed", true);
        yield return new WaitForSeconds (0.4f);
        Destroy (gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("player") || collision.collider.gameObject.tag == "trampTrigger")
        {
            if(!hitted){
                 bombSource.Play();
                 hitted=true;
            }    
            // bombSource.Play();
            StartCoroutine(explode());
            StartCoroutine (KillOnAnimationEnd ());
            
        }
    }
    IEnumerator explode(){ 
       yield return new WaitForSeconds (0.3f);
       Collider2D[] objects= Physics2D.OverlapCircleAll(transform.position,fieldOfImpact, layerToHit);
       
       foreach(Collider2D obj in objects){
           Vector2 direction = obj.transform.position -transform.position;
           obj.GetComponent<Rigidbody2D>().AddForce(direction*force);

       }
        // Destroy(gameObject);
      
   }

   void OnDrawGizmosSelected(){
       Gizmos.color=Color.red;
       Gizmos.DrawWireSphere(transform.position,fieldOfImpact);
   }
}
