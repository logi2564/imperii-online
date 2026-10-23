using UnityEngine;

public class HandicraftBatteries : ConstructorCartridge
{
	public HandicraftBatteries()
	{
		base.NameSubject = "Кустарные батареи";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/gauss-ammo-hm");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/gauss-ammo-hm");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/gauss-ammo-hm");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 30;
		base.DescriptionSubject = "Энергетические элементы пониженной ёмкости, использующие в качестве источника энергии капсулированный фрагмант артефакта ''Вспышка''. Пониженная ёмкость обусловлена кустарными условиями изготовления элементов при отсутствии специального оборудования.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.009f;
	}
}
