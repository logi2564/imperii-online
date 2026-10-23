using UnityEngine;
using UnityEngine.EventSystems;

public class Backgrownd : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEventSystemHandler
{
	public void OnBeginDrag(PointerEventData eventData)
	{
		CharacterMotion.posSwipe0 = -eventData.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (CharacterMotion.PointInform != null)
		{
			CharacterMotion.PointInform.SetActive(false);
		}
		if (!CharacterMotion.zoom)
		{
			CharacterMotion.posSwipe1 = CharacterMotion.posSwipe0;
			CharacterMotion.posSwipe0 = -eventData.position;
			CharacterMotion.posSwipe2 = -eventData.position;
			CharacterMotion.VectorOfSwipe = CharacterMotion.posSwipe2 - CharacterMotion.posSwipe1;
			CharacterMotion.VectorOfSwipe /= CharacterMotion.coefficientScreen;
			CharacterMotion.VectorOfSwipe += CharacterMotion._CameraCM.transform.position;
			CharacterMotion.swipe = true;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Inventory._GGActive || !Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			return;
		}
		if (CharacterMotion.PointInform != null)
		{
			CharacterMotion.PointInform.SetActive(false);
		}
		CharacterMotion.GexX.SetActive(true);
		CharacterMotion.GexX.transform.position = eventData.pointerCurrentRaycast.worldPosition;
		if (CharacterMotion._NextGex.Count > 0)
		{
			for (int i = 0; i < CharacterMotion._NextGex.Count; i++)
			{
				GameObject.Find(CharacterMotion._NextGex[i].NameGex).GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
			}
			CharacterMotion._NextGex.Clear();
		}
		for (int j = 0; j < CharacterMotion.TargetsList.Count; j++)
		{
			Object.Destroy(CharacterMotion.TargetsList[j]);
		}
		Inventory._CurrentCharUnit.Clear();
		Inventory._CurrentPoint.Clear();
	}
}
