using UnityEngine;
using System.Collections;

public class ShowAmmo : MonoBehaviour {

    private Vector3 mTarget;
    private Vector3 mScreen;
    public float width = 20;
    public float height = 20;
    private Vector2 mPoint;

    //武器信息
    RangedWeapon wp;
    public int curAmmo;
    public int curMagazine;


    // Use this for initialization
    void Start()
    {
        wp = GetComponentInChildren<RangedWeapon>();         
    }

    // Update is called once per frame
    void Update()
    {
        wp.GetAmmoInfo(ref curAmmo,ref curMagazine);
    }
    void OnGUI()
    {
            GUIStyle style = new GUIStyle();
            style.fontSize = 20;
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width-190, Screen.height-70, width, height),"Ammo " +curMagazine.ToString(), style);
            GUI.Label(new Rect(Screen.width - 100, Screen.height - 70, width, height), "/ " + curAmmo.ToString(), style);
    }
}
