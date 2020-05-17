//Created By: Jeremy Bond
//Date: 02/02/2020

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public static bool inGameMenuActive = false;

	[SerializeField] private GameObject inGameUI;


	/// <summary>
	/// Adding the Listeners for ui changing events.
	/// </summary>
	protected void Awake () 
	{
		EventManager.AddListener(GeneralEvents.LOADGAME, EnableGameUI);
		EventManager.AddListener(GeneralEvents.QUITGAME, DisableGameUI);
		EventManager.AddListener(GeneralEvents.OPENMENU, EnableGameMenuUI);
		EventManager.AddListener(GeneralEvents.CLOSEMENU, DisableGameMenuUI);
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

	/// <summary>
	/// Enables the menu UI.
	/// </summary>
	protected void EnableGameMenuUI ()
	{
		inGameMenuActive = true;
	}
	/// <summary>
	/// Disables the menu UI.
	/// </summary>
	protected void DisableGameMenuUI ()
	{
		inGameMenuActive = false;
	}
}
