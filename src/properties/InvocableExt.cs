using UnityEngine;

namespace BeatThat
{
	public static class InvocableExt
	{
		/// <summary>
		/// ext method lets you call a sibling <c>Invocable</c> like this:
		/// 
		/// <c>
		/// this.Invoke<MyInvocableComp>();
		/// </c>
		/// </summary>
		public static void Invoke<T>(this Component c,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn) where T : Component, Invocable
		{
			if(c == null) {
				Debug.LogWarning("Invoke " + typeof(T) + " called on null component");
				return;
			}

			var invocable = c.GetComponent<T>();
			if(invocable != null) {
				invocable.Invoke();
				return;
			}

			switch(opts) {
			case MissingComponentOptions.Add:
				invocable = c.gameObject.AddComponent<T>();
				invocable.Invoke();
				break;
			case MissingComponentOptions.AddAndWarn:
				Debug.LogWarning("Adding missing component of type " + typeof(T).Name + " to " + c.Path());
				invocable = c.gameObject.AddComponent<T>();
				invocable.Invoke();
				break;
			case MissingComponentOptions.CancelAndWarn:
				Debug.LogWarning("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
				break;
			case MissingComponentOptions.ThrowException:
				throw new MissingComponentException("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
			}
		}
	}
}
