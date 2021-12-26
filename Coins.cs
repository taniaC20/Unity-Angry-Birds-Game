using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public EnvironmentController environmentController;
    public GameObject coinSound;
    private AudioSource coinSource;

    void Start(){
      coinSource=coinSound.GetComponent<AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
      if(collision.collider.GetComponent<Bird>() != null){
        GetComponent<Rigidbody2D>().gravityScale=0;
        environmentController.deleteCoin(gameObject);
        coinSource.Play();
        // Destroy(gameObject);
        
          return;
      }
      Coins coin=collision.collider.GetComponent<Coins>();
      if(coin != null){
          return;
      }

      if(collision.collider.gameObject.tag == "trampTrigger" ){
         GetComponent<Rigidbody2D>().mass=1;
         GetComponent<Rigidbody2D>().gravityScale=1;
        //  Destroy(gameObject);
      }
      
    }
    
}
