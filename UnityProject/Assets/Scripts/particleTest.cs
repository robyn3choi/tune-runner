using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleTest : MonoBehaviour {

    public ParticleSystem particles;

	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            var col = particles.colorOverLifetime;
            col.color = Color.red;
        }
        if (Input.GetKey(KeyCode.A)) {
            var col = particles.colorOverLifetime;
            col.color = Color.blue;
        }
	}
}
