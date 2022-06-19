using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform checker;
    public LayerMask player_layer;
    public float radius;

    public Vector3 velocity;

    private bool broke=false;

    private void Update(){
        
        if(Physics.CheckBox(checker.position, new Vector3(radius,2,radius), Quaternion.identity, player_layer)){
            broke=true;
            //print("basarili");
        }
        
        
        if(broke){  //Kirildiysa asagi dusmesi velocity=hiz
            velocity.z-=Time.deltaTime/200;
            transform.Translate(velocity);
        }
    }
}
