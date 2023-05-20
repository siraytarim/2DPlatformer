using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{

    public GameObject inGameScreen,pauseScreen,winnerScreen,FinalPoint;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);  
        pauseScreen.SetActive(true);   
    }
    public void RePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
         
    }
    public void PlayButton()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);

    }   
    public void MuteButton()
    {
        AudioListener.volume = 0;
    }

}
