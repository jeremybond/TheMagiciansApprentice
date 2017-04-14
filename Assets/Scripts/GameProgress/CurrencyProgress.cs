//Created By: Jeremy Bond
//Date: 12/04/2017

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class CurrencyProgress : MonoBehaviour
{
	[SerializeField]
	private Text walletContent;
	public static CurrencyProgress chestProgress;

	public int currentWalletContent = 0;
	private int[] walletSizes = new int[] {200, 500, 999};
	public int walletSize = 200;
	private int currentWalletSize = 0;
	
	private const string SAVEPATH = "/playerCurrencyData.save";
	private const string CHESTTAG = "Chest";

	/// <summary>
	/// Adding the event listeners.
	/// </summary>
	protected void Awake () 
	{
		LoadWalletData();
		EventManager.AddAdjustWalletContentListener(ChangeWalletContent);
	}

	/// <summary>
	/// Change the content of the wallet
	/// </summary>
	/// <param name="amount">The changing amount.</param>
	public void ChangeWalletContent (int amount)
	{
		currentWalletContent += amount;
		UpdateWalletUI();
	}
	
	/// <summary>
	/// Update the wallet ui.
	/// </summary>
	private void UpdateWalletUI ()
	{
		walletContent.text = currentWalletContent.ToString();
	}

	/// <summary>
	/// the wallet is upgraded here.
	/// </summary>
	private void NextWallet ()
	{
		currentWalletSize ++;
		walletSize = walletSizes[currentWalletSize];
	}

	/// <summary>
	/// This function saves the current amount of money you have into the save file.
	/// </summary>
	public void SaveWalletData ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + SAVEPATH);

		CurrencyProgress data = new CurrencyProgress ();
		data.currentWalletContent = currentWalletContent;
		data.walletSize = currentWalletSize;

		bf.Serialize (file, data);
		file.Close ();
	}

	/// <summary>
	/// This function loads the last saved data you have into the game.
	/// </summary>
	public void LoadWalletData ()
	{
		if (File.Exists (Application.persistentDataPath + SAVEPATH))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + SAVEPATH, FileMode.Open);
			CurrencyProgress data = (CurrencyProgress) bf.Deserialize (file);
			file.Close ();

			currentWalletContent = data.currentWalletContent;
			currentWalletSize = data.walletSize;
			walletSize = walletSizes[currentWalletSize];
		}
		else
		{
			currentWalletContent = 0;
			walletSize = walletSizes[0];
		}
	}
}
