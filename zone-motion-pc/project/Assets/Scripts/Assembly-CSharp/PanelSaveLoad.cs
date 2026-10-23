using UnityEngine;

public class PanelSaveLoad : MonoBehaviour
{
	public void DestroySLPanel()
	{
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		Object.Destroy(base.gameObject);
	}

	public void Save()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		SaveLoad.AAAAAAAAAAAAAAAAAAde("Save", false);
		Inventory.MessagePanel("Сохранено в слот: 1");
		DestroySLPanel();
	}

	public void Save1()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		SaveLoad.AAAAAAAAAAAAAAAAAAde("Save1", false);
		Inventory.MessagePanel("Сохранено в слот: 2");
		DestroySLPanel();
	}

	public void Save2()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		SaveLoad.AAAAAAAAAAAAAAAAAAde("Save2", false);
		Inventory.MessagePanel("Сохранено в слот: 3");
		DestroySLPanel();
	}

	public void Save3()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		SaveLoad.AAAAAAAAAAAAAAAAAAde("Save3", false);
		Inventory.MessagePanel("Сохранено в слот: 4");
		DestroySLPanel();
	}

	public void Load0()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save");
	}

	public void Load1()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save1");
	}

	public void Load2()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save2");
	}

	public void Load3()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save3");
	}

	public void LoadAutoSave()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("AutoSave");
	}
}
