using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlashBuff : Buff {
	public float value;
	public float lifeTime;

	private Hurtable owner;
	private float timer;

	public override void Init(){
		fixType = BuffFixType.BeforeAttach;
		isInit = true;
	}

	public override void Occur (){
		owner = this.GetComponentInParent<Hurtable>();
	}

	public override void OnTick(){
		if(timer < 1){
			timer += Time.fixedDeltaTime;
		}else{
			owner.BeAttacked(value);
			timer = 0;
			lifeTime -= 1;
		}
		
		ObjectPoolMgr.instance.Recycle(this.gameObject);
	}

	public override void FixBeforeAttach (){
		Damage damage = this.GetComponent<Damage>();
		if(damage == null){
			ObjectPoolMgr.instance.Recycle(this.gameObject);
		}else{
			foreach(DamageData data in damage.damages){
				if(data.status == DamageStatusEffect.Slash){
					value += data.value * 0.5f;
				}
			}
		}
		lifeTime = 2f;
	}
}
