using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject Player;

	void Start () {
		transform.position = new Vector3(Random.Range (-14.0f, 14.0f), 20.0f, -480.0f);
	}
	
	void Update() {
		if (Input.GetKeyDown("space")) {
			rigidbody.AddForce(new Vector3 (0, 1000, 0));
		}
		}

	public float speed;
	public float handling;

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);
		}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "Boost") {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3(moveHorizontal*handling, 0.0f, moveVertical);
			rigidbody.AddForce(movement * speed * Time.deltaTime * 500);
		}
		if (other.gameObject.tag == "ResetFloor") {
			transform.position = new Vector3(Random.Range (-14.0f, 14.0f), 20.0f, -480.0f);
		}
	}

	void OnCollisionEnter(Collision collision){

		}
}
