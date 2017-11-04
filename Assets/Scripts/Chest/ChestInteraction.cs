//Created By: Jeremy Bond
//Date: 04/04/2017

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ChestInteraction : MonoBehaviour
{
	private Chest chest;
	private SpriteRenderer render;
	[SerializeField]
	private int chestID;
	[SerializeField]
	private Sprite openedChest;
	[SerializeField]
	private Sprite closedChest;

	/// <summary>
	/// initialize the chest and give it his correct values.
	/// </summary>
	protected void Start ()
	{
		chest = new Chest();
		chest.ID = chestID;
		ChestProgress.chestProgress.AddChest (chest);

		chest.Opened = ChestProgress.chestProgress.allChestData.Count > 0 ? ChestProgress.chestProgress.allChestData[chest.ID -1].Opened : false;
		render = GetComponent<SpriteRenderer>();

		if (chest != null)
		{
			ChangeChestSprite();
		}
	}

	/// <summary>
	/// Call all the functions that are used to open the chest
	/// </summary>
	public void OpenChest()
	{
		chest.Opened = true;
		ChestProgress.chestProgress.OpenChest(chest.ID -1);
		ChangeChestSprite();
	}

	/// <summary>
	/// Change the image of the chest.
	/// </summary>
	public void ChangeChestSprite ()
	{
		if (chest.Opened)
		{
			render.sprite = openedChest;
		}
		else
		{
			render.sprite = closedChest;
		}
	}
}
