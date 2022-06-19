using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=100f;

    public float lifeTime=5f;
    public bool enemy_bullet=false;
    public float enemy_bullet_radius=0.5f;
    public LayerMask player_layer;
    public GameObject hit_effect;
  

   private void Update(){
       transform.Translate(Vector3.forward*-1*Time.deltaTime*speed); //mermi gitmesi icin  -1 yonu belirtir (normalde arkaya gidiyordu)

        lifeTime-=Time.deltaTime;
        
        if(lifeTime<=0){
            Destroy(this.gameObject);
        }

        //Enemy bullet
        if(enemy_bullet)
        {
            if(Physics.CheckSphere(transform.position, enemy_bullet_radius, player_layer)){
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }
   }
   
    void OnTriggerEnter(Collider other){
        
        
        
        //hit to enemy
        if(other.CompareTag("Enemy")){
        GameObject drone=other.transform.parent.gameObject;
        drone.GetComponent<Drone>().health-=50f;

        }
        //Hit
        Instantiate(hit_effect,transform.position, transform.rotation);
        Destroy(this.gameObject);
    }


}
