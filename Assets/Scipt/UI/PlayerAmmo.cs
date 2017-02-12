using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAmmo : MonoBehaviour {
    public GameObject player;
    public int curAmmo;
    public int curMagazine;
    public Text AmmoText;

    private RangedWeapon wp;
	// Use this for initialization
    void Awake() 
    {
        wp = player.GetComponentInChildren<RangedWeapon>();
        wp.GetAmmoInfo(ref curAmmo, ref curMagazine);
    }
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        wp.GetAmmoInfo(ref curAmmo, ref curMagazine);
        AmmoText.text = "Ammo " + curMagazine + "/" + curAmmo;
        
	}
}
