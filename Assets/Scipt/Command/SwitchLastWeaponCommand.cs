using UnityEngine;
using System.Collections;

public class SwitchLastWeaponCommand : Command {
	override public void Execute(GameObject actor){
		actor.GetComponent<Fightable>().SwitchWeapon(-1);
	}
}
