//Created By: Jeremy Bond
//Date: 26/07/2016

using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static bool died = false;
	public static int lives;

	/// <summary>
	/// The OnEnable function adds the listeners from the events.
	/// </summary>
	protected void OnEnable ()
	{
		EventManager.AddListener(GeneralEvents.DIED, Died);
	}
	/// <summary>
	/// The Ondisable function removes the listeners from the events.
	/// </summary>
	protected void OnDisable ()
	{
		EventManager.RemoveListener(GeneralEvents.DIED, Died);
	}
	/// <summary>
	/// Function that set died to true;
	/// </summary>
	private void Died ()
	{
		died = true;
	}
}
