using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	virtual public void Attack(object[] message){}
	virtual public string GetAmmoInfo(){
		return "--/--";
	}
}
