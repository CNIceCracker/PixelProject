using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	/*
	private Rigidbody2D rigidbody2d;
	private Animator anim;


	void Awake(){
		rigidbody2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update(){

		//移动
		float hv = Input.GetAxis("Horizontal");
		Move (hv);
		
		//跳跃
		if(PlayerController.instance.isGround&&Input.GetKeyDown(KeyCode.K)){
			Jump ();
		}

		//防止停止按键以后人物继续滑动
		if(Mathf.Abs (hv) == 0){
			rigidbody2d.velocity = new Vector2(0,rigidbody2d.velocity.y);
		}

		anim.SetFloat("Velocity",Mathf.Abs(hv));
		anim.SetFloat("Vertical",rigidbody2d.velocity.y);

	}

	void OnCollisionStay2D(Collision2D c){
		if(c.collider.tag == "Ground"){
			PlayerController.instance.isGround = true;
		}
	}

	private void Move(float horizontalValue){
		if(horizontalValue>0.05f){
			rigidbody2d.AddForce(new Vector2(PlayerController.instance.playerSpeed,0));
			transform.localScale = new Vector3(1, 1, 1);
		}else if(horizontalValue<-0.05f){
			rigidbody2d.AddForce(new Vector2(-PlayerController.instance.playerSpeed,0));
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	private void Jump(){
		rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x,PlayerController.instance.playerJumpSpeed);
		PlayerController.instance.isGround = false;
	}

	void OnDestroy(){
		PlayerController.instance.isDead = true;
	}*/
}
