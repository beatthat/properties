﻿using UnityEditor;
using UnityEngine;
using System;

namespace BeatThat
{
	[CustomEditor(typeof(FloatProperty), true)]
	[CanEditMultipleObjects]
	public class FloatPropertyEditor : UnityEditor.Editor
	{
		override public void OnInspectorGUI() 
		{
			var prop = this.target as FloatProperty;
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