/*using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(DamageValue))] 
[ExecuteInEditMode]  
public class DamageValueEditor : Editor {
	DamageValue damageValue = new DamageValue();
	public override void OnInspectorGUI(){
		damageValue.AddDamage(DamageStatusEffect.None,100);
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("None");
		damageValue.AddDamage(DamageStatusEffect.None,EditorGUILayout.FloatField(damageValue[DamageStatusEffect.None]));
		EditorGUILayout.EndHorizontal();

		base.DrawDefaultInspector();
	}
}*/