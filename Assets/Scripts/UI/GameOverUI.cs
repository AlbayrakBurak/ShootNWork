using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
   public void Restart_Button(){
       SceneManager.LoadScene("MainLevel");
   }

    public void MainMenu_Button(){
        SceneManager.LoadScene("MainMenu");
    }

   public void Exit_Button(){
       Application.Quit();
   }

   
}
