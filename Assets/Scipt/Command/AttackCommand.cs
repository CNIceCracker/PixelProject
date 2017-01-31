using UnityEngine;
using System.Collections;

public class AttackCommand : Command {
	private object[] message;
	/// <summary>
	/// message包含两条信息,第一条:Vector3类型 攻击的对象的地址,第二条：bool类型 攻击是否由Player发出
	/// </summary>
	public AttackCommand(object[] _message){
		message = _message;
	}
	
	override public void Execute(GameObject actor){
		actor.GetComponent<Fightable>().Attack(message);
	}
}
