using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class GuiCardScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler{

	public static GuiCardScript s_Current;
	public GameObject Title;
	public GameObject Pos;
	public GameObject Neg;
	public GameObject Border;
	public Card cardInfo;
	public Vector3 startPosition;
	public Transform startParent;


	void Update()
	{
		if (cardInfo == null || cardInfo.m_Used) {
			Border.GetComponent<Image> ().color = Color.black;
		} else
		{
			Border.GetComponent<Image> ().color = Color.green;

		}
	}

	public void OnDrop (PointerEventData eventData)
	{
		if (GuiCardScript.s_Current != null) {

		}
	} 

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (!cardInfo.m_Used)
		{
			switch (cardInfo.m_Zone)
			{
			case GameZone.Hand:
				GameState.theGame.CastTargetting();
				break;
			case GameZone.InPlay:
				GameState.theGame.ChargeTargetting();
				break;
			default:
				break;
			}
			startPosition = transform.position;
			startParent = transform.parent;
			s_Current = this;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (s_Current != null)
		{
			transform.position = Input.mousePosition;
		}
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		if (s_Current != null)
		{
			GameState.theGame.EndTargetting();
			transform.position = startPosition;
			s_Current = null;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}

	#endregion

	public void InitializeCard(Card c)
	{
		cardInfo = c;
		Title.GetComponent<Text> ().text = c.m_Name;
		Pos.GetComponent<Text> ().text = ""+c.m_Positive;
		Neg.GetComponent<Text> ().text = ""+c.m_Negative;

	}
}
