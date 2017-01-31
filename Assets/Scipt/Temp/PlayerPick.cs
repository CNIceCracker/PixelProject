using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class PlayerPick : MonoBehaviour {
	public Text itemInfoText;

	public float itemInfoTextHigh;

	private GameObject pickObj;

	private XmlDocument xml;
	private string showItemName;
	//private string showItemType;

	private bool isFind;

	void Awake(){
		LoadItemInfoXml();
	}

	void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.tag == "Loot"){
			//Debug.Log("UI/" + other.gameObject.name.Substring(0,other.gameObject.name.LastIndexOf("(Clone)")));

			PlayerController.instance.inventory.AddItem("Item/UI/" + other.gameObject.name.Substring(0,other.gameObject.name.LastIndexOf("(Clone)")));
			Destroy(other.gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if(other.gameObject.tag == "Item"){
			pickObj = other.gameObject;

			if(PlayerController.instance.canPick == false){
				PlayerController.instance.canPick = true;
			}
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if(other.gameObject.tag == "Item"){
			if(pickObj.Equals(other.gameObject)){
				PlayerController.instance.canPick = false;
				pickObj = null;
			}
		}
	}

	void Update(){
		if(pickObj == null){
			PlayerController.instance.canPick = false;
		}

		ShowItemInfo(pickObj);

		if(PlayerController.instance.canPick && Input.GetKeyDown(KeyCode.J)){
			///PlayerController.instance.pickUpItem(showItemName,showItemType);
			Destroy(pickObj);
		}
	}

	void ShowItemInfo(GameObject Item){
		if(!PlayerController.instance.canPick || Item == null){
			itemInfoText.text = "";
			showItemName = "";
			return;
		}


		Vector2 position = Camera.main.WorldToScreenPoint (Item.transform.position + new Vector3(0,itemInfoTextHigh,0));
		itemInfoText.transform.position = position;

		if(Item.name.Substring(0,Item.name.IndexOf("_")) != showItemName){

			isFind = false;

			XmlNodeList xmlNodeList = xml.SelectSingleNode("ItemInfo").ChildNodes;

			foreach(XmlElement element in xmlNodeList){

				if(isFind) break;
				else if(element.FirstChild.InnerText == Item.name.Substring(0,Item.name.IndexOf("_"))){

					showItemName = element["Name"].InnerText;
					//showItemType = element["Type"].InnerText;
					isFind = true;

					switch (element["Rare"].InnerText){
					case "White": itemInfoText.color = Color.white;break;
					case "Blue": itemInfoText.color = Color.blue;break;
					case "Green": itemInfoText.color = Color.green;break;
					}

					itemInfoText.text = element["Name"].InnerText+ "\n" + element["Info1"].InnerText + "\n" + element["Info2"].InnerText;
				}
			}
		}

		if(!isFind){
			itemInfoText.text = "Can't Find Infomation !";
		}
		//Text info = weapon.GetComponentInChildren<Text>();
	}

	void LoadItemInfoXml(){
		xml = new XmlDocument();
		string doc = Resources.Load("Xml/ItemInfo").ToString(); 
		xml.LoadXml(doc);
		/*XmlReaderSettings set = new XmlReaderSettings();
		set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取
		set.ProhibitDtd = false; //这个设置是忽略DTD,不然Unity会报错
		xml.Load(XmlReader.Create((Application.dataPath+"/Resources/Xml/ItemInfo.xml"),set));*/
	}
}
