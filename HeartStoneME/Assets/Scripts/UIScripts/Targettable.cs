using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Targettable : MonoBehaviour {
	
	protected GameObject border;

	public void Start()
	{
		border = GameObject.Find (name+"/Border_");
		if (border != null) {
			print ("Border set up for " + name);
		}
	}

	public void Targetting(bool val)
	{
		if (val) {
			border.GetComponent<Image> ().color = Color.white;
		} else {
			border.GetComponent<Image> ().color = Color.black;
			
		}
	}
}
