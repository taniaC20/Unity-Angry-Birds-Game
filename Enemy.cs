
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] private GameObject _cloudParticlePrefab;
   public GameObject environment;
   private EnvironmentController envScript;
   public GameObject enemySound;
    private AudioSource enemySource;

   void Start()
    {
        envScript = environment.GetComponent<EnvironmentController>();
        enemySource=enemySound.GetComponent<AudioSource>();
    }
  
  void Update(){
      if(
            transform.position.y >= envScript.positiveY || transform.position.y <= envScript.negativeY ||
            transform.position.x >= envScript.positiveX || transform.position.x <= envScript.negativeX
        ){
            explode();
        } 
  }
  private void OnCollisionEnter2D(Collision2D collision){
      if(collision.collider.GetComponent<Bird>() != null){
          enemySource.Play();
          explode();
          return;
      }
      Enemy enemy=collision.collider.GetComponent<Enemy>();
      if(enemy != null){
          return;
      }

      if(collision.contacts[0].normal.y < -0.5 || collision.collider.gameObject.layer == LayerMask.NameToLayer("background")){
          enemySource.Play();
          explode();

      }
  }

  void explode(){
        Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

  }
}
