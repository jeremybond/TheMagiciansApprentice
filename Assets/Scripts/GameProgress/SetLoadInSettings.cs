//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class SetLoadInSettings : MonoBehaviour
{
	private Transform playerTransform;

	/// <summary>
	/// OnLevelLoaded function that is called when a level is loaded sets player position at last enterd house.
	/// </summary>
	/// <param name="level"></param>
	protected void OnLevelWasLoaded(int level)
	{
		if (playerTransform == null)
		{
			playerTransform = GameObject.FindGameObjectWithTag(ConstStrings.PLAYERTAG).transform;
		}
		if (level == 0)
		{
			Vector2 lastPlayerPos;
			lastPlayerPos.x = PlayerPrefs.GetFloat("LastPlayerSavedPositionX");
			lastPlayerPos.y = PlayerPrefs.GetFloat("LastPlayerSavedPositionY");

			playerTransform.position = lastPlayerPos;
		}
	}
}
