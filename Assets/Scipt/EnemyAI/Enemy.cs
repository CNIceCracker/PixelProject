using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float visualField;
	public float attackRange;
	public Vector3 target;

	virtual protected Command Think(){return null;}
}
