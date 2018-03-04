using UnityEditor;
using UnityEngine;
using System;

namespace BeatThat
{
	[CustomEditor(typeof(BoolProperty), true)]
	[CanEditMultipleObjects]
	public class BoolPropertyEditor : UnityEditor.Editor
	{
		override public void OnInspectorGUI() 
		{
			var prop = this.target as BoolProperty;
			var valBefore = prop.value;
			EditorGUILayout.LabelField ("Value", (this.target as HasValue).valueObj + "");
			base.OnInspectorGUI();
			if (Application.isPlaying) {
				if (valBefore != prop.value) {
					prop.SetValue (prop.value, PropertyEventOptions.Force);
				}
			}
		}
	}
}