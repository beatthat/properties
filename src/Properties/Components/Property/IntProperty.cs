using UnityEngine.Events;
using UnityEngine;


namespace BeatThat
{
	public class IntProperty : IntProp
	{
		public int m_value; // TODO: this shouldn't be public but good to see in Inspector. Move to editor class.

		override protected int GetValue() { return m_value; }
		override protected void _SetValue(int s) { m_value = s; }
	}

	public abstract class IntProp : HasInt, IHasValueChangedEvent<int>
	{
		public bool m_debug;
		public bool m_debugBreakOnSetValue;

		public UnityEvent<int> onValueChanged 
		{ 
			get { return m_onValueChanged?? (m_onValueChanged = new IntEvent()); } 
			set { m_onValueChanged = value; } 
		}
		[SerializeField]protected UnityEvent<int> m_onValueChanged;

		override public int value
		{ 
			get { return GetValue(); }
			set { SetValue(value); } 
		}
			
		override public object valueObj { get { return this.value; } }

		abstract protected int GetValue();
		abstract protected void _SetValue(int s);

		override public bool sendsValueObjChanged { get { return true; } }

		protected void SendValueChanged(int val)
		{
			SendValueObjChanged();
			if(m_onValueChanged != null) {
				m_onValueChanged.Invoke(val);
			}
		}

		protected void SetValue(int val, PropertyEventOptions opts = PropertyEventOptions.SendOnChange)
		{
			#if BT_DEBUG_UNSTRIP || UNITY_EDITOR
			if(m_debug) {
				Debug.Log("[" + Time.frameCount + "][" + this.Path() + "] " + GetType() + "::set_value to " + val);
			}
			#endif

			if(val == GetValue() && opts != PropertyEventOptions.Force) {
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
