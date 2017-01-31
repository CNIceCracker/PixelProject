using UnityEngine;
using System.Collections;

public class MoveToRightCommand : Command {
	override public void Execute(GameObject actor){
		actor.GetComponent<Moveable>().MoveToRight();
	}
}
