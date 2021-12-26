using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentController : MonoBehaviour
{
    public float negativeX = -30;
    public float positiveX = 30;
    public float negativeY = -30;
    public float positiveY = 30;
    public float timeLimit = 3f;
    public Sprite backgroundImage;
    public GameObject backgroundGameObject; 
    public GameObject gameOverMenuUI;

    private Transform birdTransform;
    private Vector3 birdPosition;

    public GameObject levelControler;
    private LevelControler levelScript;

    public GameObject inGameOptions;
    private GameOverMenu script;
    private GameObject bird;
    private Bird birdScript;

    public List<GameObject> birdsArray;
    public List<GameObject> birdsPrefabs;
    public List<Transform> positions;
    public Transform birdContainer;
    public GameOverMenu gameOverScript;
    public LevelControler levelControllerScript;
    float _timeAfterDead;
    private bool birdD=false;

    private int tries;
    private int coins;

    public void deleteBird(GameObject bird){
        tries+=1;
        Debug.Log("DELETING BIRD: "+ bird);
        birdsArray.Remove(bird);
        Destroy(bird);
        birdsArray[0].GetComponent<Bird>().initializeBird(positions[0].position, gameOverScript, levelControllerScript, this, true);
        bird = birdsArray[0];
        birdTransform = bird.GetComponent<Transform>();
        birdScript = bird.GetComponent<Bird>();
        bird.GetComponent<PolygonCollider2D>().enabled = true;
        bird.GetComponent<LineRenderer>().enabled = true;

        
        Debug.Log("CREATING BIRD: "+ bird);
        Debug.Log("TRIES:"+ tries);
    }
    public void deleteCoin(GameObject coin){
        Destroy(coin);
        coins++;

    }
    public int getCoins(){
        return coins;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < birdsPrefabs.Count; i++){

            GameObject newBird = Instantiate(birdsPrefabs[i]) as GameObject;
            birdsArray.Add(newBird);
            newBird.transform.position = positions[i].position;
            newBird.transform.SetParent(birdContainer);
            if( i != 0){
                newBird.GetComponent<Bird>().isEnabled = false;
                newBird.GetComponent<PolygonCollider2D>().enabled = false;
                newBird.GetComponent<LineRenderer>().enabled = false;

            }else{
                newBird.GetComponent<Bird>().initializeBird(positions[0].position, gameOverScript, levelControllerScript, this, true);
                bird = newBird;
                birdTransform = bird.GetComponent<Transform>();
                birdScript = bird.GetComponent<Bird>();
                
            }
        }
        backgroundGameObject.GetComponent<SpriteRenderer>().sprite = backgroundImage; 
        levelScript=levelControler.GetComponent<LevelControler>();
        script=inGameOptions.GetComponent<GameOverMenu>();
        Debug.Log("TRIES:"+ tries);

    }

    // Update is called once per frame
    void Update()
    {
        if(birdsArray.Count == 0){
             Debug.Log("All Birds are Dead");
            _timeAfterDead+=Time.deltaTime;

            if(_timeAfterDead > 3){

                Time.timeScale=0f;
                gameOverScript.setGameIsOver(true);
                gameOverMenuUI.SetActive(true);
            }

        } 
        if(levelScript.getLevelWon()!=true && script.getGameIsOver()==true){
            Time.timeScale=0f;
            gameOverMenuUI.SetActive(true);
        }

        birdTransform = birdsArray[0].transform;

        if(birdTransform != null){
            birdPosition = birdTransform.position;
            if(
                birdPosition.y > positiveY || birdPosition.y < negativeY ||
                birdPosition.x > positiveX || birdPosition.x < negativeX 
            ){
                deleteBird(birdsArray[0]);
            } 
        }
    }
      public bool getBirdDead(){
        return birdD;

    }

    public int getTries(){
        return tries;
    }

}
