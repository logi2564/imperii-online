using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdvertisingScript : MonoBehaviour
{
	private static bool AdsAvailableOnThisPlatform()
	{
		if (Application.platform == RuntimePlatform.Android) return true;
		Inventory.MessagePanel("Просмотр рекламы недоступен в версии для ПК.");
		return false;
	}

	public void QuitAP()
	{
		Inventory._Equipment = true;
		Inventory._CurtainGUIEquipment.SetActive(true);
		Inventory._CurtainIconCharacterU.SetActive(true);
		Inventory._CurtainState.SetActive(true);
		Inventory._CurtainInventory.SetActive(false);
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		Object.Destroy(base.gameObject);
	}

	public void ExitMenu()
	{
		GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe("Menu", string.Empty);
	}

	public void ConnectionAds()
	{
		if (!AdsAvailableOnThisPlatform()) return;
		bool flag = false;
		int num = 0;
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[0].CharBackpack[i].NameSubject == "None")
			{
				flag = true;
				num = i;
				break;
			}
		}
		if (flag)
		{
			if (Inventory._QuantityClipsOfAdvertising <= 10)
			{
				GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Advertise/ConnectionField"));
				gameObject.name = "ConnectionField";
				gameObject.transform.SetParent(base.gameObject.transform.GetChild(3).GetChild(0).GetChild(0));
				gameObject.transform.localPosition = new Vector3(0f, 0f);
				float num2 = Screen.width;
				num2 /= 1280f;
				gameObject.transform.localScale = new Vector3(1f, 1f);
				AAAAAAAAAAAAAAAAAAAf();
			}
			else
			{
				Inventory.MessagePanel("Вы можете просмотреть ролик только через несколько ходов");
			}
		}
		else
		{
			Inventory.MessagePanel("Рюкзак переполнен!\nНебходимо освободить место для новой экипировки...");
		}
	}

	public void ConnectionAds_DeadHero()
	{
		if (!AdsAvailableOnThisPlatform()) return;
		if (Inventory._QuantityClipsOfAdvertising <= 13)
		{
			GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Advertise/ConnectionField"));
			gameObject.name = "ConnectionField";
			gameObject.transform.SetParent(base.gameObject.transform.GetChild(2).GetChild(0).GetChild(0));
			gameObject.transform.localPosition = new Vector3(0f, 0f);
			float num = Screen.width;
			num /= 1280f;
			gameObject.transform.localScale = new Vector3(1f, 1f);
			AAAAAAAAAAAAAAAAAAAAAd();
		}
		else
		{
			Inventory.MessagePanel("Вы можете просмотреть ролик только через несколько ходов");
		}
	}

	public void AAAAAAAAAAAAAAAAAAAf()
	{
		if (!AdsAvailableOnThisPlatform()) return;
		if (Advertisement.IsReady("rewardedVideo"))
		{
			Advertisement.Initialize("1587463", false);
			ShowOptions showOptions = new ShowOptions();
			showOptions.resultCallback = AAAAAAAAAAAAAAAAAe;
			ShowOptions showOptions2 = showOptions;
			Advertisement.Show("rewardedVideo", showOptions2);
		}
	}

	private void AAAAAAAAAAAAAAAAAe(ShowResult AAAAAAAAAAAAAAAAAf)
	{
		switch (AAAAAAAAAAAAAAAAAf)
		{
		case ShowResult.Finished:
		{
			Debug.Log("The ad was successfully shown.");
			Object.Destroy(GameObject.Find("ConnectionField"));
			Inventory._QuantityClipsOfAdvertising++;
			Inventory.AAAAAAAAAAAAAAAAAAAAAch();
			GameObject gameObject = GameObject.Find("AdvertisePanel");
			gameObject.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Держи, дружище!\nНадеюсь это тебе поможет продержаться в Зоне подольше...\nЗаглядываю сюда почаще, с ростом опыта, товары становятся ценнее!";
			GameObject gameObject2;
			if (gameObject.transform.GetChild(3).transform.GetChild(0).childCount < 2)
			{
				gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject2.transform.GetChild(0).transform.localPosition = new Vector3(gameObject2.transform.GetChild(0).transform.localPosition.x * -1.2f, gameObject2.transform.GetChild(0).transform.localPosition.y, 0f);
			}
			else
			{
				gameObject2 = gameObject.transform.GetChild(3).transform.GetChild(0).GetChild(1).gameObject;
			}
			gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform.GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = Inventory._RewardAdvertisingSubject.TextureSubject;
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject2.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: " + Inventory._RewardAdvertisingSubject.NameSubject;
			if (Inventory._RewardAdvertisingSubject.Stack > 1)
			{
				Text component = gameObject2.transform.GetChild(1).GetComponent<Text>();
				string text = component.text;
				component.text = text + " " + Inventory._RewardAdvertisingSubject.Stack + " шт.";
			}
			Transform obj = gameObject2.transform;
			Vector3 localScale = new Vector3(1f, 1f);
			gameObject2.transform.localScale = localScale;
			obj.localScale = localScale;
			for (int i = 0; i < 20; i++)
			{
				if (Data.CharacterD[0].CharBackpack[i].NameSubject == "None")
				{
					Data.CharacterD[0].CharBackpack[i] = Inventory._RewardAdvertisingSubject;
					break;
				}
			}
			break;
		}
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

	public void AAAAAAAAAAAAAAAAAAAAAd()
	{
		if (!AdsAvailableOnThisPlatform()) return;
		if (Advertisement.IsReady("rewardedVideo"))
		{
			Advertisement.Initialize("1587463", false);
			ShowOptions showOptions = new ShowOptions();
			showOptions.resultCallback = AAAAAAAAAAAAAAAAAAAAAe;
			ShowOptions showOptions2 = showOptions;
			Advertisement.Show("rewardedVideo", showOptions2);
		}
	}

	private void AAAAAAAAAAAAAAAAAAAAAe(ShowResult AAAAAAAAAAAAAAAAAg)
	{
		switch (AAAAAAAAAAAAAAAAAg)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			Object.Destroy(base.gameObject);
			Inventory._QuantityClipsOfAdvertising++;
			Data.CharacterD[CharacterMotion._curCharacter].CurHealth = 23f;
			Data.CharacterD[CharacterMotion._curCharacter].Satiety += 25;
			Data.CharacterD[CharacterMotion._curCharacter].Thirst += 25;
			Data.CharacterD[CharacterMotion._curCharacter].Life = true;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[CharacterMotion._curCharacter].CurHealth / 100f - 0.5f) / 2f, 0.5f);
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[CharacterMotion._curCharacter].CurHealth / 100f, 0.3f);
			Inventory.AAAAAAAAAAAAAAAAAAAAAcg();
			Inventory._Equipment = true;
			Inventory._CurtainGUIEquipment.SetActive(true);
			Inventory._CurtainIconCharacterU.SetActive(true);
			Inventory._CurtainState.SetActive(true);
			Inventory._CurtainInventory.SetActive(false);
			CharacterMotion._PointsMove = 5;
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}
