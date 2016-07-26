//Created By: Jeremy Bond
//Date: 26/07/2016

using UnityEngine;
using System.Collections;

public class SpellCast : MonoBehaviour 
{
	/// <summary>
	/// Update function that triggers the cast spell event when spacebar is pressed.
	/// </summary>
	protected void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			EventManager.TriggerEvent(GeneralEvents.SPELLCAST);
		}
	}
}
