using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float attackFix;		//攻击补正
	public float attackRate;	//每秒攻击频率
	public float attackRange;	//攻击距离

	/*		float attack = (float)message[0] * attackFix;
			Vector3 target = (Vector3)message[1];
			bool isPlayer = (bool)message[2];*/
	virtual public void Attack(object[] message){}

}
