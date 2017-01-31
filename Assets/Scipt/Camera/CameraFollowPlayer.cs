using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
	public float smoothing;
	public Transform target;

	Vector3 move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!PlayerController.instance.isDead){
			move = target.position;
			move.y += 5f;
			move.z = transform.position.z;
			transform.position = Vector3.Lerp(transform.position, move , Time.deltaTime * smoothing);
		}
	}
}
