using UnityEngine;
using System.Collections;

public class BuffPool : ObjectPool {
	public override void Recycle (GameObject obj)
	{
		obj.GetComponent<Buff>().Termination();
		base.Recycle (obj);
	}
}
