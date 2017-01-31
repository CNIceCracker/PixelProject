using UnityEngine;
using System.Collections;

public class CharacterMove : Moveable {
	public float speed;
	public float moveEfficiency = 1;
	public float jumpHigh;
	public int jumpTimes;

	private int curJumpTimes;

	override public void MoveToLeft(){
		Rigidbody2D CharacterRB = GetComponent<Rigidbody2D>();
		if(CharacterRB != null){
			CharacterRB.AddForce(new Vector2(-speed * moveEfficiency,0));
		}

	}

	override public void MoveToRight(){
		Rigidbody2D CharacterRB = GetComponent<Rigidbody2D>();
		if(CharacterRB != null){
			CharacterRB.AddForce(new Vector2(speed * moveEfficiency,0));
		}
	}

	virtual public void Jump(){
		Rigidbody2D CharacterRB = GetComponent<Rigidbody2D>();
		if(CharacterRB != null && curJumpTimes > 0){
			CharacterRB.velocity = new Vector2(CharacterRB.velocity.x,jumpHigh * 20);
			curJumpTimes -= 1;
		}
	}

	void Awake(){
		curJumpTimes = jumpTimes;
	}

	void OnCollisionStay2D(Collision2D other){
		if(curJumpTimes < jumpTimes && other.gameObject.tag == "Ground"){
			curJumpTimes = jumpTimes;
		}
	}

}
