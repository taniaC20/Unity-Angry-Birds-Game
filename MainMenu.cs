using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public void PlayGame(){
    //    gamePaused=false;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void GoToSettingsMenu(){
    //    gamePaused=false;
       SceneManager.LoadScene("SettingsMenu");
   }
   public void GoToMainMenu(){
       SceneManager.LoadScene("Menu");
       Destroy(GameObject.Find("MenuMusic"));
    //    gamePaused=false;
   }
   
   public void QuitGame(){
    //  gamePaused=false;
     Application.Quit(); 
   }


}
