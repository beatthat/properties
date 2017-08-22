using UnityEngine;
using UnityEngine.Events;
using System;

namespace BeatThat
{
	public abstract class HasValue : MonoBehaviour, IHasValueObjChanged
	{
		/// <summary>
		/// TRUE if the impl class actually sends the onValueObjChanged event.
		/// </summary>
		abstract public bool sendsValueObjChanged { get; }


		/// <summary>
		/// A general-purpose event for value changed. 
		/// Most subclasses will have a specific value-changed event.
		/// The main case for the existence of this event is when you a component to have a Unity-Editor-configurable array
		/// of values, e.g. a FormatDrivesText wants an array of values and needs to know when a value changes.
		/// </summary>
		public UnityEvent onValueObjChanged { get { return m_onValueObjChanged?? (m_onValueObjChanged = new UnityEvent()); } }

		/// <summary>
		/// CONTRACT: subclasses that return sendsValueObjChanged TRUE must call this when their value changes.
		/// </summary>
		protected void SendValueObjChanged()
		{
			if(m_onValueObjChanged != null) {
				m_onValueObjChanged.Invoke();
			}
		}
		[NonSerialized]private UnityEvent m_onValueObjChanged;

		abstract public object valueObj { get; }
	}
}
