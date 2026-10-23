using UnityEngine;

public class Cartridge12x70 : ConstructorCartridge
{
	public Cartridge12x70()
	{
		base.NameSubject = "12х70 дробь";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 2;
		base.DescriptionSubject = "Обычный патрон 12-го калибра, снаряжённый дробью диаметром 6 мм. На близких дистанциях обладает огромным убойным и останавливающим действием. Предназначен для стрельбы только из гладкоствольного оружия.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.006f;
	}
}
