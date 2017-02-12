using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    public Slider HPSlider;
    public float maxHP;
    public float curHP;
    public GameObject player;
	// Use this for initialization
    void Awake()
    {
        curHP = maxHP = player.GetComponent<Fightable>().maxHealth;
        HPSlider.value = HPSlider.maxValue = maxHP;
    }
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        curHP = player.GetComponent<Fightable>().GetHealth();
        HPSlider.value = curHP; 
	}

}
