using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spawner : MonoBehaviour {
	
	public int enemyNumber;							//总共能产生的敌人数量
	public GameObject[] enemy = new GameObject[10];
	public float[] enemyRate = new float[10];		//生成敌人的几率
	public float interval;							//生成敌人的间隔
	public float stopSpawnDistance;					//靠近一段距离后就不生产了
	public bool isSpawning;

	private float timer;
	private Transform player;
	private float distance;
	private int curNum;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		player = PlayerController.instance.player.transform;
		anim = gameObject.GetComponent<Animator>();
		timer = interval;
	}
	
	// Update is called once per frame
	void Update () {
		distance = (player.transform.position - transform.position).magnitude;
		if(distance > stopSpawnDistance && enemyNumber > curNum){
			timer += Time.deltaTime;
			if(timer >= interval){
				StartCoroutine(CreateEnemy());
				timer = 0f;
			}
		}
	}

	private IEnumerator CreateEnemy(){
		float weight = UnityEngine.Random.Range(0f,1f);
		for(int num = 0;num < enemyRate.Length;num++){
			weight -= enemyRate[num];
			if(weight <= 0){
				anim.SetBool("IsOpen",true);
				yield return new WaitForSeconds(interval/2);
				//GameObject enemy = Instantiate(Resources.Load("Enemy/" + enemyName[num]),transform.position,transform.rotation) as GameObject;
				GameObject newEnemy = ObjectPoolMgr.instance.Alloc(enemy[num]);
				newEnemy.transform.position = this.transform.position;
				newEnemy.GetComponent<Enemy>().target = transform.position + new Vector3(UnityEngine.Random.Range(-10,10),0,0);
				newEnemy.GetComponent<Enemy>().Died += childDie;
				curNum++;
				anim.SetBool("IsOpen",false);
				break;
			}
		}
	}

	private void childDie(object o,EventArgs e){
		curNum--;
	}

}
