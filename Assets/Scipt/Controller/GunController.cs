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

	public void CreateOneBullet(Vector3 target,Transform firePoint,GameObject bullet,List<DamageData> damages,
	                            float attackRange,float accurate,bool isPlayer){
		//GameObject bulletObj = Instantiate(bullet,firePoint.position,firePoint.rotation) as GameObject;
		GameObject bulletObj = ObjectPoolMgr.instance.Alloc(bullet);
		bulletObj.transform.SetParent(null);
		bulletObj.transform.position = firePoint.position;
		Bullet bulletComp = bulletObj.GetComponent<Bullet>();
		bulletComp.damages = damages;
		bulletComp.range = attackRange;
		bulletComp.isPlayerAttack = isPlayer;
		bulletComp.targetWay = Calculator.GetBulletTarget(target,bulletObj.transform.position,accurate);
		//计算角度
		float angle =Mathf.Rad2Deg*Mathf.Atan (bulletComp.targetWay.y / bulletComp.targetWay.x);
		//判断角度所在象限，并进行修正。
		if (bulletObj.transform.position.x - target.x >= 0)
			angle=angle+180;
		//设置物体的自身欧拉角，是物体绕自身坐标系在Z轴，旋转Z度。
		bulletObj.transform.localEulerAngles=new Vector3(0,0,angle);

	}
}
