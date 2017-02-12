using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
	public float smoothing;
	public Transform target;

	Vector3 moveTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!PlayerController.instance.isDead){
			moveTarget = target.position;
			moveTarget.y += 4f;
			moveTarget.z = transform.position.z;
			if(PlayerController.instance.player.transform.localScale.x > 0){
				moveTarget.x += 8f;
			}else{
				moveTarget.x -= 8f;
			}

			transform.position = Vector3.Lerp(transform.position, moveTarget , Time.deltaTime * smoothing);
		}
	}
}
