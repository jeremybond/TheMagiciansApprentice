//Created By: Jeremy Bond
//Date: 02/02/2020

using UnityEngine;
using UnityEngine.UI;

public class FileButtonManager : MonoBehaviour 
{

	[SerializeField] private GameObject gameFileButtonOne;
	[SerializeField] private GameObject gameFileButtonTwo;
	[SerializeField] private GameObject gameFileButtonThree;
	[SerializeField] private GameObject gameCreationFileButtonOne;
	[SerializeField] private GameObject gameCreationFileButtonTwo;
	[SerializeField] private GameObject gameCreationFileButtonThree;
	[SerializeField] private GameObject EraseFileButtonOne;
	[SerializeField] private GameObject EraseFileButtonTwo;
	[SerializeField] private GameObject EraseFileButtonThree;

	private bool saveFileOneExists;
	private bool saveFileTwoExists;
	private bool saveFileThreeExists;
	private string saveFileNameOne;
	private string saveFileNameTwo;
	private string saveFileNameThree;

	/// <summary>
	/// Adds a file event listener for correct updating of the file buttons.
	/// Triggers the correction function when enabled.
	/// </summary>
	protected void Awake ()
	{
		EventManager.AddFileEventListener(FileEventTrigger);
		UpdateFileButtons();
	}
	/// <summary>
	/// Removes File event listener to prevent errors.
	/// </summary>
	protected void Disable ()
	{
		EventManager.RemoveFileEventListener(FileEventTrigger);
	}

	/// <summary>
	/// When it's a Create or Erase event, calling the update function.
	/// </summary>
	/// <param name="">fileID</param>
	/// <param name="">FileName</param>
	/// <param name="EventID"></param>
	protected void FileEventTrigger (int fileID, string fileName, int EventID)
	{
		if (EventID == 1 || EventID == 3)
		{
			UpdateFileButtons();
		}
	}

	/// <summary>
	/// Corrects the file buttons.
	/// </summary>
	protected void UpdateFileButtons ()
	{
		saveFileOneExists = (PlayerPrefs.GetInt (ConstStrings.FILEQUESTCOUNT + "1") > 0);
		saveFileTwoExists = (PlayerPrefs.GetInt (ConstStrings.FILEQUESTCOUNT + "2") > 0);
		saveFileThreeExists = (PlayerPrefs.GetInt (ConstStrings.FILEQUESTCOUNT + "3") > 0);
		saveFileNameOne = PlayerPrefs.GetString (ConstStrings.FILENAME + "1");
		saveFileNameTwo = PlayerPrefs.GetString (ConstStrings.FILENAME + "2");
		saveFileNameThree = PlayerPrefs.GetString (ConstStrings.FILENAME + "3");

		if (saveFileOneExists == true)
		{
			gameFileButtonOne.SetActive (true);
			gameFileButtonOne.GetComponentInChildren<Text> ().text = saveFileNameOne;
			EraseFileButtonOne.GetComponentInChildren<Text> ().text = "Erase " + saveFileNameOne;
			gameCreationFileButtonOne.SetActive (false);
		}
		else
		{
			gameFileButtonOne.SetActive (false);
			gameFileButtonOne.GetComponentInChildren<Text> ().text = saveFileNameOne;
			EraseFileButtonOne.GetComponentInChildren<Text> ().text = "Erase " + saveFileNameOne;
			gameCreationFileButtonOne.SetActive (true);
		}
		if (saveFileTwoExists == true)
		{
			gameFileButtonTwo.SetActive (true);
			gameFileButtonTwo.GetComponentInChildren<Text> ().text = saveFileNameTwo;
			EraseFileButtonTwo.GetComponentInChildren<Text> ().text = "Erase " + saveFileNameTwo;
			gameCreationFileButtonTwo.SetActive (false);
		}
		else
		{
			gameFileButtonTwo.SetActive (false);
			gameFileButtonTwo.GetComponentInChildren<Text> ().text = saveFileNameTwo;
			EraseFileButtonTwo.GetComponentInChildren<Text> ().text = "Erase " + saveFileNameTwo;
			gameCreationFileButtonTwo.SetActive (true);
		}
		if (saveFileThreeExists == true)
		{
			gameFileButtonThree.SetActive (true);
			gameFileButtonThree.GetComponentInChildren<Text> ().text = saveFileNameThree;
			EraseFileButtonThree.GetComponentInChildren<Text> ().text = "Erase " + saveFileNameThree;
			gameCreationFileButtonThree.SetActive (false);
		}
		else
		{
			gameFileButtonThree.SetActive (false);
			gameFileButtonThree.GetComponentInChildren<Text> ().text = saveFileNameThree;
			EraseFileButtonThree.GetComponentInChildren<Text> ().text = "Erase " + saveFileNameThree;
			gameCreationFileButtonThree.SetActive (true);
		}
	}
}
