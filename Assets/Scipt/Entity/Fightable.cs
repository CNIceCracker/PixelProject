using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fightable : Hurtable {

	public List<Weapon> weapons = null;
	public int weaponIndex = 0;

	private float attackFix = 1f;
	private List<Buff> buffs = new List<Buff>();

	void Awake(){
		weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
		weapons[0].gameObject.SetActive(true);
	}

	public void Attack(object[] message){
		object[] newMessage = new object[3];
		newMessage[0] = attackFix;
		newMessage[1] = message[0];
		newMessage[2] = message[1];
		weapons[weaponIndex].Attack(newMessage);
	}


	public void SwitchWeapon(int way){
		UnloadWeapon(weapons[weaponIndex]);
		
		weaponIndex += way;
		if(weaponIndex >= weapons.Count) weaponIndex = 0;
		else if(weaponIndex < 0) weaponIndex = weapons.Count - 1;
		
		LoadWeapon(weapons[weaponIndex]);
	}

	private void LoadWeapon(Weapon weapon){
		weapon.gameObject.SetActive(true);
	}
	
	private void UnloadWeapon(Weapon weapon){
		weapon.gameObject.SetActive(false);
	}

	public Buff GetFirstBuffByType(int Type){
		foreach(Buff buff in buffs){
			if(buff.buffType == Type){
				return buff;
			}
		}
		return null;
	}

	public bool AttachBuff(Buff buff){
		Buff old = GetFirstBuffByType(buff.buffType);
		if(old != null && old.buffLevel > buff.buffLevel){
			return false;
		}
		buffs.Add(buff);
		return true;
	}

	public bool DetachBuff(Buff buff){
		return buffs.Remove(buff);
	}

	void FixedUpdate(){
		foreach(Buff buff in buffs){
			buff.OnTick();
		}
	}
}
