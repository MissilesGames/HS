using UnityEngine;
using System.Collections;

public class Card 
{
	private static int nextID;
	public int m_GameID;
	public GameZone m_Zone;
	public int m_Positive, m_Negative;
	public string m_Name;
	public bool m_Used;
	
	public Card (string name, int pos, int neg)
	{
		m_Name = name;
		m_Positive = pos;
		m_Negative = neg;
		m_GameID = nextID++;
		m_Used = false;
	}
	
	public void Enters()
	{
		m_Zone = GameZone.InPlay;
		m_Used = true;
		GameState.theGame.m_PlayingField.Add (this);
		GameState.theGame.m_Hand.Remove (this);
	}
	
	public void Charge()
	{
		if(GameState.theGame.m_BatterySign)
		{
			GameState.theGame.AddScore(m_Positive);
		}
		else
		{
			GameState.theGame.AddScore(m_Negative);
		}
		m_Used = true;
	}

	public void GetCharged()
	{
	}
	
}
