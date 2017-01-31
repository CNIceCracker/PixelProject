using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	
	public int enemyNumber;
	public string[] enemyName = new string[10];
	public float[] enemyRate = new float[10];
	public float interval;
	public float stopSpawnDistance;
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
		float weight = Random.Range(0f,1f);
		for(int num = 0;num < enemyRate.Length;num++){
			weight -= enemyRate[num];
			if(weight <= 0){
				anim.SetBool("IsOpen",true);
				yield return new WaitForSeconds(1.0f);
				GameObject enemy = Instantiate(Resources.Load("Enemy/" + enemyName[num]),transform.position,transform.rotation) as GameObject;
				enemy.GetComponent<Enemy>().target = transform.position + new Vector3(Random.Range(-10,10),0,0);
				curNum++;
				anim.SetBool("IsOpen",false);
				break;
			}
		}
	}
}
