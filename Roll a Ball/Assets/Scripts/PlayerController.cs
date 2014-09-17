using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject Player;
	bool moveAllow = true;
	bool jumpAllow = true;

	void Start () {
		transform.position = new Vector3(Random.Range (-14.0f, 14.0f), 20.0f, -480.0f);
		rigidbody.mass = 0.01f;
	}
	
	void Update() {
		if (Input.GetKeyDown("space") ) {
			rigidbody.AddForce(new Vector3 (0, 5 * increment, 0));
		}
		}

	public float speed;
	public float handling;
	float increment = 1;

	void FixedUpdate() {
			if (moveAllow == true) {
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				rigidbody.AddForce (movement * speed * increment * Time.deltaTime);
			}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			rigidbody.mass = rigidbody.mass + .01f;
			increment++;
			Debug.Log ("Increment is: " + increment);
		}
		if (other.gameObject.tag == "Boost") {
			rigidbody.velocity = new Vector3(0, 0, 0);
			rigidbody.AddForce (0, 75 * increment / 2, 0);
			moveAllow = false;
		}
		if (other.gameObject.tag == "ResetFloor") {
			transform.position = new Vector3(Random.Range (-14.0f, 14.0f), 20.0f, -480.0f);
		}
	}

	void OnCollisionEnter(Collision collision){

		}
}
