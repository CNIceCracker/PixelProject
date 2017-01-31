using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {
	public enum Sort{
		wood = 0,iron = 1, silicon = 2,chemical = 3
	}

	public float smoothing;
	public float collectDis;
	public Sort sort;

	private Vector3 moveWay;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!PlayerController.instance.isDead){
			moveWay = (PlayerController.instance.player.transform.position - transform.position);
			if(moveWay.magnitude <= collectDis){
				transform.position = Vector3.Lerp(transform.position,PlayerController.instance.player.transform.position 
				                                  + new Vector3(0f,2f,0f),Time.deltaTime * smoothing);
			}
		}

			
		
	}
}
