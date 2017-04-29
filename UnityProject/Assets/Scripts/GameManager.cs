using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    JitMessenger jitMessenger;
    Player player;

    public GameObject calibrateBtn;
    public GameObject startBtn;
    public GameObject scoreTextObject;
    public GameObject restart;
    public GameObject greatJob;

    Text scoreText;

    int score = 0;

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
        player = Player.instance;
        jitMessenger = player.jitMessenger;
        scoreText = scoreTextObject.GetComponent<Text>();
        scoreTextObject.SetActive(false);
        greatJob.SetActive(false);
        restart.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Calibrate() {
        jitMessenger.Calibrate();
        jitMessenger.Instrument(1);
    }

    public void StartGame() {
        print("start");
        jitMessenger.StartPlaying();
        calibrateBtn.SetActive(false);
        startBtn.SetActive(false);
        scoreTextObject.SetActive(true);
        restart.SetActive(true);
    }

    public void IncrementScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void EndGame() {
        greatJob.SetActive(true);
        player.StopRunning();
    }

    public void PlayAgain() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        jitMessenger.Restart();
    }
}
