using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour {

    public Note note;
    Player player;
    GameManager gameManager;
    GameObject camera;

	// Use this for initialization
	void Start () {
        player = Player.instance;
        gameManager = GameManager.instance;
//        gameObject.SetActive(false);
//        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
//        float distanceFromCamera = transform.position.x - camera.transform.position.x;
//        if (distanceFromCamera < 18f) {
//            if (!gameObject.activeInHierarchy) {
//                gameObject.SetActive(true);
//            }
//        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (player.noteState == note) {
                OrbPickup();
            }
            else {
                WrongNote();
            }
        }
    }

    void OrbPickup() {
//        player.jitMessenger.OrbPickup();
        gameObject.SetActive(false);
        gameManager.IncrementScore();
//        print("orb");
    }

    void WrongNote() {
        //print("wrongnote");
    }
}
