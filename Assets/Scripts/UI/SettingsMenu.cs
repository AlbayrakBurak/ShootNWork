using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMix;
    private bool isFullScreen=true; 

    public void SetResoulation(int index){
        if(index==0){
            Screen.SetResolution(1920,1080,isFullScreen);
        }else if(index==1){
            Screen.SetResolution(1280,1024,isFullScreen);
        }else if(index==2){
            Screen.SetResolution(1024,768,isFullScreen);
        }else if(index==3){
            Screen.SetResolution(800,600,isFullScreen);
        }
    }


    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex); //index numarasina gore kalite ayarlandi
    } 

    public void SetFullScreen(bool fullScreen){
        Screen.fullScreen=fullScreen;
        isFullScreen=fullScreen;
    }
    
    public void SetMouseSensitivity(float value){
        PlayerPrefs.SetFloat("MouseSensitivity",value);

        if(GameObject.FindGameObjectWithTag("Player") !=null){
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSens=value;
        }
    }

    public void SetMasterVolume(float value){
        audioMix.SetFloat("MasterVolume",value);
    }
   
    public void SetMusicVolume(float value){
        audioMix.SetFloat("MusicVolume",value);
    }
}
