using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CardManager : MonoBehaviour {

	public HandManager m_handManager;
	List<GuiCardScript> cardGUIs;
	public GameObject urCard;

	void Start()
	{
		cardGUIs = new List<GuiCardScript> ();
	}

	public void ManageNewCard(Card c)
	{
		GameObject newCard = Instantiate (urCard);
		GuiCardScript controller = newCard.GetComponent<GuiCardScript> ();
		controller.InitializeCard (c);
		cardGUIs.Add(controller);
		if (c.m_Zone == GameZone.Hand)
		{
			m_handManager.Manage(controller);
		}
	}
}
