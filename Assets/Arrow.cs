using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody rb;
    Quaternion rot = Quaternion.Euler(-90f,0f,0f);
	float ttl = 10.0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		
    }

    // Update is called once per frame
    void Update()
	{
		
		transform.rotation = Quaternion.LookRotation (rb.velocity) * rot;
		ttl -= Time.deltaTime;
		if (ttl <= 0) {
			foreach (Transform child in this.transform) {
				flock otherScript = child.gameObject.GetComponent<flock>();
				otherScript.reset();
			}

			Destroy(this.gameObject);

		}
	}
}