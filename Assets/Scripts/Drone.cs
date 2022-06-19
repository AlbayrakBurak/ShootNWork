using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;
    private float coolDown=1f;
    
    public float speed =10f;
    public float follow_distance=10f;
    public Vector3 offset;
    public GameObject mesh;
    public GameObject bullet_drone;
    public Vector3 bullet_offset;
    public float health=100f;
    public GameObject death_effect_drone;


    private void Awake() 
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }


    private void FollowPlayer()
    {
        
        //Look to player
        transform.LookAt(player.position);
        transform.rotation*=Quaternion.Euler(offset);

        //Move to player
        if(Vector3.Distance(transform.position, player.position)>=follow_distance)
        {
        transform.Translate(transform.forward*-1*Time.deltaTime*speed);
        }   
        else
        {
        transform.RotateAround(player.position,transform.forward,Time.deltaTime*speed*Random.Range(4f,3f));
        }
    }


    private void Shot()
    {
        if(coolDown>0){
            coolDown-=Time.deltaTime;
        }
        else
        {
            coolDown=1f;
            //Shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bullet_drone, transform.position,transform.rotation * Quaternion.Euler(bullet_offset));
        }
    }

    private void Death(){
        if(health<=0){
            
            //Spawn particle drone
            Instantiate(death_effect_drone,transform.position,Quaternion.identity);
            
            //gameobject
            Destroy(this.gameObject);
        }
    }

}
