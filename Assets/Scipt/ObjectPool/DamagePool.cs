using UnityEngine;
using System.Collections;

public class DamagePool : ObjectPool {

	public override void Recycle (GameObject obj)
	{

		//回收对象前先回收Buff
		for(int i = 0; i < obj.transform.childCount;i++){
			GameObject buff = obj.transform.GetChild(i).gameObject;
			if(buff.tag == "Buff"){
				ObjectPoolMgr.instance.Recycle(buff);
			}
		}

		base.Recycle (obj);
	}
}
