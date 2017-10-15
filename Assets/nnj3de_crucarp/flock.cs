using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

public class flock : MonoBehaviour {

    public float speed = 5f;
	public bool hit = false;
	public bool justHit = true;
	GameObject daddy;
	// Use this for initialization
	void Start () {
        //speed = Random.Range(0.5f, 1);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!hit)
			transform.Translate(0, 0, Time.deltaTime * speed);
		
		if (justHit) {

			justHit = false;

		}
	}

	public void reset(){
		hit = false;
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.GetComponent<Rigidbody>()) {
			daddy = col.gameObject;
			var cc = GetComponent<CapsuleCollider> ();
			cc.enabled = false;
			this.transform.parent = daddy.transform;
			hit = true;
		}
	}

}
