using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public GameObject inventory;
	public GameObject craftTable;

	public static UIController instance = null; 
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			if(inventory.transform.localScale != Vector3.zero){
				inventory.transform.localScale = Vector3.zero;
			}else{
				inventory.transform.localScale = Vector3.one;
			}
		}
		if(Input.GetKeyDown(KeyCode.V)){
			if(craftTable.transform.localScale != Vector3.zero){
				craftTable.transform.localScale = Vector3.zero;
			}else{
				craftTable.transform.localScale = Vector3.one;
			}
		}
	}
}
