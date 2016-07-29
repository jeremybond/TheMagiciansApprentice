//Created By: Jeremy Bond
//Date: 

using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour 
{
	[SerializeField] private Image lifeBar;
	private float lives;

	protected void Awake () 
	{
		lives = 100;
	}
	
	protected void Update () 
	{
		if (lives < PlayerStats.lives)
		{
			lives ++;
		}
		else if (lives > PlayerStats.lives)
		{
			lives --;
		}
		UpdateLifeBar(lives);
	}

	private void UpdateLifeBar (float amount)
	{
		lifeBar.fillAmount = amount / 100;
	}
}
