using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

	/*public GameObject bullet;//发射的子弹

	public GameObject HpSlider;//血条
	public float sliderHeight;
	
	private float onceAttactTime;
	private float attactTimer = 0f;
	private float ModelHeight;//模型高度
	
	private GameObject GOslider;
	private Slider slider;

	void Awake()
	{
		GOslider = Instantiate(HpSlider) as GameObject; //生成血条
		GOslider.transform.SetParent(GameObject.Find("Canvas").transform);//将血条的父物体设置为Canvas
		GOslider.transform.localScale = new Vector3(0.6f,1f,1f);//设置血条比例
		slider = GOslider.GetComponent<Slider>();
		slider.maxValue = PlayerController.instance.playerHealth;//设置血条最大值
		ModelHeight = transform.localScale.y * GetComponent<BoxCollider2D>().bounds.size.y; //模型高度 = 比例 * 碰撞体的高度
	}

	void Update(){
		onceAttactTime = 1/PlayerController.instance.playerAttackRate;

		if(attactTimer <= onceAttactTime){ //计算是否可以射击
			attactTimer += Time.deltaTime;
		}else if(PlayerController.instance.canShoot == false){
			PlayerController.instance.canShoot = true;
		}

		if(PlayerController.instance.canShoot && Input.GetKey(KeyCode.J) && !PlayerController.instance.canPick ) { //若按下J并且人物不能拾取东西时开火
			Fire();
			PlayerController.instance.canShoot = false;
			attactTimer = 0f;
		}

		HpSliderFollow();
	}

	void Fire(){
		GameObject bulletObj = Instantiate(bullet,PlayerController.instance.playerFirePoint.position,transform.rotation) as GameObject;
		bulletObj.transform.localScale = transform.localScale; //设置子弹的比例
		bulletObj.GetComponent<Bullet>().attack = PlayerController.instance.playerAttack;
	}

	void HpSliderFollow(){
		slider.value = PlayerController.instance.playerHealth;
		//得到头顶在世界中的坐标
		//默认坐标点在脚底下，所以这里加上模型的高度即可
		Vector3 worldPosition = new Vector3 (transform.position.x , transform.position.y + ModelHeight + sliderHeight,transform.position.z);
		//根据头顶的3D世界坐标换算成它在2D屏幕中的坐标
		Vector2 position = Camera.main.WorldToScreenPoint (worldPosition);
		//得到目标真实头顶的屏幕坐标
		//position = new Vector2 (position.x,position.y);
		slider.transform.position = position;
	}

	void OnTriggerEnter2D (Collider2D other){ //监测是否被子弹打中
		if(other.tag == "Bullet"){
			Bullet bullet = other.GetComponent<Bullet>();
			if(bullet.isPlayerShoot == false){
				PlayerController.instance.playerHealth -= bullet.attack;
				Destroy(other.gameObject);
			}
		}
	}
*/

}
