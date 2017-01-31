using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	//private Transform itemListTransform;


	private List<Transform> gridList = new List<Transform>();
	
	//public string gridPath = "UI/InventoryGrid";  
	//public string ironElementPath = "UI/IronElement";   
	
	void Awake (){  
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach(Transform child in allChildren){
			if(child.tag == "Grid"){
				gridList.Add(child.transform);
			}
		}
	}

	//添加物品  
	public void AddItem(string itemPath, int count = 1){  
		//如果有相同的物品，则只是更改包里该物品的数量；否则实例化该物品，改数量  
		bool hasSameItem = false;  
		
		for (int i = 0; i < gridList.Count; i++){  
			//如果有物品  
			if(gridList[i].childCount > 0){
				Transform tra = gridList[i].GetChild(0);
				//如果有该物品
				string name = itemPath.Substring(itemPath.LastIndexOf('/') + 1);  //得到最后一个'/'后面的字符串 即增加的物品名字
				if (tra.name.Equals(name)){ //若名字相等
					hasSameItem = true;
					ModifyCount(tra.GetComponentInChildren<Text>(), count);  
					break;
				}
			}
		}
		
		if(!hasSameItem){
			for (int i = 0; i < gridList.Count; i++){  
				if(gridList[i].childCount == 0){  //若找到一个没有子物体的grid

					GameObject go = Instantiate(Resources.Load(itemPath)) as GameObject;  
					//go.GetComponent<Image>().sprite = Resources.Load<Sprite>(itemPath);  
					go.name = go.name.Substring(0,go.name.IndexOf("(Clone)"));
					go.transform.SetParent(gridList[i], false);  
					ModifyCount(go.GetComponentInChildren<Text>(), count);

					break;
				}
			}
		}
	}

	//更新物品数量
	private void ModifyCount(Text text, int count){  
		int num = int.Parse(text.text);  
		num += count;  
		text.text = num.ToString();
	}
	
	/*//整理
	public void Tidy(){  
		List<Transform> tempList = new List<Transform>();  
		for (int i = 0; i < gridList.Count; i++){  
			if (gridList[i].childCount > 0) tempList.Add(gridList[i].GetChild(0));  
		}
		
		for (int i = 0; i < tempList.Count; i++){  
			tempList[i].SetParent(gridList[i]);  
			tempList[i].position = gridList[i].position;  
		}  

	}  //似乎忘记消除原来的？*/

	/*
	public void ClearUpGrid(){
		for (int i = 0; i < grid.Count; i++)
		{
			bool isHaving= grid[i].transform.FindChild("Wood_Image(Clone)");
			if(isHaving){
				GameObject go=grid[i].transform.FindChild("Wood_Image(Clone)").gameObject;
				c_grid.Add(go);//将当前格子内的物品存储到后备列表里面
				if(i==grid.Count-1)//当所有格子内的物品都存放到备用列表中后
					grid.Clear();//清空当前的背包
			}
		}
		for (int j = 0; j < c_grid.Count; j++)
		{
			//对于每个存储到后备列表中的物品，我们依次添加到格子列表中
			GameObject go=c_grid[j];
			go.transform.SetParent(grid[j].transform);
			//调整物品的位置位于格子中间
			go.transform.localPosition=Vector3.zero;  
			//如果所有的物品都添加到了物品格子列表中，则清空后备列表
			if(j==c_grid.Count)
				c_grid.Clear();
		} 
	}*/
}
