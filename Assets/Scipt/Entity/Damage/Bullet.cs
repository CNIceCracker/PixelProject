using UnityEngine;
using System.Collections;

public class Bullet : Damage {
	
	public float speed = 1;
	public float range = 15;
	public Vector2 targetWay;

	void Awake(){
	}

	void Update () {
		range -= speed * Time.deltaTime;
		if(range < 0)
		{
			ObjectPoolMgr.instance.Recycle(this.gameObject);
		}

		transform.Translate(targetWay * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter2D(Collider2D other){ 
		Hurtable target;
		if((target = other.gameObject.GetComponent<Hurtable>()) != null){
			target.BeAttacked(damages);
		}
		ObjectPoolMgr.instance.Recycle(this.gameObject);
	}

}