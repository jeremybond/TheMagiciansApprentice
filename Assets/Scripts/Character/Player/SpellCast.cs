//Created By: Jeremy Bond
//Date: 26/07/2016

using UnityEngine;

public class SpellCast : MonoBehaviour 
{
	private bool canCast = true;
	/// <summary>
	/// Update function that triggers the cast spell event when spacebar is pressed.
	/// </summary>
	protected void Update () 
	{
		if (canCast)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				EventManager.TriggerEvent(GeneralEvents.SPELLCAST);
				canCast = false;
				Invoke("EnableCast", .5f);
			}
		}
	}
	/// <summary>
	/// Function that enables casting again.
	/// </summary>
	private void EnableCast()
	{
		canCast = true;
	}
}
