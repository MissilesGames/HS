using UnityEngine;
using System.Collections;

public class ButtonNavigation : MonoBehaviour {

	public void GoToCollectionScene()
	{
		Application.LoadLevel("CollectionScene");
	}

	public void GoToGameScene()
	{
		Application.LoadLevel("GameScene");
	}

	public void GoToMenuScene()
	{
		Application.LoadLevel("MenuScene");
	}
}
