using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {


	public GameObject solidObstacle;
	public GameObject wireframe;
	public Phase phase = Phase.phase1;

	void Start() {
		changePhase(Phase.phase1);
	}

	public void changePhase(Phase newPhase) {
		if(newPhase == phase) {
			solidObstacle.SetActive(true);
			wireframe.SetActive(false);
		} else {
			solidObstacle.SetActive(false);
			wireframe.SetActive(true);
		}
	}
}
public enum Phase { phase1, phase2 }
