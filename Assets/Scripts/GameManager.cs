using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    private bool gameIsPaused;
    private readonly String title = "Assets/Scenes/Title.unity";

    [SerializeField] public GameObject pauseMenu;
    
    public Button resumeButton;
    public Button exitButton;
    
    // Start is called before the first frame update
    void Start(){
        gameIsPaused = false;
        HidePause();
        
        
        if (LevelLoader.StartGame==false && SceneManager.GetActiveScene().path!=title){
            DontDestroyOnLoad(this.gameObject);
            LevelLoader.LoadLevel("Assets/Scenes/Title.unity");
        }
        
        if (resumeButton != null){
            resumeButton.onClick.AddListener(
                delegate{
                    gameIsPaused = !gameIsPaused;
                    PauseGame();
                });
        }
        
        if (exitButton != null){
            exitButton.onClick.AddListener(
                delegate{
                    gameIsPaused = !gameIsPaused;
                    PauseGame();
                    LevelLoader.StartGame = false;
                    LevelLoader.LoadLevel(title);
                });
        }
    }

    // Update is called once per frame
    // EVERYTHING IN THE UPDATE WILL RUN REGARDLESS IF THE GAME IS PAUSED OR NOT
    // Please keep this in mind when writing scripts
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame(){
        
        if (gameIsPaused){
            Time.timeScale = 0;
            
            //render Pause Menu
            ShowPause();
        }
        else{
            Time.timeScale = 1;
            //hide Pause Menu
            HidePause();
        }


    }

    public void HidePause(){
        pauseMenu.SetActive(false);
    }

    public void ShowPause(){
        pauseMenu.SetActive(true);
    }

}
