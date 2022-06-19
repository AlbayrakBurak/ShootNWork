using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{

  //Animasyonun silah dönmesiyle çakışmaması için
  public GameObject hand;

  public GameObject pistol_hand;
  public LayerMask obstacleLayer;
  RaycastHit hit;
  public Vector3 offset;

  public GameObject bullet;
  public Transform firePoint;


  public bool pistolAktif=true;
  private float coolDown;
  
   public AudioClip gunShot;
  
  private void Update(){


      //CAMERA LOOK
      if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer)){
          hand.transform.LookAt(hit.point);  //bakilan nesnenin kordinatlarini noktasal olarak aldik
          hand.transform.rotation*=Quaternion.Euler(offset);
      }

      
      //Bekleme suresi
      if(coolDown>0){
        coolDown-= Time.deltaTime;
      }
      
      //Shot
      if(Input.GetMouseButtonDown(0) && coolDown<=0){
        
        //Create bullet
        Instantiate(bullet,firePoint.position,transform.rotation*Quaternion.Euler(90,0,0));
        //bekleme süresini reslemesi için
        coolDown=0.25f;

        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot);

        //Animation
        GetComponent<Animator>().SetTrigger("shotTrigger");

        
      }

      if(Input.GetKeyDown(KeyCode.X) && pistolAktif){
        
          pistolFalse();
        
      }
      if(Input.GetKeyDown(KeyCode.C) && !pistolAktif){
        pistolTrue();
      }



  }

  private void pistolFalse(){
    Debug.Log("Kapalı");
    pistol_hand.SetActive(false);
    pistolAktif=false;
  }
  private void pistolTrue(){
    Debug.Log("Açık");
    pistol_hand.SetActive(true);
    pistolAktif=true;
  }
}

