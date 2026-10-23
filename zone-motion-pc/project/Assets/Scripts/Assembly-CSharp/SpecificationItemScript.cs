using UnityEngine;
using UnityEngine.UI;

public class SpecificationItemScript : MonoBehaviour
{
	public AAAAAAAAAAAAAAAAAAk Item;

	public void OpenItem()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/DescriptionItamPanel"));
		gameObject.name = "DescriptionItamPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetChild(0).GetComponent<RawImage>().texture = Item.TextureSubject;
		gameObject.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
		gameObject.transform.GetChild(1).GetComponent<Text>().text = Item.NameSubject + "\n" + Item.DescriptionSubject;
		if (Item.CostSubject > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Средняя стоимость: " + Item.CostSubject + " ru";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.WeightSubject > 0f)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Вес: " + Item.WeightSubject + " кг";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Protection > 0f)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Защита: <color=#1D902CFF>" + Item.Protection + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.XRayProtection > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Радиационная защита: <color=#1D902CFF>" + Item.XRayProtection + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.PsiProtection > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "ПСИ-защита: <color=#1D902CFF>" + Item.PsiProtection + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.ProtectionFromEject > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Защита от выброса: <color=#1D902CFF>" + Item.ProtectionFromEject + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.ArtContainer > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Контейнеры для артефактов: <color=#1D902CFF>" + Item.ArtContainer + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Damage > 0f)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Повреждение: <color=#1D902CFF>" + Item.Damage + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Range > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Дальность (min - max): <color=#1D902CFF>" + Item.MinRange + " - " + Item.Range + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.CartridgeInMagazineFull > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Кол-во патронов: <color=#1D902CFF>" + Item.CartridgeInMagazineFull + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Sanitation > 0f)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Лечение: <color=#1D902CFF>" + Item.Sanitation + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.XRaySanitation < 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Радиация: <color=#1D902CFF>" + Item.XRaySanitation + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Bleeding != 0f)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			if (Item.Bleeding < 0f)
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Кровотечение: <color=#1D902CFF>" + Item.Bleeding + "</color>";
			}
			else
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Кровотечение: <color=#9F0000FF>" + Item.Bleeding + "</color>";
			}
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Force != 0f)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			if (Item.Force > 0f)
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Выносливость: <color=#1D902CFF>" + Item.Force + "</color>";
			}
			else
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Выносливость: <color=#9F0000FF>" + Item.Force + "</color>";
			}
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.XrayNegatife > 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Радиация: <color=#9F0000FF>" + Item.XrayNegatife + "</color>";
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Hunger != 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			if (Item.Hunger > 0)
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Утоление голода: <color=#1D902CFF>" + Item.Hunger + "</color>";
			}
			else
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Утоление голода: <color=#901919FF>" + Item.Hunger + "</color>";
			}
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		if (Item.Thirst != 0)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/SpecificationItem"));
			if (Item.Thirst > 0)
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Утоление жажды: <color=#1D902CFF>" + Item.Thirst + "</color>";
			}
			else
			{
				gameObject2.transform.GetChild(0).GetComponent<Text>().text = "Утоление жажды: <color=#9F0000FF>" + Item.Thirst + "</color>";
			}
			gameObject2.transform.SetParent(gameObject.transform.GetChild(2).GetChild(0));
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}
}
