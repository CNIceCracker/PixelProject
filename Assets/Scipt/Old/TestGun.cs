/*using UnityEngine;
using System.Collections;

public class TestGun : MonoBehaviour {
	/*public float attackFix;		//攻击补正
	public float attackRate;	//每秒攻击频率
	public float attackRange;	//攻击距离
	public GameObject bullet; 	//发射的子弹
	public float accurate;		//精准性

	private float onceAttactTime;
	private float attactTimer = 0f;
	private bool canAttact;

	void Awake(){
		onceAttactTime = 1/attackRate;
	}

	void FixedUpdate(){
		if(attactTimer <= onceAttactTime){ //计算能否射击
			attactTimer += Time.deltaTime;
		}else if(canAttact == false){
			canAttact = true;
		}
	}

	void Attack(object[] message){

		if(canAttact){
			float attack = (float)message[0] * attackFix;
			Vector3 target = (Vector3)message[1];
			bool isPlayer = (bool)message[2];

			GunController.instance.CreateOneBullet(target,transform,bullet,attack,attackRange,accurate,isPlayer);
			canAttact = false;
			attactTimer = 0f;
		}

	}
}
*/