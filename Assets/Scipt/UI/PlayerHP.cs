using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
	public Text HPText;

    private float maxHP;
    private float curHP;

	private Slider HPSlider;
	private Fightable fightable;

    void Awake()
    {
		fightable = PlayerController.instance.player.GetComponent<Fightable>();
		HPSlider = GetComponent<Slider>();
		maxHP = fightable.maxHealth;
		HPSlider.maxValue = maxHP;
		curHP = maxHP;
    }

	void Update () {
		curHP = fightable.GetHealth();
        HPSlider.value = curHP; 
		HPText.text = ((int)curHP).ToString() + "/" + ((int)maxHP).ToString();
	}

}
