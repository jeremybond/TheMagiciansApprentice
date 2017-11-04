//Created By: Jeremy Bond
//Date: 04/04/2017

using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ChestProgress : MonoBehaviour
{
	public static ChestProgress chestProgress;

	public List<Chest> allChestData = new List<Chest> ();

	private const string SAVEPATH = "/playerChestData.save";
	private const string CHESTTAG = "Chest";

	protected void Awake ()
	{
		chestProgress = this;
		LoadChestData ();
	}

	/// <summary>
	/// This function saves the current data you have into the save file.
	/// </summary>
	public void SaveChestData ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + SAVEPATH);

		ChestDataFile data = new ChestDataFile ();
		data.chestCount = allChestData.Count;
		data.allChests = allChestData;

		bf.Serialize (file, data);
		file.Close ();
		print ("save current chest statuses");
	}

	/// <summary>
	/// This function loads the last saved data you have into the game.
	/// </summary>
	public void LoadChestData ()
	{
		if (File.Exists (Application.persistentDataPath + SAVEPATH))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + SAVEPATH, FileMode.Open);
			ChestDataFile data = (ChestDataFile) bf.Deserialize (file);
			file.Close ();

			allChestData = data.allChests;
			print ("load current chest statuses");
		}
		else
		{
			allChestData = new List<Chest> ();
		}
	}

	/// <summary>
	/// this is only for test purposes, it lets me access the erase game data function quickly.
	/// </summary>
	protected void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F12))
		{
			EraseChestData();
		}
	}

	/// <summary>
	/// This function removes the current or selected save data.
	/// </summary>
	public void EraseChestData ()
	{
		if (File.Exists (Application.persistentDataPath + SAVEPATH))
		{
			File.Delete(Application.persistentDataPath + SAVEPATH);
		}
	}
	
	/// <summary>
	/// This is adding a new chest to the current list and checking if the current id isnt used allready.
	/// </summary>
	/// <param name="c"></param>
	public void AddChest (Chest c)
	{
		bool newChest = true;
		for (int i = 0; i < allChestData.Count; i++)
		{
			if (c.ID == allChestData[i].ID)
			{
				newChest = false;
				return;
			}
			else if (c.ID == 0)
			{
				Debug.LogError ("Last implemented chest ID is not given yet.");
			}
		}
		if (newChest)
		{
			allChestData.Add (c);
			SaveChestData ();
			return;
		}
	}

	/// <summary>
	/// When a chest gets opened. here the data will update, it will not get saved here.
	/// </summary>
	/// <param name="id"></param>
	public void OpenChest (int id)
	{
		allChestData[id].Open ();
		SaveChestData ();
	}
}

[Serializable]
class ChestDataFile
{
	public int chestCount;
	public List<Chest> allChests;
}
