/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour {
	//public float health;		//生命值
	//public float attack;		//攻击力
	
	/*public float visualField; 	//攻击范围



	private float distance;

	//private Animator anim;


	private object[] message = new object[3];


	void Awake () {
		//anim = GetComponent<Animator>();
	}


	void FixedUpdate () {
		distance = (PlayerController.instance.player.transform.position - transform.position).magnitude;

		if(distance <= attackRange){ //若可以射击并且与Player距离小于攻击距离
			AttackNow();
		}


	}

	void AttackNow(){
		message[0] = attack;
		message[1] = PlayerController.instance.playerTargetPoint.position;
		message[2] = false;
		gameObject.BroadcastMessage("Attack",message);
		//anim.SetBool("IsAttack",true);
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "Bullet"){
			Bullet bullet = other.GetComponent<Bullet>();
			if(bullet.isPlayerShoot){
				health -= bullet.attack;
				Destroy(other.gameObject);
				if(health <= 0f){
					GetComponentInChildren<LootProduce>().isProduce = true;
					GetComponent<ShowHP>().DistoryHPS();
					Destroy(gameObject,2f);
					GetComponent<Collider2D>().enabled = false;
					GetComponent<Rigidbody2D>().gravityScale = 0;
					GetComponent<EnemyMove>().enabled = false;
					this.enabled = false;
				}
			}
		}
	}
}
*/