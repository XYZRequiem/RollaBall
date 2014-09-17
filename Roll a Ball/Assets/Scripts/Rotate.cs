using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(Random.Range (-14.0f, 14.0f), 2f, Random.Range (-470.0f, 400.0f));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
