using UnityEngine;
using System.Collections;

public class PrefabInfo : MonoBehaviour {
	public string types;
	[HideInInspector]
	public float lifetime = 0;
	void OnEnable(){
		if(lifetime > 0){
			StartCoroutine(countTime(lifetime));
		}
	}
	IEnumerator countTime(float lifetime){
		yield return new WaitForSeconds(lifetime);
		ObjectPoolMgr.instance.Recycle(gameObject);
	}

	public void Drop(){
		ObjectPoolMgr.instance.Recycle(gameObject);
	}
}
