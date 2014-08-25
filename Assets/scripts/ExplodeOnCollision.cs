using UnityEngine;
using System.Collections;

public class ExplodeOnCollision : MonoBehaviour {

	public GameObject explosion;

	public float triggerVelocity = 10;

	public GameObject pilotSeat;

	public float explosionForce = 70f;

	public GameManager gameManager;

	
	void OnCollisionEnter(Collision collision) {
		if (collision.relativeVelocity.magnitude > triggerVelocity) {
			Instantiate(explosion, collision.contacts[0].point, Quaternion.identity);
			gameObject.SetActive(false);

			pilotSeat.rigidbody.freezeRotation = true;
			pilotSeat.rigidbody.velocity = (pilotSeat.transform.position - transform.position).normalized*explosionForce;
			foreach(SpringJoint sj in pilotSeat.GetComponents<SpringJoint>())
				Destroy(sj);
			if(gameManager != null)
				gameManager.openPopupLost();
		}

	}
}