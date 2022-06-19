using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cREDİT : MonoBehaviour
{

  public void Start(){
     Time.timeScale=1;
  }

   public void credit_MainMenu(){
        SceneManager.LoadScene("MainMenu");
  }
}
