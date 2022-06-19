using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused=false;
    public GameObject pauseMenu_obj;
    public bool isGameOver=false;
    public GameObject player,pistol;
    public AudioSource music;

    public void Update (){
        if(Input.GetKeyDown(KeyCode.Escape)&&!isGameOver){
            if(!isGamePaused){
                PauseGame();
            }
            else{
                ResumeGame();
            }
        }
    }

    private void PauseGame(){
        Time.timeScale=0;

        //Pause music
        music.Pause();

        //Pause Menu
        pauseMenu_obj.SetActive(true);
        
        //SetCursor
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;

        //Disable PlayerMovement
        player.GetComponent<PlayerMovement>().enabled=false;
        pistol.GetComponent<WeaponControl>().enabled=false;
        isGamePaused=true;
    }

    private void ResumeGame(){
        
        Time.timeScale=1;
        music.UnPause();

        pauseMenu_obj.SetActive(false);

        //SetCursor
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.Locked;

        //Enable PlayerMovement
        player.GetComponent<PlayerMovement>().enabled=true;
        pistol.GetComponent<WeaponControl>().enabled=true;


        //Pause Menu
       
        isGamePaused=false;
        
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void OpenMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
