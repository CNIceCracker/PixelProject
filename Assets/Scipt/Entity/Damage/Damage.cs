using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Damage : MonoBehaviour {
	public List<DamageData> damages;
	public bool isPlayerAttack;
	public List<GameObject> buffs;

	public void AddBuff(GameObject target){

		Transform buffPoint = target.transform.FindChild("BuffPoint");
		if(buffPoint == null){
			buffPoint = new GameObject("BuffPoint").transform;
			buffPoint.parent = target.transform;
			buffPoint.localPosition = Vector3.zero;
		}

		foreach(GameObject buff in buffs){
			buff.transform.SetParent(buffPoint);
			buff.transform.localPosition = Vector3.zero;
			buff.GetComponent<Buff>().StartUp();
		}
	}
}
  