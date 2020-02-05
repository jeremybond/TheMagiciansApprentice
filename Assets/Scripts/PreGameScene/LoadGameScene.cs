//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour 
{
	/// <summary>
	/// Awake function that loads the game scene directly.
	/// </summary>
	protected void Awake () 
	{
		SceneManager.LoadScene(ConstStrings.MAINMENUSCENE);
	}
}
