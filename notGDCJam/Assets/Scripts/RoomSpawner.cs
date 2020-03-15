using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour{

    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door
    public GameObject Cam;
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn(){
        if(spawned == false){
            switch(openingDirection){
            case 1:
                //Needs a room with a bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                break;
            case 2:
                //Needs a room with a top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                break;
            case 3:
                //Needs a room with a left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                break;
            case 4:
                //Needs a room with a right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                break;
            }
            spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            Destroy(gameObject);
        }
        if(other.CompareTag("RoomCol")){

        }
        
    }



}
