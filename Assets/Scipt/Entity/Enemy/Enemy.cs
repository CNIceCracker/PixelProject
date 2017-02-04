using UnityEngine;
using System.Collections;
using System;

public class Enemy : Fightable {
	public float visualField;
	public float attackRange;
	public Vector3 target;

	public event EventHandler Died;

	virtual protected Command Think(){return null;}

	protected IEnumerator DieNow()
	{
		EventHandler handler = Died;
		if( handler != null )
		{
			handler(this, null);
			yield return new WaitForSeconds(1f);
			ObjectPoolMgr.instance.Recycle(this.gameObject);
		}
	}
}
