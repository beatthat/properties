using UnityEngine;

namespace BeatThat
{

	public enum MissingComponentOptions { AddAndWarn = 0, CancelAndWarn = 1, Add = 2, Cancel = 3,  ThrowException = 4 }

	public static class PropertyExtensions
	{
		public static void SetBool<T>(this GameObject go, bool value,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn) where T : Component, IHasBool
		{
			go.transform.SetBool<T>(value, opts);
		}

		public static void SetBool<T>(this Component c, bool value,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn) where T : Component, IHasBool
		{
			var hasBool = c.GetComponent<T>();
			if(hasBool != null) {
				hasBool.value = value;
				return;
			}

			switch(opts) {
			case MissingComponentOptions.Add:
				hasBool = c.gameObject.AddComponent<T>();
				hasBool.value = value;
				break;
			case MissingComponentOptions.AddAndWarn:
				Debug.LogWarning("Adding missing component of type " + typeof(T).Name + " to " + c.Path());
				hasBool = c.gameObject.AddComponent<T>();
				hasBool.value = value;
				break;
			case MissingComponentOptions.CancelAndWarn:
				Debug.LogWarning("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
				break;
			case MissingComponentOptions.ThrowException:
				throw new MissingComponentException("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
			}
		}

		public static bool GetBool<T>(this GameObject go,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn, bool dftVal = false) where T : Component, IHasBool
		{
			return go.transform.GetBool<T>(opts, dftVal);
		}

		public static bool GetBool<T>(this Component c, MissingComponentOptions opts = MissingComponentOptions.AddAndWarn, bool dftVal = false) where T : Component, IHasBool
		{
			var hasBool = c.GetComponent<T>();
			if(hasBool != null) {
				return hasBool.value;
			}

			switch(opts) {
			case MissingComponentOptions.Add:
				hasBool = c.gameObject.AddComponent<T>();
				return hasBool.value;
			case MissingComponentOptions.AddAndWarn:
				Debug.LogWarning("Adding missing component of type " + typeof(T).Name + " to " + c.Path());
				hasBool = c.gameObject.AddComponent<T>();
				return hasBool.value;
			case MissingComponentOptions.CancelAndWarn:
				Debug.LogWarning("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
				return dftVal;
			default: // MissingComponentOptions.ThrowException:
				throw new MissingComponentException("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
			}
		}

		public static void SetFloat<T>(this GameObject go, float value,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn) where T : Component, IHasFloat
		{
			go.transform.SetFloat<T>(value, opts);
		}

		public static void SetFloat<T>(this Component c, float value,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn) where T : Component, IHasFloat
		{
			var hasFloat = c.GetComponent<T>();
			if(hasFloat != null) {
				hasFloat.value = value;
				return;
			}

			switch(opts) {
			case MissingComponentOptions.Add:
				hasFloat = c.gameObject.AddComponent<T>();
				hasFloat.value = value;
				break;
			case MissingComponentOptions.AddAndWarn:
				Debug.LogWarning("Adding missing component of type " + typeof(T).Name + " to " + c.Path());
				hasFloat = c.gameObject.AddComponent<T>();
				hasFloat.value = value;
				break;
			case MissingComponentOptions.CancelAndWarn:
				Debug.LogWarning("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
				break;
			case MissingComponentOptions.ThrowException:
				throw new MissingComponentException("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
			}
		}

		public static float GetFloat<T>(this GameObject go, MissingComponentOptions opts = MissingComponentOptions.AddAndWarn, float dftVal = 0) where T : Component, IHasFloat
		{
			return go.transform.GetFloat<T>(opts, dftVal);
		}

		public static float GetFloat<T>(this Component c, MissingComponentOptions opts = MissingComponentOptions.AddAndWarn, float dftVal = 0) where T : Component, IHasFloat
		{
			var hasFloat = c.GetComponent<T>();
			if(hasFloat != null) {
				return hasFloat.value;
			}

			switch(opts) {
			case MissingComponentOptions.Add:
				hasFloat = c.gameObject.AddComponent<T>();
				return hasFloat.value;
			case MissingComponentOptions.AddAndWarn:
				Debug.LogWarning("Adding missing component of type " + typeof(T).Name + " to " + c.Path());
				hasFloat = c.gameObject.AddComponent<T>();
				return hasFloat.value;
			case MissingComponentOptions.CancelAndWarn:
				Debug.LogWarning("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
				return dftVal;
			default: // MissingComponentOptions.ThrowException:
				throw new MissingComponentException("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
			}
		}

		public static void SetInt<T>(this GameObject go, int value,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn) where T : Component, IHasInt
		{
			go.transform.SetInt<T>(value, opts);
		}

		public static void SetInt<T>(this Component c, int value,
			MissingComponentOptions opts = MissingComponentOptions.AddAndWarn) where T : Component, IHasInt
		{
			var hasInt = c.GetComponent<T>();
			if(hasInt != null) {
				hasInt.value = value;
				return;
			}

			switch(opts) {
			case MissingComponentOptions.Add:
				hasInt = c.gameObject.AddComponent<T>();
				hasInt.value = value;
				break;
			case MissingComponentOptions.AddAndWarn:
				Debug.LogWarning("Adding missing component of type " + typeof(T).Name + " to " + c.Path());
				hasInt = c.gameObject.AddComponent<T>();
				hasInt.value = value;
				break;
			case MissingComponentOptions.CancelAndWarn:
				Debug.LogWarning("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
				break;
			case MissingComponentOptions.ThrowException:
				throw new MissingComponentException("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
			}
		}

		public static int GetInt<T>(this GameObject go, MissingComponentOptions opts = MissingComponentOptions.AddAndWarn, int dftVal = 0) where T : Component, IHasInt
		{
			return go.transform.GetInt<T>(opts, dftVal);
		}

		public static int GetInt<T>(this Component c, MissingComponentOptions opts = MissingComponentOptions.AddAndWarn, int dftVal = 0) where T : Component, IHasInt
		{
			var hasInt = c.GetComponent<T>();
			if(hasInt != null) {
				return hasInt.value;
			}

			switch(opts) {
			case MissingComponentOptions.Add:
				hasInt = c.gameObject.AddComponent<T>();
				return hasInt.value;
			case MissingComponentOptions.AddAndWarn:
				Debug.LogWarning("Adding missing component of type " + typeof(T).Name + " to " + c.Path());
				hasInt = c.gameObject.AddComponent<T>();
				return hasInt.value;
			case MissingComponentOptions.CancelAndWarn:
				Debug.LogWarning("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
				return dftVal;
			default: // MissingComponentOptions.ThrowException:
				throw new MissingComponentException("Failed to set property on " + c.Path() + " due to missing component of type " + typeof(T).Name);
			}
		}

		/// <summary>
		/// For the case that there 0, 1, or multiple drivers for some component T,
		/// find the 'root' driver.
		/// In the case of multiple drivers, any driver that is in turn driven by another driver is not the root.
		/// </summary>
		/// <returns>The root driver.</returns>
		/// <param name="thisComp">C.</param>
		/// <param name="excludeSelf">if TRUE, always exclude the calling component</param>
		/// <typeparam name="T">The driven type</typeparam>
		public static T GetRootDriver<T>(this Component thisComp, bool excludeSelf = true) where T : class
		{
			using(var list = ListPool<T>.Get()) {
				thisComp.GetComponents<T>(list, true);

				if(list.Count == 0) {
					return null;
				}

				if(excludeSelf) {
					for(int i = list.Count - 1; i > 0; i--) {
						if(object.ReferenceEquals(thisComp, list[i])) {
							list.RemoveAt(i);
						}
					}
				}

				if(list.Count == 1) {
					return list[0];
				}


				using(var tmp = ListPool<T>.Get()) {
					tmp.AddRange(list);

					foreach(var t in list) {
						var d = t as IDrive;
						if(d == null) {
							continue;
						}

						var driven = d.GetDrivenObject() as T;
						if(driven != null) {
							tmp.Remove(driven);
						}
					}

					if(tmp.Count > 0) {
						return tmp[0];
					}
				}
			}
			return null;
		}

	}
}
