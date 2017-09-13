using UnityEngine;
using UnityEngine.Events;

namespace BeatThat
{
	public abstract class HasClick : MonoBehaviour, IHasClick
	{
		public abstract bool interactable { get; set; }

		[System.Obsolete("use onClick UnityEvent")]
		public event System.Action Clicked;

		[SerializeField] private UnityEvent m_onClicked = new UnityEvent();
		public UnityEvent onClicked { get { return m_onClicked; } set { m_onClicked = value; } }

		protected void SendClickEvent()
		{
			#pragma warning disable 618
			if(this.Clicked != null) {
				Clicked();
			}
			#pragma warning restore 618

			this.onClicked.Invoke();
		}
	}
}
