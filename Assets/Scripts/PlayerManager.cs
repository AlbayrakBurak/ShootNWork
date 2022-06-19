using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    private bool player_Alive=true;
    public GameObject death_Effect;
    public GameObject hand;
    public GameObject crosshair;
    public GameObject gameOverMenuUI;
    public PauseMenu pause_menu;

    public void Death()
    {
        if(player_Alive)
        {
            player_Alive=false;

            //Disable Pause Menu
            pause_menu.isGameOver=true;


            //Effect
            Instantiate(death_Effect, transform.position, Quaternion.identity);

            //Oyuncu kontrollerini kapat
            GetComponent<PlayerMovement>().enabled=false;
            hand.SetActive(false);
            crosshair.SetActive(false);

            //Cursor aktif
            Cursor.visible=true;
            Cursor.lockState=CursorLockMode.None;

            //Game Over
            gameOverMenuUI.SetActive(true);

        }    
    }

    public void Start(){
        hand.SetActive(false);
    }
}
