using UnityEngine;
using System.Collections;

public class MoveToLeftCommand : Command {

	override public void Execute(GameObject actor){
		actor.GetComponent<Moveable>().MoveToLeft();
	}
}
