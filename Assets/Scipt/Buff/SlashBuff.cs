using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlashBuff : Buff {
	public float value = 10;
	public float lifeTime;

	private Hurtable owner;
	private List<DamageData> damage = new List<DamageData>();

	public override void StartUp (){
		owner = GetComponentInParent<Hurtable>();
		damage.Add(new DamageData(DamageStatusEffect.None,value));
		StartCoroutine("Dot");
	}

	public override void Termination ()
	{
		damage.Clear();
		StopCoroutine("Dot");
	}

	public IEnumerator Dot(){
		while(lifeTime > 0){
			owner.BeAttacked(damage);
			if(lifeTime >= 1){
				yield return new WaitForSeconds(1);
				lifeTime--;
			}else{
				yield return new WaitForSeconds(lifeTime);
				lifeTime = 0;
			}
		}

		ObjectPoolMgr.instance.Recycle(this.gameObject);

	}
}
