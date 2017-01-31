using UnityEngine;
using System.Collections;

public class MapEdge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other){
		Destroy(other.gameObject);
	}
}
