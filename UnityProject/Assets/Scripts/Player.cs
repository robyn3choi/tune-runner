using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Note { G, A, Bf, B, C, Cs, D, E, F };

public class Player : MonoBehaviour {

    public Note noteState;
    public float jumpForce = 10f;
    public float moveSpeed = 3f;
    public LayerMask ground;
    public JitMessenger jitMessenger;

    Rigidbody2D rigidBody;
    bool isGrounded;
    bool isStarted; 
    int instrumentNumber = 1;

    public static Player instance = null;

    public GameObject glow;
    ParticleSystem.MainModule particleSystem;

    void Awake() {
        if (instance == null) {
            instance = this;
        }    
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        jitMessenger = GetComponent<JitMessenger>();
        particleSystem = glow.GetComponent<ParticleSystem>().main;
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.IsTouchingLayers(GetComponent<Collider2D>(), ground);

        if (isStarted)
            rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }

        if (Input.GetKey(KeyCode.A)) {
            rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.O)) {
//            difference = transform.position.x - initial;
//            initial = transform.position.x;
//            print(difference);
//            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//            cube.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            print (transform.position.x);
            GameObject orb = (GameObject)Instantiate(Resources.Load("OrbG"));
            orb.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        }
	}

    public void applyNote(string midiString) {
        int midiInt = int.Parse(midiString);
        int baseNote = midiInt % 12;

        switch (baseNote) {
            case 0:
                noteState = Note.C;
                particleSystem.startColor = new Color(0, 1f, 0, 1f);
                break;
            case 1:
                noteState = Note.Cs;
                particleSystem.startColor = new Color(0, 0, 1f, 1f);
                break;
            case 2:
                noteState = Note.D;
                particleSystem.startColor = new Color(0, 1f, 1f, 1f);
                break;
            case 4:
                noteState = Note.E;
                particleSystem.startColor = new Color(0.5f, 0, 1f, 1f);
                break;
            case 5:
                noteState = Note.F;
                particleSystem.startColor = new Color(1f, 0, 1f, 1f);
                break;
            case 7:
                noteState = Note.G;
                particleSystem.startColor = new Color(1f, 0, 0, 1f);
                break;
            case 9:
                noteState = Note.A;
                particleSystem.startColor = new Color(1, 1, 1, 1f);
                break;
            case 10:
                noteState = Note.Bf;
                particleSystem.startColor = new Color(1f, 1f, 0, 1f);
                break;
            case 11:
                noteState = Note.B;
                particleSystem.startColor = new Color(1f, 0.5f, 0, 1f);
                break;
            
//            case 9:
//                Jump();
//                break;
//            case 11:
//                Slide();
//                break;
        }
    }

    public void Jump() {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    public void Slide() {
        
    }

    public void StartRunning() {
        isStarted = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("InstrumentChange")) {
            print("instrunentcage");
            instrumentNumber++;
            jitMessenger.Instrument(instrumentNumber);
        }
    }

    public void StopRunning() {
        isStarted = false;
    }
}
