using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 5;
    public Rigidbody2D rb;
    public GameObject Cam;
    Vector2 movement;


    // Update is called once per frame
    void FixedUpdate(){
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("RoomCol")){
            Cam.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, Cam.transform.position.z);
            
            
            if(gameObject.transform.position.x < other.transform.position.x && Math.Abs(gameObject.transform.position.y - other.transform.position.y)<2){
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.5f , other.transform.position.y ,gameObject.transform.position.z);
            } else if(gameObject.transform.position.x > other.transform.position.x &&  Math.Abs(gameObject.transform.position.y - other.transform.position.y)<2){
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1.5f , other.transform.position.y ,gameObject.transform.position.z);
            } else if(gameObject.transform.position.y < other.transform.position.y){
                gameObject.transform.position = new Vector3(other.transform.position.x, gameObject.transform.position.y + 1.5f ,gameObject.transform.position.z);
            } else if(gameObject.transform.position.y > other.transform.position.y){
                gameObject.transform.position = new Vector3(other.transform.position.x , gameObject.transform.position.y - 1.5f ,gameObject.transform.position.z);
            }
            
        }
        
    }
}
