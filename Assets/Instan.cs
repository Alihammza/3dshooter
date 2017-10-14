using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instan : MonoBehaviour {

    public GameObject arrowPrefab;

	// Use this for initialization
	void Start () {
        //arrowPrefab = Resources.Load("arrow") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)) {
            var go = Instantiate(arrowPrefab, transform.position, transform.rotation);
        
            Rigidbody rb = go.GetComponent<Rigidbody>();
            //  rb.velocity = Camera.main.transform.forward * 30;
            rb.transform.Translate( new Vector3(8,2,2));
            rb.velocity = new Vector3(2f, 10f, 8f);
        }
	}
}
