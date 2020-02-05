//Created By: Jeremy Bond
//Date: 02/02/2020

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	[SerializeField] private GameObject inGameUI;


	/// <summary>
	/// Adding the Listeners for ui changing events.
	/// </summary>
	protected void Awake () 
	{
		EventManager.AddListener(GeneralEvents.LOADGAME, EnableGameUI);
		EventManager.AddListener(GeneralEvents.QUITGAME, DisableGameUI);
	}

	/// <summary>
	/// Enable all the ui.
	/// </summary>
	protected void EnableGameUI ()
	{
		inGameUI.SetActive(true);
	}
	/// <summary>
	/// Disable all the ui.
	/// </summary>
	protected void DisableGameUI ()
	{
		inGameUI.SetActive (false);
	}
}
