using UnityEngine;
using System.Collections;

public class CommonPool : ObjectPool {
	public override GameObject Alloc(float lifetime){
		GameObject commonObject= base.Alloc(lifetime);
		return commonObject;
	}
}
