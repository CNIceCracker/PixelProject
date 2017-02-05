using UnityEngine;
using System.Collections;

public class Buff : MonoBehaviour {
	public float lifeTime;

	public virtual IEnumerator Trigger(){
		yield return new WaitForSeconds(lifeTime);
	}
}
