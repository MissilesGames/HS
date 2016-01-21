using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayManager : Targettable , IDropHandler{

	GameObject zone;
	void Start()
	{
		zone = GameObject.Find ("InPlayZone");

		((Targettable)this).Start();
	}
	public void OnDrop (PointerEventData eventData)
	{
		if (GuiCardScript.s_Current != null) {
			GuiCardScript.s_Current.transform.SetParent (zone.transform, false);
			if (GuiCardScript.s_Current.cardInfo.m_Zone == GameZone.Hand)
			{
				GuiCardScript.s_Current.cardInfo.Enters ();
			}

		}
	}
}
