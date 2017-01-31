using UnityEngine;  
using System.Collections;  
using UnityEngine.UI;  
using UnityEngine.EventSystems;  

//ICanvasRaycastFilter可以控制射线是否穿透物品，也可以使用CanvasGroup的blocksRaycasts  
public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter {  
	
	private Transform canvas;  
	private Transform nowParent; //一般来说，物品是格子的子物体，nowParent记录的是当前物品属于哪个格子  
	public bool isRaycastLocationValid = true; //默认射线不能穿透物品  

	private GameObject operateObject;
	
	public void OnBeginDrag(PointerEventData eventData){
		canvas = GameObject.Find("Canvas").transform;
		nowParent = transform.parent;

		Text selfText = gameObject.GetComponentInChildren<Text>();
		int apartNum = int.Parse(selfText.text) / 2; //计算可能要拆分出的物体数量

		if(Input.GetKey(KeyCode.LeftShift) && apartNum > 0){
			operateObject = Instantiate(gameObject) as GameObject; //生成一个新的UI
			operateObject.name = operateObject.name.Substring(0,operateObject.name.IndexOf("(Clone)"));

			//修改数值
			operateObject.GetComponentInChildren<Text>().text = apartNum.ToString();  
			selfText.text = (int.Parse(selfText.text) - apartNum).ToString();


		}else{
			operateObject = gameObject;
		}
		operateObject.transform.SetParent(canvas);//将当前拖拽的物品置前  
		operateObject.GetComponent<Item>().isRaycastLocationValid = false;  //让当前拖拽的物品不参与射线检测

	}
	
	public void OnDrag(PointerEventData eventData){  
		operateObject.transform.position = Input.mousePosition;  
	}  
	
	public void OnEndDrag(PointerEventData eventData){  
		GameObject go = eventData.pointerCurrentRaycast.gameObject;  
		
		if (go != null){  
			if (go.tag == "Grid"){  //放置到空格子
				SetParentAndPosition(operateObject.transform, go.transform);  
			}  
			else if (go.tag == "Item"){  
				if(go.name == operateObject.name){  //若是同类物品则合并
					Combine(operateObject,go);
				} else{ //若是其他物品
					if(operateObject == gameObject){  //如果是当前物体整体移动则交换位置，注意可能需要把物品下的子物体的Raycast Target关掉
						SetParentAndPosition(transform, go.transform.parent);  
						SetParentAndPosition(go.transform, nowParent);  
					}else{   //否则取消移动，销毁operateObje
						Combine(operateObject,gameObject);
					}
				}
			}
			else{  //若go.tag既不是Grid也不是Item，说明指向一个无意义的目标
				if(operateObject == gameObject){ //若是当前物体整体移动,则让其返回原位
					SetParentAndPosition(operateObject.transform, nowParent);  
				}else{ //否则取消移动
					Combine (operateObject,gameObject);
				}
			}  
		}  
		else{  //若go == null 说明是无效移动
			if(operateObject == gameObject){ //若是当前物体整体移动,则让其返回原位
				SetParentAndPosition(operateObject.transform, nowParent);  
			}else{ //否则取消移动
				Combine (operateObject,gameObject);
			}
		}  
		operateObject.GetComponent<Item>().isRaycastLocationValid = true;  //让当前拖拽的物品继续参与射线检测
	}  
	
	private void SetParentAndPosition(Transform child, Transform parent){  
		child.SetParent(parent);  
		child.position = parent.position;  
	}  

	private void Combine(GameObject operateObject,GameObject targetObject){ //将前者的数量加到后者上,并销毁前者
		targetObject.GetComponentInChildren<Text>().text = 
			(int.Parse(operateObject.GetComponentInChildren<Text>().text) 
			 + int.Parse(targetObject.GetComponentInChildren<Text>().text)).ToString();
		Destroy(operateObject);
	}
	
	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera){  
		return isRaycastLocationValid;  
	}
	
}  