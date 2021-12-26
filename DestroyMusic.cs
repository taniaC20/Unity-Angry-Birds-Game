using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMusic : MonoBehaviour
{
    
    void Start() {
        string currentSceneName=SceneManager.GetActiveScene().name;
        if(currentSceneName== "Menu"){
            if(GameObject.Find("Music") != null){
                Destroy(GameObject.Find("Music"));
            }
            
        }else{
            if(GameObject.Find("MenuMusic") != null){
                Destroy(GameObject.Find("MenuMusic"));

            }
        }
        // Destroy(GameObject.Find("Music"));
    } 
}
