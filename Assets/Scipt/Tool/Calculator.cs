using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Calculator{
	/// <summary>
	/// 根据目标和子弹初始位置以及精确度计算出子弹应该飞行的方向
	/// </summary>
	/// <returns>The bullet target.</returns>
	/// <param name="target">Target.</param>
	/// <param name="BulletPos">Bullet position.</param>
	/// <param name="accurate">Accurate.</param>
	public static Vector2 GetBulletTarget(Vector3 target,Vector3 BulletPos, float accurate){
		Vector2 targetWay = new Vector2(target.x - BulletPos.x, target.y - BulletPos.y).normalized;
		float inaccuracy = (100-accurate) * UnityEngine.Random.Range(-1f,1f) / 500f;
		return new Vector2(targetWay.x - inaccuracy,targetWay.y + inaccuracy).normalized;
	}

	/// <summary>
	/// 根据攻击和护甲计算应该受到的伤害
	/// </summary>
	/// <returns>The damage.</returns>
	/// <param name="attack">Attack.</param>
	/// <param name="armor">Armor.</param>
	public static float GetDamage(List<DamageData> damages,float armor){
		float allDamage = 0f;
		float damageReduction = armor /(300f+armor);	//应当减免的伤害比例，护甲越高，这个数值越高
		foreach(DamageData damage in damages){
			allDamage += damage.value;
		}
		allDamage *= (1-damageReduction);
		return allDamage;
	}

	/// <summary>
	/// 计算目标是否会被击中
	/// </summary>
	/// <returns><c>true</c>, if damaged was been, <c>false</c> otherwise.</returns>
	/// <param name="target">Target.</param>
	/// <param name="damage">Damage.</param>
	public static bool BeDamaged(Transform target, Damage damage){
		if(target.tag == "Player"){
			if(!damage.isPlayerAttack){
				return true;
			}
			else{
				return false;
			}
		}else{
			if(damage.isPlayerAttack){
				return true;
			}
			else{
				return false;
			}
		}
	}

	/*
	public static void SetBuffInfo(GameObject owner,ref GameObject buff){
		switch(buff.name){
		case "ImpactBuff(Clone)":
			buff.GetComponent<ImpactBuff>().ownerTrans = owner.transform;
			break;
		case "SlashBuff(Clone)":
			buff.GetComponent<SlashBuff>().lifeTime = 3;
			break;
		}
	}*/

	public static void clearEvent(ref EventHandler clearEvent)
	{
		Delegate[] dels = clearEvent.GetInvocationList();
		foreach (Delegate del in dels)
		{
			/*//得到方法名
			object delObj = del.GetType().GetProperty("Method").GetValue(del, null);
			string funcName = (string)delObj.GetType().GetProperty("Name").GetValue(delObj, null);
			Debug.Log(funcName);*/

			clearEvent -= del as EventHandler;
		}
	}
}
