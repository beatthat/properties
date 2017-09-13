using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// A component that proxies andother HasFloat
	/// Gets a special base class to make sure that when you drag 'driven' in the inspector
	/// that it doesn't end of driving itself
	/// </summary>
	public abstract class ProxiesFloat : DisplaysFloat, IDrive<HasFloat>
	{
		public HasFloat m_driven;

		[Tooltip("set FALSE if you want to leave driven null or similar")]
		public bool m_findDrivenSibling = true;

		#region IDrive implementation

		public HasFloat driven 
		{ 
			get { 
				if(m_driven == null) {
					using(var hasFloats = ListPool<HasFloat>.Get()) {
						GetComponents<HasFloat>(hasFloats);
						foreach(var hf in hasFloats) {
							if(hf == this) {
								continue;
							}
							m_driven = hf;
							break;
						}
					}
				}
				return m_driven;
			}
		}

		public object GetDrivenObject() { return this.driven; }

		#endregion

		#if UNITY_EDITOR
		void OnValidate()
		{
			if(object.ReferenceEquals(m_driven, this)) {
				m_driven = null;
			}

			if(m_driven == null && m_findDrivenSibling) {
				m_driven = this.GetSiblingComponent<HasFloat>(true); // TODO: maybe need a special inspector that cycles through options?
			}
		}
		#endif
	}
}
