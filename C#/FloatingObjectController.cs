using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectController : MonoBehaviour {

	//public float horizontalSpeed;
	public float verticalSpeed;
	public float amplitude;
	private Vector3 tempPosition;
	private float creationTime;

	// Use this for initialization
	void Start () {
		//Vector3 height = new Vector3(0f, 0f, 0f);
		//height.y = Random.Range(0.1f, 1.0f);
		creationTime = Time.realtimeSinceStartup;
		tempPosition = transform.position;
		tempPosition.y += Random.Range(0.1f, 1.0f);
		transform.position = tempPosition;
	}
	
	// Update is called once per frame
	void Update () {
		var currentTime = Time.realtimeSinceStartup - creationTime;

		tempPosition.y += Mathf.Sin(currentTime * verticalSpeed) * amplitude;
		transform.position = tempPosition;
	}
}
