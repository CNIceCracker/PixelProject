using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Damage : MonoBehaviour {
	public List<DamageData> damages;
	public List<GameObject> buffs;
	public bool isPlayerAttack;
	public float attackFix;

	public void AddBuff(GameObject target){

		Transform buffPoint = target.transform.FindChild("BuffPoint");
		if(buffPoint == null){
			buffPoint = new GameObject("BuffPoint").transform;
			buffPoint.parent = target.transform;
			buffPoint.localPosition = Vector3.zero;
		}

		foreach(GameObject buff in buffs){
			Buff buf = buff.GetComponent<Buff>();
			if((buf.GetFixType() & BuffFixType.BeforeAttach) == BuffFixType.BeforeAttach){
				buf.FixBeforeAttach();
			}
			buff.transform.SetParent(buffPoint);
			buff.transform.localPosition = Vector3.zero;
			buf.Occur();
		}
	}
}
  