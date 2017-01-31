using UnityEngine;
using System.Collections;

public class JumpCommand : Command {

	override public void Execute(GameObject actor){
		actor.GetComponent<CharacterMove>().Jump();
	}
}
