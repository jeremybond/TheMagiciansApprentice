//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
	public List<int> allChestData = new List<int> ();
	public string lastSavedLevel;
	public string saveFileName1;
	public string saveFileName2;
	public string saveFileName3;
	public int saveFile1;
	public int saveFile2;
	public int saveFile3;
	public int currentSaveID;
	private int fileQuestCount1;
	private int fileQuestCount2;
	private int fileQuestCount3;

	private Vector2 playerPosition;

	protected void Awake ()
	{
		saveFile1 = PlayerPrefs.GetInt (ConstStrings.FILEQUESTCOUNT + "1");
		saveFile2 = PlayerPrefs.GetInt (ConstStrings.FILEQUESTCOUNT + "2");
		saveFile3 = PlayerPrefs.GetInt (ConstStrings.FILEQUESTCOUNT + "3");
		saveFileName1 = PlayerPrefs.GetString (ConstStrings.FILENAME + "1");
		saveFileName2 = PlayerPrefs.GetString (ConstStrings.FILENAME + "2");
		saveFileName3 = PlayerPrefs.GetString (ConstStrings.FILENAME + "3");
	}

	/// <summary>
	/// Creates a new save file.
	/// </summary>
	/// <param name="saveFile"></param>
	protected void CreateFile (int saveFileID, string saveFileName)
	{
		PlayerPrefs.SetInt (ConstStrings.FILEQUESTCOUNT + saveFileID.ToString (), 1);
		PlayerPrefs.SetString (ConstStrings.FILENAME + saveFileID, saveFileName);
	}
	/// <summary>
	/// saves a file.
	/// </summary>
	/// <param name="saveFileID"></param>
	/// <param name="saveFileName"></param>
	protected void SaveFile (int saveFileID, string saveFileName)
	{
		// nothing happens here yet!!
	}
	/// <summary>
	/// Erases a save file.
	/// </summary>
	/// <param name="saveFile"></param>
	protected void EraseFile (int saveFileID, string saveFileName)
	{
		PlayerPrefs.DeleteKey (ConstStrings.FILEQUESTCOUNT + saveFileID.ToString ());
		PlayerPrefs.DeleteKey (ConstStrings.FILENAME + saveFileID.ToString());
	}

	/// <summary>
	/// When a game scene changes, it gets saved in the PlayerPrefs.
	/// </summary>
	protected void ChangeGameScene ()
	{
		PlayerPrefs.SetInt (ConstStrings.LASTPLAYEDSCENE + currentSaveID.ToString (), SceneManager.GetActiveScene ().buildIndex);
	}

	/// <summary>
	/// Adjusting files will trigger appointed functions.
	/// </summary>
	/// <param name="fileID"></param>
	protected void FileAdjustment (int fileID, string fileName, int eventNature)
	{
		if (eventNature == 1)//create
		{
			CreateFile (fileID, fileName);
		}
		else if (eventNature == 2)//save
		{
			SaveFile (fileID, fileName);
		}
		else if (eventNature == 3)//erase
		{
			EraseFile (fileID, fileName);
		}
	}

	/// <summary>
	/// OnEnable function add listener to EnterHouse event.
	/// </summary>
	protected void OnEnable ()
	{
		EventManager.AddListener (GeneralEvents.ENTERHOUSE, HouseEntered);
		EventManager.AddListener (GeneralEvents.CHANGEGAMESCENE, ChangeGameScene);
		EventManager.AddFileEventListener (FileAdjustment);
	}
	/// <summary>
	/// OnDisable function removes listener to EnterHouse event
	/// </summary>
	protected void OnDisable ()
	{
		EventManager.RemoveListener (GeneralEvents.ENTERHOUSE, HouseEntered);
		EventManager.RemoveListener (GeneralEvents.CHANGEGAMESCENE, ChangeGameScene);
		EventManager.RemoveFileEventListener (FileAdjustment);
	}
	/// <summary>
	/// HouseEntered function is callend when EnterHouse event is triggerd.
	/// </summary>
	private void HouseEntered ()
	{
		playerPosition = GameObject.FindGameObjectWithTag (ConstStrings.PLAYERTAG).transform.position;
		playerPosition -= new Vector2 (0, .5f);
		PlayerPrefs.SetFloat (ConstStrings.SAVEDPLAYERPOSITIONX + currentSaveID.ToString (), playerPosition.x);
		PlayerPrefs.SetFloat (ConstStrings.SAVEDPLAYERPOSITIONY + currentSaveID.ToString (), playerPosition.y);
	}
	/// <summary>
	/// OnLevelWasLoaded function gives the playerPosition variable a value if it has none.
	/// </summary>
	/// <param name="level"></param>
	protected void OnLevelWasLoaded (int level)
	{
		if (level == 0)
		{
			if (playerPosition == Vector2.zero)
			{
				playerPosition = GameObject.FindGameObjectWithTag (ConstStrings.PLAYERTAG).transform.position;
			}
		}
	}
}
