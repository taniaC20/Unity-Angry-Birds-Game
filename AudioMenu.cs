using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
       
        DontDestroyOnLoad(transform.gameObject);
        
        
    }

}
