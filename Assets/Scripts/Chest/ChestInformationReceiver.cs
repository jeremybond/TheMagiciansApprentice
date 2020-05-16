//Created By: Jeremy Bond
//Date: 

using UnityEngine;
using System.Collections;
using System;
using Mono.Data.Sqlite;
using System.Data;

[RequireComponent (typeof(ChestInteraction))]
public class ChestInformationReceiver : MonoBehaviour 
{
	bool[] getCurrency;
	bool[] locked;
	int[] currencyGained;
	string[] itemTypeGained;
	string[] itemGained;

	string connectionString;// = "URI=file:" + Application.dataPath + "/Plugins/ChestInformation.db";
	string commandString = "SELECT * " + "FROM ";
	string table1 = "ChestType";
	string table2 = "MoneyChestContent";
	string table3 = "ItemChestContent";

	SqliteConnection conn;
	SqliteCommand command;

    /// <summary>
    /// Get all information of the chest in question
    /// </summary>
    private void Start ()
	{
		connectionString = "URI=file:" + Application.dataPath + "/Plugins/ChestInformation.db";
		string conn = connectionString;
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd1 = dbconn.CreateCommand ();
		IDbCommand dbcmd2 = dbconn.CreateCommand ();
		IDbCommand dbcmd3 = dbconn.CreateCommand ();

		string sqlQuery1 = commandString + table1;
		string sqlQuery2 = commandString + table2;
		string sqlQuery3 = commandString + table3;

		dbcmd1.CommandText = sqlQuery1;
		dbcmd2.CommandText = sqlQuery2;
		dbcmd3.CommandText = sqlQuery3;

		IDataReader reader1 = dbcmd1.ExecuteReader ();
		IDataReader reader2 = dbcmd2.ExecuteReader ();
		IDataReader reader3 = dbcmd3.ExecuteReader ();
		/*
		while (reader1.Read ())
		{
			
			getCurrency = reader1.GetBoolean (0);
			locked = reader1.GetBoolean(1);
			Debug.Log ("Getcurrency  = " + getCurrency);
			Debug.Log ("Locked  = " + locked);

		}*/
		while (reader2.Read ())
		{
			int getCurrency = reader2.GetInt32 (0);
			//Debug.Log ("Getcurrency  = " + getCurrency);
			
		}
		/*
		while (reader3.Read () && !getCurrency)
		{
			string itemTypeGained = reader3.GetString(0);
			string itemGained = reader3.GetString(1);
			Debug.Log ("GetItemType  = " + itemTypeGained);
			Debug.Log ("GetItem  = " + itemGained);
		}
		*/
		reader1.Close ();
		reader2.Close ();
		reader3.Close ();
		reader1 = null;
		reader2 = null;
		reader3 = null;
		dbcmd1.Dispose ();
		dbcmd2.Dispose ();
		dbcmd3.Dispose ();
		dbcmd1 = null;
		dbcmd2 = null;
		dbcmd3 = null;
		dbconn.Close ();
		dbconn = null;
	}
}
