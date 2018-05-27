using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.HelloAR;

public class AnchorManager : MonoBehaviour {

	public GameObject anchoredPrefab;
	//public GameObject unanchoredPrefab;
	//Vector3 lastAnchorPosition;
	//Quaternion lastAnchorRotation;
	Anchor anchor;
	
	// Update is called once per frame
	void Update () {
		
		Touch touch;	
		touch = Input.GetTouch(0);

		if (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Began) {
			TrackableHit hit;
			TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon | 
				TrackableHitFlags.FeaturePointWithSurfaceNormal;
			
			if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit)) {
				//Random height from plane
				//Vector3 height = new Vector3(0f, 0f, 0f);
				//height.y = Random.Range(0.1f, 1.0f);

				anchor = hit.Trackable.CreateAnchor(hit.Pose);
				var anchoredObject = Instantiate(anchoredPrefab, hit.Pose.position, hit.Pose.rotation, anchor.transform);
				
				//Random color generator
				//anchoredObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
				
				//make the  object look at camera
				/*if ((hit.Flags & TrackableHitFlags.PlaneWithinPolygon) != TrackableHitFlags.None) {
					//get camera position
					Vector3 cameraPosition = Frame.Pose.position;
					cameraPosition.y = hit.Pose.position.y;

					//have the object to look at the camera respecting its "up" perspective
					anchoredObject.transform.LookAt(cameraPosition, anchoredObject.transform.up);
				}*/
			}
		}

		if (anchor == null)
			return;
	}
}
