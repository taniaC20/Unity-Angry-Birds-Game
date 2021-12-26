using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    private bool gameIsOver;
    public float timeLimit = 1f;

    public GameObject levelControler;
    private LevelControler levelScript;
  
    public EnvironmentController environmentScript;
    private GameObject bird;
    private Bird birdScript;

     void Start()
    {
        bird=environmentScript.birdsArray[0];
        levelScript=levelControler.GetComponent<LevelControler>();
        birdScript = bird.GetComponent<Bird>();
    }
    void Update()
    {

    }
    
   public void Retry(){
        string currentSceneName=SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        gameIsOver=false;
   }
   public void GoToMainMenu(){
       SceneManager.LoadScene("Menu");
       gameIsOver=false;

   }

   public bool getGameIsOver(){
       return gameIsOver;
   }
   public void setGameIsOver(bool gameOver){
       gameIsOver=gameOver;

   }



}
