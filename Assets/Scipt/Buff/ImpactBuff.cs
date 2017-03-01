using UnityEngine;
using System.Collections;

public class ImpactBuff : Buff {
	//击中目标前自身的位置
	public Vector3 pos;

	public override void Init(){
		fixType = BuffFixType.BeforeAttach;
		isInit = true;
	}
	
	public override void Occur (){
		Vector2 way;
		if(transform.position.x - pos.x > 0){
			way = Vector2.right;
		}else{
			way = Vector2.left;
		}
		way *= 1200;
		GetComponentInParent<Rigidbody2D>().AddForce(way);
		ObjectPoolMgr.instance.Recycle(this.gameObject);
	}

	public override void FixBeforeAttach (){
		pos = this.transform.position;
	}

}