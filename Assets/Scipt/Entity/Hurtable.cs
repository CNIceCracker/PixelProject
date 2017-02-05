using UnityEngine;
using System.Collections;

public class Hurtable : MonoBehaviour {

	public float health;
	public float armor = 0;

    public GameObject damageText;

	public void BeAttacked(float enemyAttack){
        float realDamage=Calculator.GetDamage(enemyAttack, armor);
        health -= realDamage;
		if(health < 0) health = 0;
        
        GameObject mObject = Instantiate(damageText, transform.position, Quaternion.identity) as GameObject;
        mObject.GetComponent<DamageText>().value =(int)realDamage;
	}

	void OnTriggerEnter2D (Collider2D other){ //监测是否被攻击
		/*if(other.tag == "Damage"){
			Damage damage = other.GetComponent<Damage>();
			if(Calculator.BeDamaged(transform,damage)){
				BeAttacked(damage.attack);
				Destroy(other.gameObject);
			}
		}*/
	}
}
