using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHP : MonoBehaviour {
	public GameObject HpSlider; //血条种类
	public float sliderHeight; 	//血条距离头部的高度

	private float ModelHeight;
	private GameObject GOslider;
	private Slider slider;

	void Awake(){
		PrepareHPS();
	}

	void FixedUpdate(){
		ShowHPS();
	}

	void PrepareHPS(){
		GOslider = Instantiate(HpSlider) as GameObject;		//生成血条
		GOslider.transform.SetParent(GameObject.Find("Canvas").transform);	//将其置于Canvas下
		GOslider.transform.localScale = new Vector3(0.2f,0.4f,1f);		//设置初始尺寸
		slider = GOslider.GetComponent<Slider>();
		slider.maxValue = GetComponent<Fightable>().health;
		ModelHeight = transform.localScale.y * GetComponent<BoxCollider2D>().bounds.size.y;
	}

	void ShowHPS(){
		float currentHealth = GetComponent<Fightable>().health;
		if(currentHealth >0){
			slider.value = currentHealth;
			//得到头顶在世界中的坐标
			//默认坐标点在脚底下，所以这里加上模型的高度即可
			Vector3 worldPosition = new Vector3 (transform.position.x , transform.position.y + ModelHeight + sliderHeight,transform.position.z);
			//根据头顶的3D坐标换算成它在2D屏幕中的坐标
			Vector2 position = Camera.main.WorldToScreenPoint (worldPosition);
			//得到真实头顶的2D坐标
			position = new Vector2 (position.x,position.y);
			slider.transform.position = position;
		}else{
			DistoryHPS();
		}
	}

	public void DistoryHPS(){
		Destroy(GOslider);
	}
}
