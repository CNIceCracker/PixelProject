using UnityEngine;
using System.Collections;

public class Buff : MonoBehaviour {
	public int buffId;
	public int buffType;
	public int lifeCycleTime;
	public int buffLevel;
	protected BuffFixType fixType;
	protected bool isInit;

	public virtual void Init(){}

	public virtual void Occur(){}
	public virtual void OnTick(){}
	public virtual void BeHit(){}
	public virtual void BeHurt(){}
	public virtual void BeforeKilled(){}
	public virtual void AfterKilled(){}
	public virtual void Termination(){}

	public virtual void FixAfterCreate(){}
	public virtual void FixBeforeAttach(){}

	public BuffFixType GetFixType(){
		return fixType;
	}

	public bool GetIsInit(){
		return isInit;
	}

}
