using UnityEngine;

public class Cartridge45АСР : ConstructorCartridge
{
	public Cartridge45АСР()
	{
		base.NameSubject = ".45 АСР";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/45ACP");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/45ACP");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/45ACPo");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 4;
		base.DescriptionSubject = "Патрон калибра .45 с оболочечной пулей остаётся популярным уже более сотни лет. Тяжёлая пуля при относительно слабом пороховом заряде летит с не слишком большой скоростью, но обладает значительным останавливающим действием.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.004f;
	}
}
