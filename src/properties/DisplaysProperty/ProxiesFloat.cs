using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// A component that proxies another HasFloat
	/// Gets a special base class to make sure that when you drag 'driven' in the inspector
	/// that it doesn't end of driving itself
	/// </summary>
	public abstract class ProxiesFloat : DisplaysFloat, IDrive<HasFloat>
	{
		[HideInInspector]public HasFloat m_driven;

		override protected void OnEnable()
		{
			base.OnEnable();
			if(m_driven == null) {
				m_driven = this.FindNonCircularTarget();
			}
		}

		public HasFloat driven { get { return m_driven; } }

		public object GetDrivenObject() { return this.driven; }

		public bool ClearDriven() { m_driven = null; return true; }

		#if UNITY_EDITOR
		virtual protected void Reset()
		{
			m_driven = this.FindNonCircularTarget();
		}
		#endif
	}
}
