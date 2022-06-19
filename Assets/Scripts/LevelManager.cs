using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    //Player level control
    public bool player_enter, player_exit;
   
    //Drone Spawn
    public Transform [] drone_spawners;
    public bool Spawned=false;
    public GameObject drone;
    public GameObject lockDoor;
    


    //Level Spawn
    public GameObject open_level;
    public GameObject destroy_level;
  
    public void Awake(){
        player_enter=false;
        Spawned=false;
    }

    private void Update(){
        
        if(!Spawned)
        {
            if(player_enter)
            {
               
                //Drone Spawn
                for(int i=0; i<drone_spawners.Length; i++)
                {
                    Instantiate(drone,drone_spawners[i].position,Quaternion.identity);
                }   
                    lockDoor.SetActive(true);
                    
                //Level Spawn
                SpawnLevel();
                Spawned=true;
                
            }
          
        }
          //Destroy level
          if(player_exit)
            {
                if(destroy_level!=null){
                DestroyLevel();
                if(lockDoor!=null) {Object.Destroy(lockDoor);}
            }
                
                
            }
    }


    private void SpawnLevel()
    {
        Vector3 pos=new Vector3(transform.position.x,transform.position.y,transform.position.z+175);
        GameObject obj= Instantiate(open_level,pos, Quaternion.identity);
        obj.GetComponent<LevelManager>().destroy_level=this.gameObject;
        
    }
    
    private void DestroyLevel(){
        Destroy(destroy_level);
      
    }

}
