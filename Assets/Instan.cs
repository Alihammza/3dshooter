	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instan : MonoBehaviour {
	public float maxTime;
	public float minSwipeDist;
	float startTime;
	float endTime;
	float swipeDist;
	float swipeTime;
	Vector3 startPos, endPos;


    	public GameObject arrowPrefab;

	// Use this for initialization
	void Start () {
        }
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 || true) {
//			Touch touch = Input.GetTouch(0); // get the touch

//			if (touch.phase == TouchPhase.Began) {
			if(Input.GetMouseButtonDown(0)){
				
				startTime = Time.time;
//				startPos = touch.position;
				startPos = Input.mousePosition;  
//			} else if (touch.phase == TouchPhase.Ended) {
			} else if (Input.GetMouseButtonUp(0)) {
				
				endTime = Time.time;
//				endPos = touch.position;
				endPos = Input.mousePosition;
				Vector3 deltaPos = endPos - startPos;
				if (deltaPos.y < -10) {
					var go = Instantiate(arrowPrefab, transform.position+new Vector3(0f,0f,0.0f), transform.rotation);
					Rigidbody rb = go.GetComponent<Rigidbody>();
					float pitch = (startPos.y-Screen.height/2)/(Screen.height/2.0f) * (3.1415f/2f);
					float yaw = Mathf.Atan2 (deltaPos.y, deltaPos.x);
					float power = deltaPos.magnitude / 20;

					if (pitch < 0)
						pitch = 0.0f;

					if (power < 10f)
						power = 10f;

					if (power > 40f)
						power = 40f;

					//rb.velocity = Camera.main.transform.forward * 30;
					//rb.transform.Translate( new Vector3(8,2,2));
					//rb.velocity = new Vector3(2f, 5f, 10f);
					deltaPos.Normalize();
					rb.velocity = new Vector3(-deltaPos.x, Mathf.Sin(pitch), -deltaPos.y );
					rb.velocity.Normalize ();
					rb.velocity *= power;
					Debug.Log (rb.velocity);
				}
			}

	        }
	}
}
