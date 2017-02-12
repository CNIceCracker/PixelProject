using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour{

	public static GunController instance = null; 
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}

	public void ChangeBulletWay(Vector3 target,GameObject bullet,float accurate = 100f){

		Bullet bulletComp = bullet.GetComponent<Bullet>();

		bulletComp.targetWay = Calculator.GetBulletTarget(target,bullet.transform.position,accurate);
		//计算角度
		float angle =Mathf.Rad2Deg*Mathf.Atan (bulletComp.targetWay.y / bulletComp.targetWay.x);
		//判断角度所在象限，并进行修正。
		if (bullet.transform.position.x - target.x >= 0)
			angle=angle+180;
		//设置物体的自身欧拉角，是物体绕自身坐标系在Z轴，旋转Z度。
		bullet.transform.localEulerAngles=new Vector3(0,0,angle);


	}
}
