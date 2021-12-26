using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;
    float _timeKilled;
    public GameObject inGameOptions;
    public GameObject winMenuUI;
    public GameObject music;
    private GameOverMenu script;
    public EnvironmentController environmentScript;
    private int points;
    private int timesDead;
    public Text txt;
    public Text coinsTxt;
    private bool levelWon;
    

    void Start(){
        script=inGameOptions.GetComponent<GameOverMenu>();
    }

    private void OnEnable(){
        _enemies = FindObjectsOfType<Enemy>();
    }

    public bool getLevelWon(){
        return levelWon;
    }
    public void setLevelWon(bool levelW){
        levelWon=levelW;
    }
    public int getPoints(){
        return points;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies){
            if(enemy != null){
                return;
            }
        } 

        timesDead+=1;
        if(timesDead==1){
            checkEnemiesDead();
        }

        _timeKilled+=Time.deltaTime;
        if(_timeKilled > 1 ){
            levelWon=true;
            Time.timeScale=0f;
            winMenuUI.SetActive(true);
            // music.SetActive(false);
            txt.text=" "+points+" ";
            coinsTxt.text=" "+environmentScript.getCoins()+" ";
        }

        // UnityEditor.EditorApplication.isPlaying = false;
        
    }
    private void checkEnemiesDead(){

        switch (environmentScript.getTries())
        {
            case 0:
                Debug.Log("Case 0");
                points+=60;
                Debug.Log("Points:"+ points);
                break;
            case 1:
                Debug.Log("Case 1");
                points+=50;
                Debug.Log("Points:"+ points);
                break;
            case 2:
                Debug.Log("Case 2");
                points+=40;
                Debug.Log("Points:"+ points);
                break;
            case 3:
                Debug.Log("Case 3");
                points+=30;
                Debug.Log("Points:"+ points);
                break;
            case 4:
                Debug.Log("Case 4");
                points+=20;
                Debug.Log("Points:"+ points);
                break;
            case 5:
                Debug.Log("Case 5");
                points+=10;
                Debug.Log("Points:"+ points);
                break;
            case 6:
                Debug.Log("Case 6");
                points+=5;
                Debug.Log("Points:"+ points);
                break;
            default:
                Debug.Log("Default case");
                points+=0;
                break;
        }

        Debug.Log("You killed all enemies");
        

    }
}
