using UnityEngine.Events;
using UnityEngine;


namespace BeatThat
{
	public class FloatProperty : FloatProp
	{
		public float m_value; // TODO: this shouldn't be public but good to see in Inspector. Move to editor class.

		override protected float GetValue() { return m_value; }
		override protected void _SetValue(float s) { m_value = s; }
	}

	public abstract class FloatProp : HasFloat, IHasValueChangedEvent<float>
	{
		public bool m_debug;
		public bool m_debugBreakOnSetValue;

		public UnityEvent<float> onValueChanged 
		{ 
			get { return m_onValueChanged?? (m_onValueChanged = new FloatEvent()); } 
			set { m_onValueChanged = value; } 
		}
		[SerializeField]protected UnityEvent<float> m_onValueChanged;

		override public float value
		{ 
			get { return GetValue(); }
			set { SetValue(value); } 
		}
			
		override public object valueObj { get { return this.value; } }

		abstract protected float GetValue();
		abstract protected void _SetValue(float s);

		override public bool sendsValueObjChanged { get { return true; } }

		protected void SendValueChanged(float val)
		{
			SendValueObjChanged();
			if(m_onValueChanged != null) {
				m_onValueChanged.Invoke(val);
			}
		}

		protected void SetValue(float val, PropertyEventOptions opts = PropertyEventOptions.SendOnChange)
		{
			#if BT_DEBUG_UNSTRIP || UNITY_EDITOR
			if(m_debug) {
				Debug.Log("[" + Time.frameCount + "][" + this.Path() + "] " + GetType() + "::set_value to " + val);
			}
			#endif

			if(Mathf.Approximately(val, GetValue()) && opts != PropertyEventOptions.Force) {
				return;
			}

			_SetValue(val);

			#if UNITY_EDITOR
			if(m_debugBreakOnSetValue) {
				Debug.LogWarning("[" + Time.frameCount + "][" + this.Path() + "] " + GetType() + "::set_value to " + val + " BREAK ON SET VALUE is enabled");
				Debug.Break();
			}
			#endif

			if(opts != PropertyEventOptions.Disable) {
				SendValueChanged(val);
			}
		}
	}

}
