using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {


	public string enemyName;
	public float interval;
	public bool isCreating;
	public float visualField;

	private float timer;
	private GameObject player;
	private float distance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		timer = interval;
	}
	
	// Update is called once per frame
	void Update () {
		distance = (player.transform.position - transform.position).magnitude;
		if(distance < visualField && isCreating == true){
			timer += Time.deltaTime;
			if(timer >= interval){
				CreateEnemy();
				timer = 0f;}
		}
	}


	private void CreateEnemy(){
		Instantiate(Resources.Load("Enemy/" + enemyName),transform.position,transform.rotation);
	}
}