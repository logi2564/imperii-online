using System;
using System.IO;
using System.Text;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine;

public class GPSCloud : MonoBehaviour
{
	private const string AAAAAAAAAAAAAAAAAAAAAf = "CloudGameProgress";

	public static GPSCloud Instance { get; private set; }

	private void Start()
	{
		Instance = this;
	}

	public void SaveGameToCloud()
	{
		Debug.Log("137");
		if (Social.localUser.authenticated)
		{
			((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution("CloudGameProgress", DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseMostRecentlySaved, AAAAAAAAAAAAAAAAAAAi);
		}
		else
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAq("Отсутствует подключение к интерету.\nПроверте подклчение к интернету и попробуйте снова использовать облачное сохранение, либо сохраните прогресс в другой слот.\nCode: GPSCloud36");
		}
	}

	private void AAAAAAAAAAAAAAAAAAAi(SavedGameRequestStatus AAAAAAAAAAAAAAAAAAc, ISavedGameMetadata AAAAAAAAAAAAAAAAAAAAd)
	{
		if (AAAAAAAAAAAAAAAAAAc == SavedGameRequestStatus.Success)
		{
			SaveLoad.AAAAAAAAAAAAAAAAAAde("AutoSave", false);
			string path = Path.Combine(Application.persistentDataPath, "CipherAutoSave.json");
			string text = File.ReadAllText(path);
			int length = text.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
			}
			text = Encoding.UTF8.GetString(array, 0, array.Length);
			array = Encoding.ASCII.GetBytes(text);
			SavedGameMetadataUpdate updateForMetadata = default(SavedGameMetadataUpdate.Builder).Build();
			((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(AAAAAAAAAAAAAAAAAAAAd, updateForMetadata, array, AAAAAAAAAAAAAAAAAAAj);
			Debug.Log("239");
			Inventory.AAAAAAAAAAAAAAAAAAcy("CloudSave");
			GPSscript.AAAAAAAAAAAAAAAAAAAq("CloudSave. GPSCloud69");
		}
		else
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAq("Отсутствует подключение к интерету.\nПроверте подклчение к интернету и попробуйте снова использовать облачное сохранение, либо сохраните прогресс в другой слот.\nCode: GPSCloud72");
		}
	}

	private void AAAAAAAAAAAAAAAAAAAj(SavedGameRequestStatus AAAAAAAAAAAAAAAAAAAAAg, ISavedGameMetadata AAAAAAAAAAAAAAAAAAAk)
	{
		GPSscript.AAAAAAAAAAAAAAAAAAAq("Успешно сохранено в облако.");
	}

	public void LoadGameFromCloud()
	{
		Debug.Log("137");
		if (Social.localUser.authenticated)
		{
			((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution("CloudGameProgress", DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseMostRecentlySaved, AAAAAAAAAAAAAAAAAAAl);
		}
		else
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAq("Отсутствует подключение к интерету.\nПроверте подклчение к интернету и попробуйте снова загрузить облачное сохранение, либо загрузите прогресс из другого слота.\nCode: GPSCloud93");
		}
	}

	private void AAAAAAAAAAAAAAAAAAAl(SavedGameRequestStatus AAAAAAAAAAAAAAAAAAAAAAe, ISavedGameMetadata AAAAAAAAAAAAAAAc)
	{
		GPSscript.AAAAAAAAAAAAAAAAAAAq("102");
		((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(AAAAAAAAAAAAAAAc, AAAAAAAAAAAAAAAAAAAm);
		GPSscript.AAAAAAAAAAAAAAAAAAAq("104");
	}

	private void AAAAAAAAAAAAAAAAAAAm(SavedGameRequestStatus AAAAAAAAAAAAAAAAAAAn, byte[] AAAAAAAAAAAAAAAAAAAAAh)
	{
		Debug.Log("175");
		if (AAAAAAAAAAAAAAAAAAAn == SavedGameRequestStatus.Success)
		{
			if (AAAAAAAAAAAAAAAAAAAAAh.Length == 0)
			{
				GPSscript.AAAAAAAAAAAAAAAAAAAq("Облачное сохранение еще не использовалось.\nCode: GPSCloud113");
				return;
			}
			string text = Encoding.ASCII.GetString(AAAAAAAAAAAAAAAAAAAAAh);
			string path = Path.Combine(Application.persistentDataPath, "CipherAutoSave.json");
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			string text2 = BitConverter.ToString(bytes);
			File.WriteAllText(path, text2.Replace("-", string.Empty));
			SaveOneMap saveOneMap = JsonUtility.FromJson<SaveOneMap>(text);
			SaveLoad.AAAAAAAAAAAAAAAAAAAAAcp("AutoSave", saveOneMap.staS.CurrentScene);
			Debug.Log("206");
		}
	}
}
