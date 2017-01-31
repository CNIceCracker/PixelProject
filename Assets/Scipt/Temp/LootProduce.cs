using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootProduce : MonoBehaviour {
	public enum Sort{
		wood = 0,iron = 1, silicon = 2,chemical = 3
	}

	public int woodNum,ironNum,siliconNum,chemicalNum;

	public bool isProduce = false;
	private float produceOnceTime;
	private float produceTimer = 0f;

	private List<string> itemList = new List<string>();
	
	void Start () {
		while(woodNum-- != 0){
			itemList.Add("WoodElement");
		}
		while(ironNum-- != 0){
			itemList.Add("IronElement");
		}
		while(siliconNum-- != 0){
			itemList.Add("SiliconElement");
		}
		while(chemicalNum-- != 0){
			itemList.Add("ChemicalElement");
		}

		produceOnceTime = 1 / itemList.Count;
	}
	
	// Update is called once per frame
	void Update () {
		if(isProduce && itemList.Count != 0){
			if(produceTimer < produceOnceTime){
				produceTimer += Time.deltaTime;
			}else{
				produceTimer = 0f;
				int index = Random.Range(0,itemList.Count - 1);
				GameObject temp = Instantiate(Resources.Load("Item/GameObject/" + itemList[index]),transform.position,transform.rotation) as GameObject;
				temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f),1)*50f);
				itemList.RemoveAt(index);
			}

		}


	}
}
