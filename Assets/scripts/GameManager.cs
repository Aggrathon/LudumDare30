using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject podracer;
	public Transform spawnPoint;
	private GameObject instPodracer;
	private Rigidbody engine;

	public GameObject popup;
	public Text popupTime;
	public Text popupTries;
	public Text popupTitle;
	public Text uiTimer;
	public Text uiSpeed;

	List<Obstacle> obstacles;
	Phase currentPhase = Phase.phase1;

	float timer = 0f;
	int tries = 0;
	bool playing = false;

	// Use this for initialization
	void Start () {
		obstacles = new List<Obstacle>();
		Obstacle o;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("obstacle"))
			if( (o = go.GetComponent<Obstacle>()) != null)
				obstacles.Add(o);
		spawn();
		closePopup();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Shift"))
			switchPhase();
		if(Input.GetButtonUp("Menu"))
			openMenu();

		if(playing) {
			timer += Time.deltaTime;
			uiTimer.text = timer.ToString("0.0");
		}
		uiSpeed.text = (engine.velocity.magnitude/1.5f).ToString("0.0");
	}

	void switchPhase() {
		if(currentPhase == Phase.phase1)
			changePhase(Phase.phase2);
		else
			changePhase(Phase.phase1);
	}

	void changePhase(Phase p) {
		currentPhase = p;
		foreach (Obstacle o in obstacles) {
			o.changePhase(p);
		}
	}

	public void Finish() {
		openPopupWon();
	}
	
	public void openPopupWon() {
		popup.SetActive(true);
		playing = false;
		Screen.lockCursor = false;
		Screen.showCursor = true;
		popupTime.text = "TIME: "+timer.ToString("0.0")+" SECONDS";
		popupTitle.text = "YOU CROSSED THE FINISH LINE";
		popupTries.text = "TRIES: "+tries+" TIME"+(tries==1?"":"S")+" DESTROYED";
	}
	
	public void openPopupLost() {
		popup.SetActive(true);
		playing = false;
		Screen.lockCursor = false;
		Screen.showCursor = true;
		popupTime.text = "TIME: "+timer.ToString("0.0")+" SECONDS";
		popupTitle.text = "YOUR PODRACER WAS DESTROYED";
		popupTries.text = "TRIES: "+tries+" TIME"+(tries==1?"":"S")+" DESTROYED";
	}

	public void closePopup() {
		popup.SetActive(false);
		playing = true;
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}

	public void retry () {
		timer = 0f;
		tries++;
		closePopup();
		spawn ();
	}

	public void spawn() {
		if(instPodracer != null)
			Destroy(instPodracer);

		instPodracer = (Instantiate(podracer, spawnPoint.position, spawnPoint.rotation) as GameObject);
		foreach (ExplodeOnCollision eoc in instPodracer.GetComponentsInChildren<ExplodeOnCollision>())
			eoc.gameManager = this;
		foreach (GoalTrigger gt in instPodracer.GetComponentsInChildren<GoalTrigger>())
			gt.gm = this;

		engine = instPodracer.GetComponentInChildren<Steering>().gameObject.GetComponent<Rigidbody>();
	}

	public void openMenu() {
		Screen.lockCursor = false;
		Screen.showCursor = true;
		Application.LoadLevel("Menu");
	}
}
