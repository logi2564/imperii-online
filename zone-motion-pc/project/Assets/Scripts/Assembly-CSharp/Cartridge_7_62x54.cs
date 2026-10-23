using UnityEngine;

public class Cartridge_7_62x54 : ConstructorCartridge
{
	public Cartridge_7_62x54()
	{
		base.NameSubject = "7,62x54 мм 7H1";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/7.62x54-7H1");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/7.62x54-7H1");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/7.62x54-7H1");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 30;
		base.DescriptionSubject = "Специально разработанный снайперский патрон калибра 7,62 мм. Пуля оснащена стальным сердечником. В сравнении со стандартным патроном того же калибра обладает улучшенными баллистическими характеристиками и повышенной пробивающей способностью.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.008f;
	}
}
