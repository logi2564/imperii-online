using UnityEngine;

public class Cartridge_5_45x39 : ConstructorCartridge
{
	public Cartridge_5_45x39()
	{
		base.NameSubject = "5,45x39 мм";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/5-45x39");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/5-45x39");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-45x39");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 7;
		base.DescriptionSubject = "Армейский патрон калибра 5.45x39 мм 7Н10 с пулей повышенной пробиваемости используется в автоматических винтовках стран Варшавского договора. Благодаря уменьшению импульса отдачи и увеличению дальности полета пули обеспечивает более высокую точность боя в сравнении со старым патроном калибра 7,62 мм.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.004f;
	}
}
