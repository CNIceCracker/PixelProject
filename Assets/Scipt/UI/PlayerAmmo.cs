using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAmmo : MonoBehaviour {

	private Text ammoText;
    private RangedWeapon wp;

    void Awake() {
        wp = PlayerController.instance.player.GetComponentInChildren<RangedWeapon>();
		ammoText = GetComponent<Text>();
        
    }

	void Update () {
		ammoText.text = wp.GetAmmoInfo();
	}
}
