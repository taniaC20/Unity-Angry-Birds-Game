
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    bool _birdWasLaunched;
    float _timeSittingAround;
    [SerializeField] float _launchPower = 500;
    [SerializeField] private GameObject _cloudParticlePrefab;
    public GameObject inGameOptions;
    private GameOverMenu script;
    public GameObject levelControler;
    private LevelControler levelScript;
    private EnvironmentController environmentController;
    public bool isEnabled = false;
    private bool launched=false;
    

    void Start(){
    
    }
    
    public float getTimeSitingAround(){
        return _timeSittingAround;
    }
    public void initializeBird(Vector3 _position, GameOverMenu _gameOverScript, LevelControler _levelControllerScript,EnvironmentController _environmentController, bool _isEnabled ){
        transform.position = _position;
        _initialPosition=_position;
        script=_gameOverScript;
        levelScript=_levelControllerScript;
        environmentController=_environmentController;
        isEnabled = _isEnabled;
        
    }
    private void Awake(){
        if(isEnabled == false) return;
        // GetComponent<PolygonCollider2D>().enabled=false;
    }
    private void Update(){
        if(isEnabled == false) return;
  

        GetComponent<LineRenderer>().SetPosition(1,_initialPosition);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude<=0.1){
            _timeSittingAround+=Time.deltaTime;

        }
        if(_timeSittingAround > 2){
             environmentController.deleteBird(gameObject);
             Destroy(gameObject);
        }
        
    }
    private void OnMouseDown(){
        if(launched == true) return;
        if(isEnabled == false) return;
        GetComponent<SpriteRenderer>().color=Color.red;
        GetComponent<LineRenderer>().enabled=true;
        GetComponent<PolygonCollider2D>().enabled=false;
        launched=false;
    }

     private void OnMouseUp(){
         if(launched == true) return;
         if(isEnabled == false ) return;
        GetComponent<SpriteRenderer>().color=Color.white;
        Vector2 directionToInitialPosition=_initialPosition-transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition*_launchPower);
        GetComponent<Rigidbody2D>().gravityScale=1;
        _birdWasLaunched=true;
        GetComponent<LineRenderer>().enabled=false;
        GetComponent<PolygonCollider2D>().enabled=true;
        launched=true;

    }

    private void OnMouseDrag(){
        if(launched == true) return;
        if(isEnabled == false) return;
        Vector3 newPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position=new Vector3(newPosition.x,newPosition.y);
        GetComponent<PolygonCollider2D>().enabled=false;
        launched=false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(isEnabled == false) return;

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("trap"))
        {
             Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
             environmentController.deleteBird(gameObject);
             Destroy(gameObject);
             
             return;
          

        }

    }
    
    

} 
