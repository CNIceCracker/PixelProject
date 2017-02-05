using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hurtable : MonoBehaviour {

	public float health;
	public float armor = 0;


	public void BeAttacked(List<DamageData> damages){
		float damageReduction = armor/(300f+armor);
		health -= Calculator.GetDamage(damages,damageReduction);

		if(health < 0) health = 0;
        
        GameObject mObject = Instantiate(damageText, transform.position, Quaternion.identity) as GameObject;
        mObject.GetComponent<DamageText>().value =(int)realDamage;
	}
	
}
