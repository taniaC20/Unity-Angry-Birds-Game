using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
   public GameObject pauseMenuUI;
   public static bool gamePaused=false;
   public GameObject music;

    
   void Update()
    {
       
          if(gamePaused){
            Pause();
          }else{
            Resume();
          }
        
    }

    public void setPaused(){
        gamePaused=true;

    }
    public void setResume(){
        gamePaused=false;

    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
    }
    public void GoToMainMenu(){
       Time.timeScale=1f;
       SceneManager.LoadScene("Menu");
       gamePaused=false;
   }
    public void Retry(){
        gamePaused=false;
        Time.timeScale=1f;
        string currentSceneName=SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

        if(music !=null){
          music.SetActive(false);
        }
        
   }
   public void Next(){
        gamePaused=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
    public void QuitGame(){
      Application.Quit(); 
    }
}
