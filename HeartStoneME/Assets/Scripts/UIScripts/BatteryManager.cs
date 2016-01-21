using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;

public class BatteryManager : Targettable, IDropHandler{

	public Sprite pos;
	public Sprite neg;
	public GameObject signImage;
	public void SetSign (bool sign)
	{
		if (sign)
		{
			signImage.GetComponent<Image>().sprite = pos;
		}
		else
		{
			signImage.GetComponent<Image>().sprite = neg;
		}
	}

	public void OnDrop (PointerEventData eventData)
	{
		if (GuiCardScript.s_Current != null) {
			Card card = GuiCardScript.s_Current.cardInfo;
			if (card.m_Zone == GameZone.InPlay) {
				card.Charge ();
			}
		}
	}
}
