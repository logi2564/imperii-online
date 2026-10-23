using UnityEngine;

public class Cartridge9x19 : ConstructorCartridge
{
	public Cartridge9x19()
	{
		base.NameSubject = "9х19 мм";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/9x19zmo");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/9x19zmo");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x19zmo");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 3;
		base.DescriptionSubject = "Стандартный патрон калибра 9х19 мм с оболочечной пулей. Обладает хорошими баллистическими характеристиками и при этом недорог в изготовлении, что и обусловило широкое его распространение. Малоэффективен против бронежилетов.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.003f;
	}
}
