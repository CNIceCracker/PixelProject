using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHPValue : MonoBehaviour {
    private float maxHP;
    private float curHP;
    public Text HPText;
	// Use this for initialization
	void Start () {
        curHP = maxHP = GetComponentInParent<PlayerHP>().maxHP;
        HPText.text = ((int)curHP).ToString() + "/" + ((int)maxHP).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        curHP = GetComponentInParent<PlayerHP>().curHP;
        HPText.text = ((int)curHP).ToString() + "/" + ((int)maxHP).ToString();
        Debug.Log(maxHP);
	}
}
