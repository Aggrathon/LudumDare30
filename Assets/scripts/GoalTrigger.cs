using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour {

	public GameManager gm;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Finish")
			gm.Finish();
	}
}
