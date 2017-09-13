using UnityEditor;
using UnityEngine;

namespace BeatThat
{
	[CustomEditor(typeof(ProxiesFloat), true)]
	[CanEditMultipleObjects]
	public class ProxiesFloatEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUI.BeginChangeCheck ();

			base.OnInspectorGUI();

			var drivenProp = this.serializedObject.FindProperty("m_driven");
			if(drivenProp.objectReferenceValue == this.target) {

				var changeTo = (target as ProxiesFloat).GetSiblingComponent<HasFloat>(true);

				Debug.LogWarning("ProxiesFloat.driven is pointing to self! change to " + ((changeTo != null)? changeTo.GetType().Name: "null"));
				drivenProp.objectReferenceValue = changeTo;
			}

			this.serializedObject.ApplyModifiedProperties();

			if (EditorGUI.EndChangeCheck ()) {
				(this.target as DisplaysFloat).UpdateDisplay();
			}
		}

		virtual protected void OnDisplaysFloatInspectorGUI() 
		{
			base.OnInspectorGUI();
		}
	}
}