using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hurtable : MonoBehaviour {

	public float maxHealth;
	public float armor = 0;
	public GameObject damageText;

	[SerializeField]
	private float curHealth;

	void Awake(){
		RecoverHealth();
	}


	public void BeAttacked(List<DamageData> damages,float fix = 1f){
		float realDamage = Calculator.GetDamage(damages,armor);
		realDamage *= fix;
		curHealth -= realDamage;

		if(curHealth < 0) curHealth = 0;
        
        GameObject mObject = Instantiate(damageText, transform.position, Quaternion.identity) as GameObject;
        mObject.GetComponent<DamageText>().value =(int)realDamage;
	}

	public void RecoverHealth(){
		curHealth = maxHealth;
	}

	public float GetHealth(){
		return curHealth;
	}
}
