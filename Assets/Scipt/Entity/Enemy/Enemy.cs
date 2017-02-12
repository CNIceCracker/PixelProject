using UnityEngine;
using System.Collections;
using System;

public class Enemy : Fightable {
	public EnemyNameData enemyName;
	public int level;
	public float visualField;
	public float attackRange;
	public Vector3 target;

	[SerializeField]
	protected bool isDead = false;

	public event EventHandler Died;

	virtual protected Command Think(){return null;}

	protected IEnumerator DieNow()
	{
		if( Died != null )
		{
			isDead = true;
			Died(this, null);
			Calculator.clearEvent(ref Died);
			yield return new WaitForSeconds(1f);
			ObjectPoolMgr.instance.Recycle(this.gameObject);
		}
	}

	public void Rebirth(){
		isDead = false;
		GetComponent<ShowHP>().PrepareHPS();
		RecoverHealth();
	}
}
