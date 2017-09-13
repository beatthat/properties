using UnityEditor;

namespace BeatThat
{
	[CustomEditor(typeof(DisplaysFloat), true)]
	[CanEditMultipleObjects]
	public class DisplaysFloatEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUI.BeginChangeCheck ();

			OnDisplaysFloatInspectorGUI();

			if (EditorGUI.EndChangeCheck ()) {
				(this.target as DisplaysFloat).UpdateDisplay();
			}
		}

		virtual protected void OnDisplaysFloatInspectorGUI() 
		{
			base.OnInspectorGUI();
		}

		protected void DrawDisplaysFloatProperties()
		{
			var valueProp = this.serializedObject.FindProperty("m_value");
			var updateDisplayOnEnableProp = this.serializedObject.FindProperty("m_updateDisplayOnEnable");
			var applyChangesOnLateUpdate = this.serializedObject.FindProperty("m_applyChangesOnLateUpdate");

			EditorGUILayout.PropertyField(valueProp);
			EditorGUILayout.PropertyField(updateDisplayOnEnableProp);
			EditorGUILayout.PropertyField(applyChangesOnLateUpdate);
		}
	}
}