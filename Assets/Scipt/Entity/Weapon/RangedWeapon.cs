using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangedWeapon : Weapon {
	public float attackRange;	//攻击距离

	public GameObject bullet; 	//发射的子弹
	public float accurate;		//精准性
	public float fireRate;		//每秒攻击频率
	public int magazineSize;	//弹夹容量
	public int maxAmmo;			//子弹上限
	public float reloadTime;	//填装时间

	public float critChance = 0.05f;	//暴击率
	public float critMultiplier = 2f;	//暴击倍率
	public float statusChance = 0.1f;	//触发几率
	
	//攻击面板
	public List<DamageData> damages = new List<DamageData>();	

	private int curMagazine;
	private int curAmmo;
	private float onceAttactTime;
	private float attactTimer = 0f;
	private bool canAttact;
	private List<Transform> firePoint = new List<Transform>();		//针对多枪管的情况
	private int fireIndex;
	
	void Awake(){
		onceAttactTime = 1/fireRate;
		fireIndex = 0;
		Transform[] children = transform.GetComponentsInChildren<Transform>();
		foreach(Transform child in children){
			if(child.tag == "FirePoint"){
				firePoint.Add(child);
			}
		}
		curMagazine = magazineSize;
		curAmmo = maxAmmo;

	}
	
	void FixedUpdate(){

		//计算能否射击
		if(attactTimer > 0){ 								//若还在冷却则继续计时
			attactTimer -= Time.deltaTime;
		}else if(canAttact == false && curMagazine > 0){	//若弹夹中还有子弹则继续射击
			canAttact = true;
		}else if(curMagazine == 0 && curAmmo > 0){			//若弹夹中没有子弹并且还有弹药则装弹(针对没有子弹后捡到子弹的情况)
			if(curAmmo > magazineSize){
				curMagazine = magazineSize;
				curAmmo -= magazineSize;
			}else{
				curMagazine = curAmmo;
				curAmmo = 0;
			}
		}
	}

	
	override public void Attack(object[] message){
		if(canAttact){
			float attackFix = (float)message[0];
			if(Random.Range(0f,1f) < critChance){
				attackFix *= critMultiplier;
			}
			Vector3 target = (Vector3)message[1];
			bool isPlayer = (bool)message[2];

			GameObject bulletObj = ObjectPoolMgr.instance.Alloc(bullet);
			bulletObj.transform.position = firePoint[fireIndex].position;
			Bullet bulletComp = bulletObj.GetComponent<Bullet>();
			bulletComp.damages = damages;
			bulletComp.range = attackRange;
			bulletComp.isPlayerAttack = isPlayer;
			bulletComp.attackFix = attackFix;

			List<GameObject> buffs;
			if(statusChance > 0){
				buffs = new List<GameObject>();
				foreach(DamageData data in damages){
					if(Random.Range(0f,1f) <= statusChance){
						GameObject buff = ObjectPoolMgr.instance.Alloc(data.status.ToString()+ "Buff");
						buff.transform.SetParent(bulletObj.transform);
						if(buff != null){
							Calculator.SetBuffInfo(bulletObj,ref buff);
							buffs.Add(buff);
						}
					}
				}
			}else{
				buffs = null;
			}
			bulletComp.buffs = buffs;

			GunController.instance.ChangeBulletWay(target,bulletObj,accurate);

			//计算弹药消耗,更新冷却时间
			canAttact = false;
			if(--curMagazine == 0){
				attactTimer = reloadTime;
				if(curAmmo >= magazineSize){
					curMagazine = magazineSize;
					curAmmo -= magazineSize;
				}else if(curAmmo > 0){
					curMagazine = curAmmo;
					curAmmo = 0;
				}
			}else{
				attactTimer = onceAttactTime;
			}

			if(++fireIndex > firePoint.Count-1){
				fireIndex = 0;
			}
		}
	}//End of Attack()

    public void GetAmmoInfo( ref int curAmmo,ref int curMagazine)
    {
        curAmmo = this.curAmmo;
        curMagazine = this.curMagazine;
    }   
}
