//Created By: Jeremy Bond
//Date: 04/04/2017

using System;

[Serializable]
public class Chest
{
	public int ID;
	public bool Opened;

	public void Open ()
	{
		Opened = true;
	}
}
