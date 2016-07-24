//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class GameProgress : MonoBehaviour
{
	private Vector2 playerPosition;

	protected void Awake()
	{
	}

	protected void OnEnable()
	{
		EventManager.AddListener(GeneralEvents.ENTERHOUSE, HouseEntered);
	}

	protected void OnDisable()
	{
		EventManager.RemoveListener(GeneralEvents.ENTERHOUSE, HouseEntered);
	}

	private void HouseEntered()
	{
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		playerPosition -= new Vector2(0, .1f);
		PlayerPrefs.SetFloat("LastPlayerSavedPositionX", playerPosition.x);
		PlayerPrefs.SetFloat("LastPlayerSavedPositionY", playerPosition.y);
	}

	protected void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{
			if (playerPosition == Vector2.zero)
			{
				playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			}
		}
	}
}
