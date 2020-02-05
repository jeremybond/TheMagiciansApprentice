//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class SetLoadInSettings : MonoBehaviour
{
	private Transform playerTransform;
	private int playerLives;
	private int currentSaveID;

	protected void Awake ()
	{
		currentSaveID = PlayerPrefs.GetInt(ConstStrings.CURRENTSAVEDID);
	}


	/// <summary>
	/// OnLevelLoaded function that is called when a level is loaded sets player position at last entered house.
	/// </summary>
	/// <param name="level"></param>
	protected void OnLevelWasLoaded(int level)
	{
		if (level > 1)
		{
			PlayerPrefs.SetInt(ConstStrings.PLAYERLIVES + currentSaveID.ToString (), PlayerStats.lives);
			if (playerTransform == null)
			{
				playerTransform = GameObject.FindGameObjectWithTag(ConstStrings.PLAYERTAG).transform;
			}
			if (level == 0)
			{
				Vector2 lastPlayerPos;
				lastPlayerPos.x = PlayerPrefs.GetFloat(ConstStrings.SAVEDPLAYERPOSITIONX + currentSaveID.ToString ());
				lastPlayerPos.y = PlayerPrefs.GetFloat(ConstStrings.SAVEDPLAYERPOSITIONY + currentSaveID.ToString ());

				playerTransform.position = lastPlayerPos;
			}
		}
	}
}
