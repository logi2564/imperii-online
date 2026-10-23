using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaScript : MonoBehaviour
{
	public void QuitEncyclopedia()
	{
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		Object.Destroy(base.gameObject);
	}

	public void ArtefactPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAy artefact in Data.Artefacts)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Itam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = artefact.TextureSubject;
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = artefact.NameSubject + "\n" + artefact.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = artefact;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void SuitPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAAAAAAbe suitsEncyclopedium in Data.SuitsEncyclopedia)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Itam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = suitsEncyclopedium.TextureSubject;
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = suitsEncyclopedium.NameSubject + "\n" + suitsEncyclopedium.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = suitsEncyclopedium;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void WeaponPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (ConstructorWeapon weaponsEncyclopedium in Data.WeaponsEncyclopedia)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/WeaponItam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = weaponsEncyclopedium.TextureSubject;
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = weaponsEncyclopedium.NameSubject + "\n" + weaponsEncyclopedium.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = weaponsEncyclopedium;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void CartridgePanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAAAAk cartridgeEncyclopedium in Data.CartridgeEncyclopedia)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Itam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = cartridgeEncyclopedium.TextureSubject;
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = cartridgeEncyclopedium.NameSubject + "\n" + cartridgeEncyclopedium.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = cartridgeEncyclopedium;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void MedicalPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAAAAk medicalEncyclopedium in Data.MedicalEncyclopedia)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Itam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = medicalEncyclopedium.TextureSubject;
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = medicalEncyclopedium.NameSubject + "\n" + medicalEncyclopedium.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = medicalEncyclopedium;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void ProductsPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAAAAk productsEncyclopedium in Data.ProductsEncyclopedia)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Itam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = productsEncyclopedium.TextureSubject;
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = productsEncyclopedium.NameSubject + "\n" + productsEncyclopedium.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = productsEncyclopedium;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void EmptyPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAAAAk emptyEncyclopedium in Data.EmptyEncyclopedia)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Itam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = emptyEncyclopedium.TextureSubject;
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = emptyEncyclopedium.NameSubject + "\n" + emptyEncyclopedium.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = emptyEncyclopedium;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void MutantsPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/ItemPanel"));
		gameObject.name = "ItemPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAAAAk mutantsEncyclopedium in Data.MutantsEncyclopedia)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Itam"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = mutantsEncyclopedium.TextureSubject;
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = mutantsEncyclopedium.NameSubject + "\n" + mutantsEncyclopedium.DescriptionSubject;
			gameObject2.GetComponent<SpecificationItemScript>().Item = mutantsEncyclopedium;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}
}
