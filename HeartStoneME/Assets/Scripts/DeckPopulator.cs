using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class DeckPopulator : MonoBehaviour {

	private static void Shuffle<Card>(IList<Card> deck)
	{
		RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
		int n = deck.Count;
		while (n > 1)
		{
			byte[] box = new byte[1];
			do provider.GetBytes(box);
			while (!(box[0] < n * (System.Byte.MaxValue / n)));
			int k = (box[0] % n);
			n--;
			Card value = deck[k];
			deck[k] = deck[n];
			deck[n] = value;
		}
	}

	public List<Card> GenerateBasicDeck()
	{
		List<Card> deck = new List<Card>();

		//Talking
		deck.Add (new Card ("Text Message", 1, 1));
		deck.Add (new Card ("Heart Emoji", 2, 3));
		deck.Add (new Card ("Missles Emoji", 3, 2));
		deck.Add (new Card ("Communication", 3, 3));


		//Food
		deck.Add (new Card ("Kimchi", 2, 3));
		deck.Add (new Card ("Pizza", 3, 2));
		deck.Add (new Card ("Fine Scotch", 4, 5));
		deck.Add (new Card ("Cooking Duo", 4, 4));
		deck.Add (new Card ("Dinner Party", 3, 3));

		//Dancing
		deck.Add (new Card ("Dancer", 2, 2));
		deck.Add (new Card ("Nu Disco", 3, 1));
		deck.Add (new Card ("90s R&B", 3, 1));
		deck.Add (new Card ("Swing Dancing", 1, 3));

		//Games
		deck.Add (new Card ("Destino", 3, 4));
		deck.Add (new Card ("Hearthstone", 4, 3));
		deck.Add (new Card ("Social Game", 2, 2));
		deck.Add (new Card ("Game Design", 6, 6));
		deck.Add (new Card ("Crosswords", 2, 2));


		//Couple
		deck.Add (new Card ("Post Office", 1, 1));
		deck.Add (new Card ("Pete", 3, 5));
		deck.Add (new Card ("M.E.", 5, 3));
		//deck.Add (new Card ("Cuddle", 1, 1));
		deck.Add (new Card ("Hanging Out", 4, 4));


		foreach (Card c in deck)
		{
			c.m_Zone = GameZone.Deck;
		}
		Shuffle (deck);
		return deck;
	}
}
