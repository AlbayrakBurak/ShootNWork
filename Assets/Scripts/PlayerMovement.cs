using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    public float speed=1f;

    //Camera controller
    private float xRotation=0f; //mouse acisi icin max
    public float mouseSens=100f;
    

    //Jump gravity
    private Vector3 velocity;
    private float gravity = -10f;
    private bool isGround;
    public float jumpSpeed=50;
    public float jump=10f;

    
    public Transform groundChecker; //ziplama kontrol
    public float groundCheckerRadius;
    public LayerMask obstacleLayer; //checkground kontrol



    private void Awake(){
        controller = GetComponent<CharacterController>();
        
        //cursor mouse imleci gizleme ve esitleme
        Cursor.visible=false; 
        Cursor.lockState=CursorLockMode.Locked;

    }

    private void Update(){

        //check ground
        isGround=Physics.CheckSphere(groundChecker.position,groundCheckerRadius, obstacleLayer);
        
        Vector3 moveInputs = Input.GetAxis("Horizontal")*transform.right + Input.GetAxis("Vertical")*transform.forward;
        Vector3 moveVelocity=moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity); //Alinan vektorun hareketi

        //Camera Controller Mouse Hassasiyeti
        transform.Rotate(0, Input.GetAxis("Mouse X")*Time.deltaTime*mouseSens,0);
        xRotation -=Input.GetAxis("Mouse Y")*Time.deltaTime*mouseSens;
       
        xRotation=Mathf.Clamp(xRotation,-90f,90f);  //y ekseninde tam tur donmemesi icin

        Camera.main.transform.localRotation=Quaternion.Euler(xRotation,0,0);

       
        
       // print(isGround);
        
        
        //Jump / Gravity
        
        if(!isGround){
            velocity.y += gravity*Time.deltaTime ; //asagi duserken hizlanmasi icin
            speed =jumpSpeed;
            
        }
        else {
            //velocity.y=-0.05f; yere sabiti kaldırdık.
            speed=7;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGround ){
            
                                                       //bug fix 
            velocity.y=Mathf.Sqrt(jump * -2f * gravity/**Time.deltaTime*/ ); //ziplama gucu
            print("basarili");
        }
        
        controller.Move(velocity*Time.deltaTime);
       
        //print(velocity);

         
       
    }
}

