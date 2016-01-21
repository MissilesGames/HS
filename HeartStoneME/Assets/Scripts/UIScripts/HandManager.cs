using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HandManager : MonoBehaviour {
	public GameObject handZone;

	public void Manage(GuiCardScript controller)
	{
		controller.GetComponent<RectTransform>().SetParent(handZone.transform, false);
	}
	
}
