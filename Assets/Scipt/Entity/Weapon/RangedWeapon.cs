using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangedWeapon : Weapon {

	public GameObject bullet; 	//发射的子弹
	public float accurate;		//精准性
	public int magazineSize;	//弹夹容量
	public float reloadTime;

	private float curBullet;
	private float onceAttactTime;
	private float attactTimer = 0f;
	private bool canAttact;
	private List<Transform> firePoint = new List<Transform>();
	private int fireIndex;
	
	void Awake(){
		onceAttactTime = 1/attackRate;
		fireIndex = 0;
		Transform[] children = transform.GetComponentsInChildren<Transform>();
		foreach(Transform child in children){
			if(child.tag == "FirePoint"){
				firePoint.Add(child);
			}
		}
		curBullet = magazineSize;
	}
	
	void FixedUpdate(){
		if(attactTimer >= 0){ //计算能否射击
			attactTimer -= Time.deltaTime;
		}else if(canAttact == false){
			canAttact = true;
		}
	}

	
	override public void Attack(object[] message){
		if(canAttact){
			float attack = (float)message[0] * attackFix;
			Vector3 target = (Vector3)message[1];
			bool isPlayer = (bool)message[2];

			GunController.instance.CreateOneBullet(firePoint[fireIndex],bullet,attack,attackRange,accurate,target,isPlayer);
			canAttact = false;
			if(--curBullet == 0){
				attactTimer = reloadTime;
			}else{
				attactTimer = onceAttactTime;
			}

			if(++fireIndex > firePoint.Count-1){
				fireIndex = 0;
			}
		}
	}
}
