//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHouse : MonoBehaviour
{
	/// <summary>
	/// The OnTrigger function is used to check when a player will exit the collider.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == ConstStrings.PLAYERTAG)
		{
			SceneManager.LoadScene(ConstStrings.MAINSCENENAME);
		}
	}
}
