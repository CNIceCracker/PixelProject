using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(DamageData))]  
public class DamageDataDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {  
		EditorGUI.BeginProperty(position, label, property);  
		 
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);  

		int indent = EditorGUI.indentLevel;  
		EditorGUI.indentLevel = 0;  

		Rect statusRect = new Rect(position.x, position.y, 90, position.height);  
		Rect valueRect = new Rect(position.x + 120, position.y, 100, position.height);  

		EditorGUI.PropertyField(statusRect, property.FindPropertyRelative("status"), GUIContent.none);  
		EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);   

		EditorGUI.indentLevel = indent;  
		
		EditorGUI.EndProperty();  
	}
}
