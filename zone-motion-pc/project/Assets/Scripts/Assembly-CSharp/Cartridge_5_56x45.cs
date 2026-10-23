using UnityEngine;

public class Cartridge_5_56x45 : ConstructorCartridge
{
	public Cartridge_5_56x45()
	{
		base.NameSubject = "5,56x45 мм";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 10;
		base.DescriptionSubject = "Малоимпульсный натовский патрон калибра 5,56х45 мм, разработанный для ведения прицельного огня очередями. Известен под индексом SS109. Обладает прекрасными баллистическими характеристиками.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.005f;
	}
}
