using UnityEngine;
using System.Collections;

public class Hurtable : MonoBehaviour {

	public float health;
	public float armor = 0;

	public void BeAttacked(float enemyAttack){
		health -= Calculator.GetDamage(enemyAttack,armor);
		if(health < 0) health = 0;
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
