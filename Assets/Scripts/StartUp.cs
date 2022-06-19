using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUp : MonoBehaviour
{
    public Slider MouseSensSlider;

   public void Awake(){
    //Set Mouse Sens Prefs 
    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>()
    .mouseSens=PlayerPrefs.GetFloat("MouseSensitivity",100);

    MouseSensSlider.value=PlayerPrefs.GetFloat("MouseSensitivity",100);
   }
}
    