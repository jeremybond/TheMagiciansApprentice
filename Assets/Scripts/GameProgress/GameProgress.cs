//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class GameProgress : MonoBehaviour
{
	private Vector2 playerPosition;
	
	/// <summary>
	/// OnEnable function add listener to EnterHouse event.
	/// </summary>
	protected void OnEnable()
	{
		EventManager.AddListener(GeneralEvents.ENTERHOUSE, HouseEntered);
	}
	/// <summary>
	/// OnDisable function removes listener to EnterHouse event
	/// </summary>
	protected void OnDisable()
	{
		EventManager.RemoveListener(GeneralEvents.ENTERHOUSE, HouseEntered);
	}
	/// <summary>
	/// HouseEntered function is callend when EnterHouse event is triggerd.
	/// </summary>
	private void HouseEntered()
	{
		playerPosition = GameObject.FindGameObjectWithTag(ConstStrings.PLAYERTAG).transform.position;
		playerPosition -= new Vector2(0, .1f);
		PlayerPrefs.SetFloat("LastPlayerSavedPositionX", playerPosition.x);
		PlayerPrefs.SetFloat("LastPlayerSavedPositionY", playerPosition.y);
	}
	/// <summary>
	/// OnLevelWasLoaded function gives the playerPosition variable a value if it has none.
	/// </summary>
	/// <param name="level"></param>
	protected void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{
			if (playerPosition == Vector2.zero)
			{
				playerPosition = GameObject.FindGameObjectWithTag(ConstStrings.PLAYERTAG).transform.position;
			}
		}
	}
}
