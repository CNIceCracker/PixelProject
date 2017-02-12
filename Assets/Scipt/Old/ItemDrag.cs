/*using UnityEngine;  
using UnityEngine.UI;  
using UnityEngine.EventSystems;  
using System.Collections;  

public class ItemDrag : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IDragHandler {  


	// 鼠标起点  
	private Vector2 originalLocalPointerPosition;     
	// 面板起点  
	private Vector3 originalPanelLocalPosition;  
	// 当前面板  
	private RectTransform panelRectTransform;  
	// 父面板
	private RectTransform parentRectTransform;  

	private GameObject scrollRect;//在gridlist之上的一个物体作为父节点
	private GameObject originalGrid;//记录物品拖动前的位置

	private static int siblingIndex = 0;  
	private Inventory inventory;

	void Awake () {  
		panelRectTransform = transform as RectTransform;  //设置当前面板
		parentRectTransform = GameObject.FindGameObjectWithTag("ScrollRect").GetComponent<RectTransform>() as RectTransform;  //设置父面板
		scrollRect = GameObject.Find("ScrollRect");
	}
	
	// 鼠标按下  
	public void OnPointerDown (PointerEventData data) {  
		originalGrid=panelRectTransform.parent.gameObject;	//记录物品当前所在的格子信息
		if(!Input.GetKey(KeyCode.LeftShift)){ //若此时没有按下左shift键
			panelRectTransform.SetParent(scrollRect.transform);	//将物品放置在gridManager下
			siblingIndex++;  
			panelRectTransform.transform.SetSiblingIndex(siblingIndex);		//设置当前面板层级，保证物品显示在整个背包层面之上
			
			// 记录当前面板起点  
			originalPanelLocalPosition = panelRectTransform.localPosition;  
			
			// 通过屏幕中的鼠标点，获取在父节点中的鼠标点
			// parentRectTransform:父节点  
			// data.position:当前鼠标位置  
			// data.pressEventCamera:当前事件的摄像机  
			// originalLocalPointerPosition:获取当前鼠标起点  
			RectTransformUtility.ScreenPointToLocalPointInRectangle (parentRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition); 
		}
		 
	}  

	// 拖动  
	public void OnDrag (PointerEventData data) {  
		if (panelRectTransform == null || parentRectTransform == null){ //若当前面板或父面板未获取则返回
			return;  
		}
		Vector2 localPointerPosition;  // 获取本地鼠标位置  

		//返回值 bool: Returns true if the plane of the RectTransform is hit, regardless of whether the point is inside the rectangle.
		//if语句作用: 限制物品拖动范围不超出父面板
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle 
		    (parentRectTransform, data.position, data.pressEventCamera, out localPointerPosition)) {  

			// 移动位置 = 本地鼠标当前位置 - 本地鼠标起点位置  
			Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;  
			// 当前物品位置 = 物品起点 + 移动位置  
			panelRectTransform.localPosition = originalPanelLocalPosition + offsetToOriginal;  

		}  
		// ClampToWindow ();  
	}

	// 鼠标抬起
	public void OnPointerUp(PointerEventData data){
		// transform.SetParent(gridlist.transform);
		RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition,-Vector2.up); 
		//若碰撞到物体
		if (hit.collider != null) {		 
			//如果射线检测到的gameobject为grid,且没有子物体,就把当前物品放在grid节点下 
			if(hit.collider.gameObject.tag=="Grid" && hit.collider.gameObject.transform.childCount == 0) {
				transform.SetParent(hit.transform,false);
			}
		}
		//如果不是格子或没有检测到物体，则将物品放回到原来的格子内
		else{
			transform.SetParent(originalGrid.transform);
		}
		//重置物品位置
		transform.localPosition=Vector3.zero;
	}


}*/