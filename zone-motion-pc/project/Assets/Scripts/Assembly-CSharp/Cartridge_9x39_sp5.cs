using UnityEngine;

public class Cartridge_9x39_sp5 : ConstructorCartridge
{
	public Cartridge_9x39_sp5()
	{
		base.NameSubject = "9х39 мм СП-5";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/9x39-PAB-9");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/9x39-PAB-9");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x39-PAB-9");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 9;
		base.DescriptionSubject = "Дозвуковой «снайперский» патрон СП-5 оснащён пулей с биметаллической оболочкой. Полость позади стального сердечника заполнена свинцом. Требует использования глушителя для обеспечения бесшумной стрельбы. Распространён в странах Варшавского договора.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.002f;
	}
}
