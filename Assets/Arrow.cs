using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody rb;
    Quaternion rot = Quaternion.Euler(-90f,0f,0f);

	public float maxTime;
	public float minSwipeDist;
	float startTime;
	float endTime;
	Vector3 startPos, endPos;
	float swipeDist;
	float swipeTime;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
	{
		transform.rotation = Quaternion.LookRotation (rb.velocity) * rot;
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				startTime = Time.time;
				startPos = touch.position;
			} 
			else if (touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;
				swipeDist = (endPos - startPos).magnitude;
				swipeTime = endTime - startTime;

				if (swipeTime < maxTime && swipeDist > minSwipeDist) {
					swipe ();
				}

			}
		}
				
	}

	void swipe(){
		Vector2 distance = endPos - startPos;
		if(Mathf.Abs(distance.x)>Mathf.Abs(distance.y)){
			Debug.Log ("Horizontal Swipe");
			if(distance.x>0){
				Debug.Log ("Right Swipe");
			}
			if(distance.x<0){
				Debug.Log ("Left Swipe");
			}
		}
		else if(Mathf.Abs(distance.x)>Mathf.Abs(distance.y)){
			Debug.Log ("Vertical Swipe");
			if(distance.y>0){
				Debug.Log ("Up Swipe");
			}
			if(distance.y<0){
				Debug.Log ("Down Swipe");
			}
		}

	}
}