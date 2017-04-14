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

	protected void Start ()
	{
		chest = new Chest();
		chest.ID = chestID;
		ChestProgress.chestProgress.AddChest (chest);
		chest.Opened = ChestProgress.chestProgress.allChestData.Count < 0 ? ChestProgress.chestProgress.allChestData[chest.ID].Opened : false;
		render = GetComponent<SpriteRenderer>();
		if (chest != null)
		{
			ChangeChestSprite();
		}
		print("chest id = " + chest.ID);
	}

	public void OpenChest()
	{
		print ("open chest function called");
		chest.Opened = true;
		ChestProgress.chestProgress.OpenChest(chest.ID);
		ChangeChestSprite();
	}

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
