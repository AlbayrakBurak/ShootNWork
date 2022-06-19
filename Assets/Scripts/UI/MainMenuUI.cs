using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    public void Start(){
        Time.timeScale=1;
    }
    public void Play_Main(){
        SceneManager.LoadScene("MainLevel");
        Time.timeScale=1;
    }

    public void Exit_Main(){
        Application.Quit();
    }
    public void Credit_Scene(){
        SceneManager.LoadScene("CreditScene");
    }
}
