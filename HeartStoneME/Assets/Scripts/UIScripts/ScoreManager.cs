using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public void UpdateScore(int val)
	{
		scoreText.text = "Score: " + val;
	}
}
