using UnityEngine;
using System.Collections;

public abstract class Command {
	public virtual void Execute(GameObject actor){}
}
