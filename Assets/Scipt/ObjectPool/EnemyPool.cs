using UnityEngine;
using System.Collections;

public class EnemyPool : ObjectPool {

	public override GameObject Alloc (float lifetime)
	{
		//分配前要回满血
		GameObject enemy = base.Alloc (lifetime);
		enemy.GetComponent<Enemy>().Rebirth();
		return enemy;
	}

	public override void Recycle (GameObject obj)
	{


		//回收Buff
		Transform buffPoint = obj.transform.FindChild("BuffPoint");
		if(buffPoint != null){
			for(int i = 0; i < buffPoint.childCount;i++){
				ObjectPoolMgr.instance.Recycle(buffPoint.GetChild(i).gameObject);
			}
		}

		base.Recycle (obj);
	}

}
