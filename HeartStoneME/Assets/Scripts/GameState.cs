using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameZone 
{
	Deck,
	Hand,
	InPlay,
	Discard
}

public class GameState : MonoBehaviour {

	public static GameState theGame;

	public CardManager m_CardManager;
	public BatteryManager m_BatteryManager;
	public ScoreManager m_ScoreManager;
	public PlayManager m_PlayManager;

	public bool m_BatterySign;
	public int m_Score;
	public List<Card> m_Hand;
	public List<Card> m_PlayingField;
	Queue<Card> m_Deck;
	List<Card> m_RawDeck;
	bool m_started;
	
	// Use this for initialization
	void Start ()
	{
		theGame = this;
		m_Score = 0;
		m_BatterySign = true;
		m_Hand = new List<Card> ();
		m_PlayingField = new List<Card> ();

		PopulateDeck ();
		m_started = false;
	}

	void Update()
	{
		if(!m_started)
		{
			m_started = true;
			BeginGame();
		}
	}

	void BeginGame()
	{
		DrawCards(3);
	}
	
	void PopulateDeck()
	{
		DeckPopulator dp = new DeckPopulator ();
		m_RawDeck = dp.GenerateBasicDeck ();
		m_Deck = new Queue<Card>(m_RawDeck);
	}
	
	public void NewTurn()
	{
		m_BatterySign = !m_BatterySign;
		m_BatteryManager.SetSign (m_BatterySign);
		DrawACard();
		foreach (Card c in m_Hand)
		{
			c.m_Used = false;
		}
		foreach (Card c in m_PlayingField)
		{
			c.m_Used = false;
		}
	}
	
	void DrawCards(int num)
	{
		for(int i = 0; i < num; i++)
		{
			DrawACard();
		}
	}
	
	void DrawACard()
	{
		if (m_Deck.Count != 0)
		{
			Card c = m_Deck.Dequeue();
			m_Hand.Add (c);
			c.m_Zone = GameZone.Hand;
			m_CardManager.ManageNewCard(c);
		}
	}

	public void AddScore(int val)
	{
		m_Score += val;
		m_ScoreManager.UpdateScore (m_Score);
	}

	public void CastTargetting()
	{
		m_PlayManager.Targetting (true);
	}
	public void ChargeTargetting()
	{
		m_BatteryManager.Targetting (true);
	}

	public void EndTargetting()
	{
		m_BatteryManager.Targetting (false);
		m_PlayManager.Targetting (false);
	}
}
