using UnityEngine;
using System.Collections;

public class BuffPool : ObjectPool {

	public override GameObject Alloc(float lifetime){
		GameObject obj = base.Alloc(lifetime);
		Buff buff = obj.GetComponent<Buff>();
		if(buff.GetIsInit() == false){
			buff.Init();
		} 
		return obj;
	}

	public override void Recycle (GameObject obj)
	{
		obj.GetComponent<Buff>().Termination();
		base.Recycle (obj);
	}
}
