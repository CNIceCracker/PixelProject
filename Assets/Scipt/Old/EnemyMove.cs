/*using UnityEngine;
using System.Collections;

public class EnemyMove: MonoBehaviour {
	public float visualField; //视野范围
	public float speed; //移动速度
	public bool canFly; //是否可以飞行
	public float stopDistance; //停止移动的距离

	private Animator anim;
	private Vector3 moveWay; 	//应该移动的方向

	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate () {
		if(!PlayerController.instance.isDead){
			moveWay = PlayerController.instance.player.transform.position - transform.position;
		}

		if(moveWay.magnitude <= visualField){ //若与Player的距离小于视野范围, 即Player在视野范围之内
			//更改朝向
			if(moveWay.x > 0.1){
				transform.localScale = new Vector3(1,1,1);
			}else if(moveWay.x < -0.1){
				transform.localScale = new Vector3(-1,1,1);
			}

			if(moveWay.magnitude >= stopDistance){ //若与Player距离大于停止距离则移动，否则不移动
				anim.SetBool("IsMove",true);
				transform.Translate(moveWay.normalized * speed * Time.deltaTime,Space.World);
			}

		}else{
			anim.SetBool("IsMove",false);
		}

	}
}
 */