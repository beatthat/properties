using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Use a float to drive some display element and an update-display call will trigger when the property changes by script call or animation.
	/// Exposes the IHasFloat set_value interface, so this component can be used more easily in transitions (e.g. as an element of a TransitionsElements)
	/// </summary>
	public abstract class DisplaysFloat : HasFloat
	{
		
		[Range(0f, 1f)]
		public float m_value;
		public bool m_updateDisplayOnEnable;
		public bool m_applyChangesOnLateUpdate;

		public override float value 
		{
			get {
				return m_value;
			}
			set {
				m_value = value;
				if(this.gameObject.activeInHierarchy) {
					ScheduleUpdateDisplay();
				}
			}
		}

		public override bool sendsValueObjChanged { get { return false; } }

		// Analysis disable ConvertToAutoProperty
		virtual protected bool applyChangesOnLateUpdate { get { return m_applyChangesOnLateUpdate; } set { m_applyChangesOnLateUpdate = value; } }
		// Analysis restore ConvertToAutoProperty

		virtual protected void OnEnable()
		{
			if(m_updateDisplayOnEnable) {
				UpdateDisplay();
			}
		}

		protected void ScheduleUpdateDisplay()
		{
			if(this.applyChangesOnLateUpdate) {
				this.displayUpdatePending = true;
				return;
			}
			UpdateDisplay();
		}

		abstract public void UpdateDisplay();

		virtual protected void OnDidApplyAnimationProperties()
		{
			if(!this.gameObject.activeInHierarchy) {
				return;
			}
			ScheduleUpdateDisplay();
		}

		protected bool displayUpdatePending { get; set; }

		virtual protected void LateUpdate()
		{
			if(this.displayUpdatePending) {
				UpdateDisplay();
				this.displayUpdatePending = false;
			}
		}
	}
}
