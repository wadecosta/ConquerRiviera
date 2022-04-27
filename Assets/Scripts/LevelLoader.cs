using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static bool StartGame;
    private readonly String title = "Assets/Scenes/Title.unity";
    private readonly String startLevel ="Assets/Scenes/Game.unity";
    public Button button = null; 
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().path!=title){
            StartGame = true;
        }
        else{
            StartGame = false;
        }
        
        if (!StartGame && SceneManager.GetActiveScene().path!=title){
            LoadLevel(title);
        }
        
        
        //start button
        if (button != null){
            button.onClick.AddListener(
                delegate{
                    StartGame = true;
                    LoadLevel(startLevel);
                });
        }
    }

    // Update is called once per frame
    // EVERYTHING IN THE UPDATE WILL RUN REGARDLESS IF THE GAME IS PAUSED OR NOT
    // Please keep this in mind when writing scripts
    void Update()
    {
        
    }
    
    public static void LoadLevel(string level){
        SceneManager.LoadScene(level);
    }
}
