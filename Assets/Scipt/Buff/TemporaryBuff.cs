/*using UnityEngine;
using System.Collections;

public class TemporaryBuff : Buff {
	public float lifeTime;

	public IEnumerator Timing(){
		yield return new WaitForSeconds(lifeTime);
		ObjectPoolMgr.instance.Recycle(this.gameObject);
	}

}
*/