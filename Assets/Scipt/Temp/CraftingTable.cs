using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour {
	private List<GameObject> itemList = new List<GameObject>();
	public List<string> itemNameList = new List<string>();

	private XmlDocument xml;
	private Transform result;

	// Use this for initialization
	void Awake () {
		LoadCraftTableXml();
		result = transform.FindChild("Result");
	}

	public void Craft(){   //每次点击合成按钮时调用
		int index = 0;   			    	//记录物品序号
		itemList.Clear();  //先清空列表,再把格子内的物品信息添加到List中
		itemNameList.Clear();
		Transform[] allChildren = transform.FindChild("ItemList").GetComponentsInChildren<Transform>();
		foreach(Transform child in allChildren){
			if(child.tag == "Grid" && child.childCount > 0){
				GameObject item = child.GetChild(0).gameObject;
				itemList.Add(item);
				itemNameList.Add(item.name);
				index++;
			}
		}

		if(index != 3) return;  //若index不等于3, 说明不够3个物品, 无法合成

		//得到CraftTable节点下的所有子节点
		XmlNodeList xmlNodeList = xml.SelectSingleNode("CraftTable").ChildNodes;
		bool isFind = false;
		string resultName = "";  		    //记录合成出来的物品名字
		//遍历所有子节点
		foreach(XmlElement way in xmlNodeList){            //遍历所有的合成方式
			index = 0;
			foreach(XmlElement element in way.ChildNodes){ //遍历元素
				if(isFind){							   //若已经找到符合条件的公式,不继续搜索,同时记录要合成的物品名
					resultName = element.InnerText;
					break;
				}
				if(element.InnerText == itemNameList[index]){  //若元素内容与第index个物品的名字相同
					index++;
					if(index == 3){						       //先将index+1(搜索下一个),再判断index是否等于3(因为合成栏中最多3个物品,即index最多等于2)
						isFind = true;
					}
				}else{								   //否则说明条件不符合, 跳出循环
					break;
				}
			}

			if(isFind){ 						//若找到符合条件的公式,不继续搜索
				break;
			}
		}

		//开始生成物品
		if(isFind){
			bool isOverLap = false;          //记录是否重叠生成

			if(result.childCount > 0){  //若生成格中已有物品
				if(result.GetChild(0).name.Equals(resultName)){   //若是同一种物品,则将isOverLap设置为true;
					isOverLap = true;
				}else{											  //否则取消生成
					return;
				}

			}

			foreach(GameObject item in itemList){				  //遍历物品, 将其数量减少, 若少于0, 则销毁该物体
				Text text = item.GetComponentInChildren<Text>();
				int num = int.Parse(text.text) - 1;

				if(num > 0){
					text.text = num.ToString();
				}else{
					Destroy(item);
				}
			}

			//开始生成物品
			if(isOverLap){      //若是重复生成, 将原物体的数量加一
				result.GetComponentInChildren<Text>().text = (int.Parse(result.GetComponentInChildren<Text>().text) + 1).ToString();
			}else{				//否则生成一个新的物体
				GameObject resultObject = Instantiate(Resources.Load("Item/UI/" + resultName)) as GameObject;
				resultObject.transform.SetParent(result,false);
				resultObject.name = resultObject.name.Substring(0,resultObject.name.IndexOf("(Clone)"));
				resultObject.GetComponentInChildren<Text>().text = "1";
			}

		}
	}

	void LoadCraftTableXml(){
		//创建xml文档
		xml = new XmlDocument();
		string doc = Resources.Load("Xml/CraftTable").ToString(); 
		xml.LoadXml(doc); 

		/*xml = new XmlDocument();
		XmlReaderSettings set = new XmlReaderSettings();
		set.IgnoreComments = true;	//忽略xml注释文档的影响。有时候注释会影响到xml的读取
		set.ProhibitDtd = false; //忽略DTD,不然Unity会报错
		xml.Load(XmlReader.Create((Application.dataPath+"/Resources/Xml/CraftTable.xml"),set));*/

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
