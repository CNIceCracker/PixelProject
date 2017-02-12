using UnityEngine;
using System.Collections;

public class ImpactBuff : Buff {
	public Transform ownerTrans;
	
	private Vector2 way;

	public override void StartUp ()
	{
		if(transform.position.x - ownerTrans.position.x < 0){
			way = Vector2.left;
		}else{
			way = Vector2.right;
		}
		way *= 1200;
		GetComponentInParent<Rigidbody2D>().AddForce(way);
		ObjectPoolMgr.instance.Recycle(this.gameObject);
	}

}
