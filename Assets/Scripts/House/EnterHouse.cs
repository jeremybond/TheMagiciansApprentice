// Created by: Jeremy Bond
// Date: 06/06/2016

using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{
	[SerializeField] private string HouseSceneName;
	private int currentSaveID;

	protected void Awake ()
	{
		currentSaveID = PlayerPrefs.GetInt(ConstStrings.CURRENTSAVEDID);
	}

	/// <summary>
	/// The OnTrigger function is used to check when a player will enter the collider.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == ConstStrings.PLAYERTAG)
		{
			PlayerPrefs.SetInt(ConstStrings.PLAYERLIVES + currentSaveID.ToString (), PlayerStats.lives);
            EventManager.TriggerEvent(GeneralEvents.ENTERHOUSE);
			SceneManager.LoadScene (HouseSceneName);
		}
	}
}
