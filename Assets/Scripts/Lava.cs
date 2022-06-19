using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    // Tagi player olana carptiginda olum fonksiyonunu calistir
    private void OnTriggerEnter(Collider other) {
        //if player fall to lava
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerManager>().Death();
        }
    }
}
