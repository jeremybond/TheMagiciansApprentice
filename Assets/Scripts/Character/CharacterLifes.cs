//Created By: Jeremy Bond
//Date: 26/07/2016

using UnityEngine;
using System.Collections;

public class CharacterLifes : MonoBehaviour 
{
	private int maxLives = 100;
	public int lives = 100;
	
	/// <summary>
	/// OnDisable function that removes adjust life listeners.
	/// </summary>
	protected void OnDisable()
	{
		RemoveAdjustLifeListeners();
	}
	/// <summary>
	/// Function that increases the life.
	/// </summary>
	private void IncreaseLife(int adjustment)
	{
		lives += adjustment;
		if(lives > maxLives)
		{
			lives = maxLives;
		}
		RemoveAdjustLifeListeners();
	}
	/// <summary>
	/// Function that decreases the life.
	/// </summary>
	private void DecreaseLife(int adjustment)
	{
		lives -= adjustment;
		Debug.Log(lives);
		RemoveAdjustLifeListeners();
		CheckForDeath();
	}
	/// <summary>
	/// Function that checks when you are dead.
	/// </summary>
	private void CheckForDeath()
	{
		if(lives <= 0)
		{
			Debug.Log("died");
		}
	}
	/// <summary>
	/// When enter enemy collider add adjust life listener.
	/// </summary>
	/// <param name="col"></param>
	protected void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == ConstStrings.ENEMYTAG)
		{
			EventManager.AddAdjustLifeListener(DecreaseLife);
		}
	}
	/// <summary>
	/// When leave enemy collider remove adjust life listener.
	/// </summary>
	/// <param name="col"></param>
	protected void OnCollisionExit2D(Collision2D col)
	{
		if(col.transform.tag == ConstStrings.ENEMYTAG)
		{
			EventManager.RemoveAdjustLifeListener(DecreaseLife);
		}
	}
	/// <summary>
	/// When triggered by spell adds adjust life listeners.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == ConstStrings.SPELLTAG)
		{
			EventManager.AddAdjustLifeListener(DecreaseLife);
		}
		else if(col.transform.tag == ConstStrings.PICKUP)
		{
			EventManager.AddAdjustLifeListener(IncreaseLife);
		}
	}
	/// <summary>
	/// When triggered by spell removes adjust life listeners.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerExit2D(Collider2D col)
	{
		if (col.transform.tag == ConstStrings.SPELLTAG)
		{
			EventManager.RemoveAdjustLifeListener(DecreaseLife);
		}
		else if (col.transform.tag == ConstStrings.PICKUP)
		{
			EventManager.RemoveAdjustLifeListener(IncreaseLife);
		}
	}
	/// <summary>
	/// Function that removes all the ajust life listeners.
	/// </summary>
	private void RemoveAdjustLifeListeners()
	{
		EventManager.RemoveAdjustLifeListener(DecreaseLife);
		EventManager.RemoveAdjustLifeListener(IncreaseLife);
	}
}
