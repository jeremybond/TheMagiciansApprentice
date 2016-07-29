//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class SetLoadInSettings : MonoBehaviour
{
	private Transform playerTransform;
	private int playerLives;

	/// <summary>
	/// OnLevelLoaded function that is called when a level is loaded sets player position at last enterd house.
	/// </summary>
	/// <param name="level"></param>
	protected void OnLevelWasLoaded(int level)
	{
		PlayerPrefs.SetInt(ConstStrings.PLAYERLIVES, PlayerStats.lives);
		if (playerTransform == null)
		{
			playerTransform = GameObject.FindGameObjectWithTag(ConstStrings.PLAYERTAG).transform;
		}
		if (level == 0)
		{
			Vector2 lastPlayerPos;
			lastPlayerPos.x = PlayerPrefs.GetFloat(ConstStrings.SAVEDPLAYERPOSITIONX);
			lastPlayerPos.y = PlayerPrefs.GetFloat(ConstStrings.SAVEDPLAYERPOSITIONY);

			playerTransform.position = lastPlayerPos;
		}
	}
}
