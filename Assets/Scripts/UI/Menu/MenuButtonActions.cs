//Created By: Jeremy Bond
//Date: 02/02/2020

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class MenuButtonActions : MonoBehaviour
{
	private int newSaveID;
	private string newSaveName;
	private GameProgress gameProgress;
	[SerializeField] private Text newNameTextField;
	
	/// <summary>
	/// The required actions taken after pressing a save file.
	/// </summary>
	public void PlaySaveFile (int saveID)
	{
		if (PlayerPrefs.GetInt (ConstStrings.FILEQUESTCOUNT + saveID.ToString ()) != 0)
		{
			LoadLevel (saveID);
		}
	}

	/// <summary>
	/// This loads the level.
	/// </summary>
	public void LoadLevel (int ID)
	{
		if (PlayerPrefs.GetInt (ConstStrings.LASTPLAYEDSCENE + ID.ToString()) >= 1)
		{
			SceneManager.LoadScene (PlayerPrefs.GetInt (ConstStrings.LASTPLAYEDSCENE + ID.ToString()));
		}
		else
		{
			SceneManager.LoadScene(ConstStrings.TESTGAME);
			// the correct scene.
			//SceneManager.LoadScene (ConstStrings.GAMESCENE);
		}
		EventManager.TriggerEvent(GeneralEvents.LOADGAME);
	}
	/// <summary>
	/// Calls the create file function.
	/// </summary>
	/// <param name="fileName"></param>
	public void PressedCreateFile ()
	{
		newSaveName = newNameTextField.text;
		CreateSaveFile (newSaveID, newSaveName);
	}
	/// <summary>
	/// Calls the erase file function.
	/// </summary>
	/// <param name="fileName"></param>
	public void PressedEraseFile (int fileID)
	{
		EraseSaveFile(fileID);
	}
	/// <summary>
	/// Triggers a create file event and cleares out the newSaveID value;
	/// </summary>
	private void CreateSaveFile (int fileID, string fileName)
	{
		EventManager.TriggerFileEvent(fileID, fileName, 1);
		PlaySaveFile(fileID);
		newSaveID = 0;
		newSaveName = "";
	}
	/// <summary>
	/// Triggers an erase file event.
	/// </summary>
	/// <param name="fileID"></param>
	private void EraseSaveFile (int fileID)
	{
		EventManager.TriggerFileEvent(fileID, "", 3);
	}
	/// <summary>
	/// Remembers the ID for the new save file.
	/// </summary>
	/// <param name="saveID"></param>
	public void SetNewSaveID (int saveID)
	{
		newSaveID = saveID;
	}
}
