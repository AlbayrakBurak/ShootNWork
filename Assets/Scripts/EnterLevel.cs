using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager lm;
    public bool enter;
    //public GameObject lockDoor;
    //public float zaman =15f;
    public bool hand;
    public GameObject pistol;
    public void OnTriggerEnter(Collider other){

     
        if(enter){
        lm.player_enter=true;
       
       /* lockDoor.SetActive(true);
        zaman-=Time.deltaTime;
        if(zaman<=0){
            Destroy(lockDoor);
            zaman=0;
        }*/

        }
        else {
            lm.player_exit=true;
            if(!hand){
                hand=true;
                pistol.SetActive(true);

            }
        }
    }
}
