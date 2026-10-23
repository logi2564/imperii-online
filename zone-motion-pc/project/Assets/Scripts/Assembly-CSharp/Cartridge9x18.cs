using UnityEngine;

public class Cartridge9x18 : ConstructorCartridge
{
	public Cartridge9x18()
	{
		base.NameSubject = "9х18 мм";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/9x18");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/9x18");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x18");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 2;
		base.DescriptionSubject = "Патрон с оболочечной пулей - со стальным сердечником и свинцовой рубашкой под металлической оболочкой. Обладает хорошим останавливающим действием, однако малоэффективен против бронежилетов.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.002f;
	}
}
