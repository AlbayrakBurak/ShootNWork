using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public LayerMask obstacle,player_layer;
    RaycastHit hit;
    public GameObject death_Effect;
    private bool hit_laser;
    public float range=100f;
        
    void Update()
    {
        //Line Renderer
        if(Physics.Raycast(transform.position, transform.forward, out hit, range, obstacle))
        {   
            GetComponent<LineRenderer>().enabled=true;
            hit_laser=true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);          
            GetComponent<LineRenderer>().startWidth=0.1f + Mathf.Sin(Time.time)/60;  //Sin grafiğine göre ayarlandı 1,-1 arasındaki değeri için time alındı
        }
        else{
            GetComponent<LineRenderer>().enabled=false;
            hit_laser=false;
        }
        //Kill Player
        if(Physics.Raycast(transform.position, transform.forward, out hit, range, player_layer))
        {
            if(hit_laser)
            {
                if(hit.transform.CompareTag("Player")){
                hit.transform.gameObject.GetComponent<PlayerManager>().Death();
                }
            }
        }
    }
}
