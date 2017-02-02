﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolMgr : MonoBehaviour {
	public static ObjectPoolMgr instance = null; 

	private Dictionary<string, ObjectPool> poolDic = new Dictionary<string, ObjectPool>();
	protected bool _binit = false;				//是否已经初始化
	//储存一些初始化信息
	public List<AllocSize> objectPoolList = new List<AllocSize>(5);
	[System.Serializable]
	public class AllocSize{
		public int preAllocSize;
		public int autoIncreaseSize;
		public GameObject prefeb;
	}

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		//如果没有进行过初始化，先初始化创建池中的对象
		if(!_binit){
			_init();
			_binit = true;
		}
		
		DontDestroyOnLoad (gameObject);
	}

	protected void _init(){
		foreach(AllocSize pool in objectPoolList){
			string poolNameString = pool.prefeb.name + "Pool";
			//生成type类型对象池的GameObject,它挂在ObjectPoolMgr层次下
			GameObject subPool = new GameObject(poolNameString);
			subPool.transform.parent = this.transform;
			//根据poolNameString 找到对应的对象池类,并添加到对象池GameObject上
			System.Type poolType = System.Type.GetType(poolNameString);
			ObjectPool newPool = (ObjectPool)subPool.AddComponent(poolType);
			//如果没有为此对象池实现一个类,那么挂载一个带有通用alloc和recycle方法的脚本
			if(!newPool){
				newPool = subPool.AddComponent<CommonPool>() as ObjectPool;
			}
			//传一些参数到新创建的对象池中
			newPool.objTypeString = pool.prefeb.name;
			newPool.prefab = pool.prefeb;
			newPool.preAllocCount = pool.preAllocSize;
			newPool.autoIncreaseCount = pool.autoIncreaseSize;
			poolDic.Add(poolNameString,newPool);
		}
	}

	//两种方法取出，一种用名称，一种用GameObject类型的参数，后者可以无中生有，前者只能从已经存在的对象池中取

	public GameObject Alloc(string type, float lifetime = 0){
		//根据传入type取出对应类型对象池
		ObjectPool subPool = null;
		string poolNameString = type + "Pool"; //拼出对象池名字
		
		if(!poolDic.TryGetValue(poolNameString,out subPool)){ //如果字典中没有这样的对象池,则报错
			Debug.LogWarning("Cannot find pool" + type);
		}
		//从对象池中取一个对象返回
		GameObject returnObj = subPool.Alloc(lifetime);
		return returnObj;
	}

	public GameObject Alloc(GameObject obj, float lifetime = 0){
		ObjectPool subPool = null;
		string poolNameString = obj.name + "Pool"; //拼出对象池名字
		//先看看能不能取
		if(poolDic.TryGetValue(poolNameString,out subPool)){ //如果字典中已经有这种对象池
			return subPool.Alloc(lifetime);
		}else{//否则新创一个
			//生成type类型对象池的GameObject,它挂在ObjectPoolMgr层次下
			GameObject newPool = new GameObject(poolNameString);
			newPool.transform.parent = this.transform;
			//根据poolNameString 找到对应的对象池类,并添加到对象池GameObject上
			System.Type poolType = System.Type.GetType(poolNameString);
			subPool = (ObjectPool)newPool.AddComponent(poolType);
			if(subPool == null)
			//如果没有为此对象池实现一个类,那么挂载一个带有通用alloc和recycle方法的脚本
			subPool = newPool.AddComponent<CommonPool>() as ObjectPool;
			//传一些参数到新创建的对象池中
			subPool.objTypeString = obj.name;
			subPool.prefab = obj;
			subPool.preAllocCount = 5;
			subPool.autoIncreaseCount = 5;
			poolDic.Add(poolNameString,subPool);
			return subPool.Alloc(lifetime);
		}
	}
	
	public void Recycle(GameObject recycleObj){
		//根据对象的信息取出对应类型的对象池
		ObjectPool subPool;
		if(poolDic.TryGetValue(recycleObj.GetComponent<PrefabInfo>().types + "Pool",out subPool)){
			//往池中放入对象
			subPool.Recycle(recycleObj);
		}else{
			Debug.LogError("Fail to Recycle" + recycleObj.name);
		}

	}
}