//Created By: Jeremy Bond
//Date: 

using UnityEngine;
using System.Collections.Generic;

public class InGameMenuManager : MonoBehaviour 
{
	private GameObject menu;
	[SerializeField]
	private GameObject blackground;
	[SerializeField]
	private GameObject rowContainer;
	[SerializeField]
	private GameObject firstRow;
	[SerializeField]
	private GameObject spellSelection;
	[SerializeField]
	private GameObject inventory;
	[SerializeField]
	private GameObject questLog;
	[SerializeField]
	private GameObject relationships;
	[SerializeField]
	private GameObject wearables;
	[SerializeField]
	private GameObject settings;
	[SerializeField]
	private GameObject save;
	
	private List<GameObject> firstRowButtons = new List<GameObject>();
	private List<GameObject> currentRowList = new List<GameObject>();
	private GameObject currentRow;

	private int firstButton = 1;
	private int currentRowCount = 0;
	private int[] buttonSelected = new int[2];
	private int currentLayerButtonCount;

	private int buttonDifference = 52;
	private int rowDifference = 200;

	
	protected void Awake ()
	{
		menu = this.gameObject;
		for (int i = 0; i < buttonSelected.Length; i++)
		{
			buttonSelected[i] = firstButton;
		}
		currentRowList.Add(firstRow);
		currentRow = currentRowList[currentRowCount];
		currentLayerButtonCount = currentRow.transform.childCount;
		if (rowContainer && blackground && firstRow && spellSelection && inventory && questLog && relationships && wearables && settings && save)
		{
			ExitMenu ();
			for (int i = 0; i < rowContainer.transform.childCount; i++)
			{
				firstRowButtons.Add (rowContainer.transform.GetChild (i).gameObject);
			}
		}
		else
		{
			throw new System.ArgumentException("No object serialized in a slot. IngameMenuManager script requires objects, found on 'InGameMenu'");
		}
	}

	/// <summary>
	/// Checking for any interaction with the menu.
	/// </summary>
	protected void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape))
		{
			if (currentRowCount > 0)
			{
				MoveRowDown();
			}
			else
			{
				if (blackground.activeSelf)
				{
					ExitMenu();
				}
				else
				{
					OpenMenu();
				}
			}
		}
		if (rowContainer.activeSelf)
		{
			if (Input.GetKeyDown (KeyCode.W) && buttonSelected[currentRowCount] > firstButton)
			{
				
				MoveLayerDown ();Debug.Log(currentLayerButtonCount + " = button count | buttonselected =  " + buttonSelected[currentRowCount]);
			}
			if (Input.GetKeyDown (KeyCode.S) && buttonSelected[currentRowCount] < currentLayerButtonCount)
			{
				MoveLayerUp ();
				Debug.Log (currentLayerButtonCount + " = button count | buttonselected =  " + buttonSelected[currentRowCount]);
				
			}
			if (Input.GetKeyUp (KeyCode.Space))
			{
				if (currentRowCount == 0)
				{
					MoveRowUp(rowContainer.transform.GetChild(buttonSelected[currentRowCount] - firstButton).gameObject);
				}
				else
				{
					//Add specific other actions for indept menu
				}
			}
		}
	}

	/// <summary>
	/// Activating the menu.
	/// </summary>
	public void OpenMenu ()
	{
		for (int i = 0; i < menu.transform.childCount; i++)
		{
			menu.transform.GetChild(i).gameObject.SetActive(true);
		}
		ResetLayerPosition ();
		EventManager.TriggerEvent(GeneralEvents.OPENMENU);
	}

	/// <summary>
	/// Closing the menu.
	/// </summary>
	public void ExitMenu ()
	{
		for (int i = 0; i < menu.transform.childCount; i++)
		{
			menu.transform.GetChild(i).gameObject.SetActive(false);
		}
		EventManager.TriggerEvent(GeneralEvents.CLOSEMENU);
	}

	/// <summary>
	/// Resetting the layer to the beginning.
	/// </summary>
	public void ResetLayerPosition ()
	{
		Debug.Log(buttonSelected[currentRowCount] + " The current button selected");
		for (int j = firstButton; j < buttonSelected[currentRowCount];)
		{
			MoveLayerDown();
			Debug.Log(j + " times move layer down called");
		}
	}

	/// <summary>
	/// All actions required to move to the next row happen here.
	/// </summary>
	/// <param name="nextLayer"></param>
	public void MoveRowUp (GameObject nextLayer)
	{
		MoveObject (-rowDifference, 0);
		currentRowList.Add(nextLayer);

		currentRowCount++;
		currentRow = nextLayer;
		currentLayerButtonCount = nextLayer.transform.childCount;
		Debug.Log(currentLayerButtonCount +" = CurrentLayerButtonCount");
		nextLayer.SetActive(true);
	}

	/// <summary>
	/// All actions required to move to the previous row happen here.
	/// </summary>
	public void MoveRowDown ()
	{
		ResetLayerPosition();
		currentRowList.RemoveAt(currentRowCount);
		currentRowCount --;
		currentRow.SetActive(false);
		currentRow = currentRowList[currentRowCount];
		currentLayerButtonCount = currentRow.transform.childCount;
		MoveObject (rowDifference, 0);
	}

	/// <summary>
	/// All actions required to move up the current layer happen here.
	/// </summary>
	protected void MoveLayerUp ()
	{
		MoveObject(0, buttonDifference);
		buttonSelected[currentRowCount]++;
	}

	/// <summary>
	/// All the actions required to move down the current layer happen here.
	/// </summary>
	protected void MoveLayerDown ()
	{
		MoveObject (0, -buttonDifference);
		buttonSelected[currentRowCount]--;
	}

	/// <summary>
	/// A function to move objects, meant for rows and layers.
	/// </summary>
	/// <param name="x">The added horizontal value.</param>
	/// <param name="y">the added vertical value.</param>
	protected void MoveObject (int x, int y)
	{
		currentRow.transform.position += new Vector3( x, y, 0);
	}
}
