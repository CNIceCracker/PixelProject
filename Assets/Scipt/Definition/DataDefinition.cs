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

[System.Serializable]
public class EnemyNameData{
	public string enemyType;
	public string prefix;


	public EnemyNameData(string enmeyType,string prefix = null){
		this.enemyType = enmeyType;
		this.prefix = prefix;
	}

	public string GetFullName(){
		return  prefix+ " " + enemyType;
	}
}