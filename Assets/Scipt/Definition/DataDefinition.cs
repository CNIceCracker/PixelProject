using UnityEngine;
using System.Collections;

[System.Serializable]
public class DamageData {
	public DamageStatusEffect status;
	public float value;

	public DamageData(DamageStatusEffect status,float value){
		this.status = status;
		this.value = value;
	}
}
