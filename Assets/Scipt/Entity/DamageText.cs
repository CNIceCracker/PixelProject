using UnityEngine;
using System.Collections;

public class DamageText : MonoBehaviour {
    private Vector3 mTarget;
    private Vector3 mScreen;
    public int value;

    public float width=100;
    public float height=50;
    private Vector2 mPoint;
    public float freeTime=1f;
	// Use this for initialization
	void Start () {
        mTarget = this.transform.position;
        mScreen = Camera.main.WorldToScreenPoint(mTarget);
        mPoint = new Vector2(mScreen.x, Screen.height - mScreen.y);

        StartCoroutine("Free");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * 2f * Time.deltaTime);
	    mTarget=transform.position;
        mScreen=Camera.main.WorldToScreenPoint(mTarget);
        mPoint = new Vector2(mScreen.x-5, Screen.height - mScreen.y-30);
    }
    void OnGUI()
    {
        if (mScreen.z > 0)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 10;
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(mPoint.x, mPoint.y, width, height), value.ToString(),style);
        }

        
    }
    IEnumerator Free()
    {
        yield return new WaitForSeconds(freeTime);
        Destroy(this.gameObject);
    }
}
