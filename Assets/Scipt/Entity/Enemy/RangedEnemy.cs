using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangedEnemy : Enemy {

	private Transform playerTrans;
	private float distance;
	private Animator anim;
	private Rigidbody2D rg;
	private bool isDead = false;

	void Awake(){
		weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
		weapons[0].gameObject.SetActive(true);
		anim = GetComponent<Animator>();
		rg = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		rg.WakeUp();
		if(playerTrans == null) playerTrans =  PlayerController.instance.player.transform;

		Command command = Think();
		if(command != null){
			command.Execute(gameObject);
		}

		if(health <= 0 && isDead == false){
			isDead = true;
			StartCoroutine(DieNow());
		}
	}

	override protected Command Think(){
		if(!isDead){
			distance = (playerTrans.position - transform.position).magnitude;
			
			if(distance <= visualField  ){ 		//若与Player距离小于视野距离,则将目标改为Player，并准备攻击
				target = playerTrans.position;
				
				if(distance <= attackRange){
					anim.SetBool("IsAim",true);
					anim.SetBool("IsMove",false);
					if((transform.position.x - target.x) > 0) { //分辨左右
						transform.localScale = new Vector3(-1,1,1);
					}
					else{
						transform.localScale = new Vector3(1,1,1);
					} 
					object[] message = new object[2];
					message[0] = playerTrans.position;
					message[1] = false;
					return new AttackCommand(message);
				}
			}else{
				distance = (target - transform.position).magnitude;
			}
			
			if(distance > 1f){
				anim.SetBool("IsMove",true);
				anim.SetBool("IsAim",false);
				if((transform.position.x - target.x) > 0) { //分辨左右
					transform.localScale = new Vector3(-1,1,1);
					return new MoveToLeftCommand();
				}
				else{
					transform.localScale = new Vector3(1,1,1);
					return new MoveToRightCommand();
				} 
			}else{
				anim.SetBool("IsMove",false);
				return null;
			}

		}else{
			return null;
		}

	}


}
