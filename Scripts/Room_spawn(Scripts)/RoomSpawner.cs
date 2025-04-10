using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;

	public float waitTime = 4f;
	
	

	void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn",0.2f);


	}

  

    void Spawn(){
		if(spawned == false){
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				Invoke("one", 0.05f);
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				Invoke("two", 0.03f);
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				Invoke("three", 0.07f);
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				Invoke("four", 0.09f);
			}
			spawned = true;
		}
	}

	void one()
    {
		rand = Random.Range(0, templates.bottomRooms.Length);
		Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
	}

	void two()
    {
		rand = Random.Range(0, templates.topRooms.Length);
		Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
	}

	void three()
    {
		rand = Random.Range(0, templates.leftRooms.Length);
		Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
	}

	void four()
    {
		rand = Random.Range(0, templates.rightRooms.Length);
		Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} 
			spawned = true;
		}
	}
}
