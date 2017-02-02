using UnityEngine;
using System.Collections;

public class ObjectPool : MonoBehaviour {
	protected Queue queue = new Queue();		//用来保存池中对象

	[SerializeField]
	protected int _freeObjCount = 0;			//池中待分配对象数量
	public int preAllocCount;					//初始化时预分配对象数量
	public int autoIncreaseCount;				//池中可增加对象数量
	protected bool _binit = false;				//是否已经初始化
	[HideInInspector]
	public GameObject prefab;					//prefab引用
	[HideInInspector]
	public string objTypeString;				//池中对象描述字符串

	protected void AddPrefab(int num){
		for(int i = 0;i < num; i++){	//初始化多个对象
			GameObject obj = Instantiate(prefab , new Vector3(0,0,0), Quaternion.identity) as GameObject;
			obj.SetActive(false);//防止挂在returnObj上的脚本自动开始执行
			obj.transform.parent = this.transform;
			queue.Enqueue(obj);
		}
	}

	public virtual GameObject Alloc(float lifetime){
		//如果没有进行过初始化，先初始化创建池中的对象
		if(!_binit){
			AddPrefab(preAllocCount);
			_binit = true;
		}

		if(lifetime<0){
			return null;//lifetime<0时，创建对象池并返回null
		}

		if(_freeObjCount <= 0) AddPrefab(autoIncreaseCount);//若已经没有可用对象则新分配一个
		GameObject returnObj = queue.Dequeue() as GameObject;
		_freeObjCount--;

		//使用PrefabInfo脚本保存returnObj的一些信息
		PrefabInfo info = returnObj.GetComponent<PrefabInfo>();
		if(info == null){
			info =  returnObj.AddComponent<PrefabInfo>();
		}
		if(lifetime > 0){
			info.lifetime = lifetime;
		}
		info.types = objTypeString;
		returnObj.SetActive(true);
		return returnObj;
	}
	
	public virtual void Recycle(GameObject obj){
		//待分配对象已经在对象池中
		if(queue.Contains(obj)){
			Debug.LogWarning("the obj " + obj.name + " be recycle twice!" );
			return;
		}
		if( _freeObjCount > preAllocCount + autoIncreaseCount ){
			Destroy(obj);//当前池中object数量已满，直接销毁
		}else{
			queue.Enqueue(obj);//入队，并进行reset
			obj.transform.parent = this.transform;
			obj.SetActive(false);
			_freeObjCount++;
		}
	}

}
