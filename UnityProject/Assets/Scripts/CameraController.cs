using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    Vector3 lastPlayerPosition;
    float distanceToMove;

	// Use this for initialization
	void Start () {
        lastPlayerPosition = player.position;
	}
	
	// Update is called once per frame
	void Update () {
        distanceToMove = player.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = player.position;
	}
}
