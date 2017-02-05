using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hurtable : MonoBehaviour {

	public float health;
	public float armor = 0;
	public GameObject damageText;


	public void BeAttacked(List<DamageData> damages){
		float damageReduction = armor/(300f+armor);
		float realDamage = Calculator.GetDamage(damages,damageReduction);
		health -= realDamage;

		if(health < 0) health = 0;
        
        GameObject mObject = Instantiate(damageText, transform.position, Quaternion.identity) as GameObject;
        mObject.GetComponent<DamageText>().value =(int)realDamage;
	}
	
}
