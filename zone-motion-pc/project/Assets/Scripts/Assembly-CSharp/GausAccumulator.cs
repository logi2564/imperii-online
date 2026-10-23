using UnityEngine;

public class GausAccumulator : ConstructorCartridge
{
	public GausAccumulator()
	{
		base.NameSubject = "Аккумуляторы";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Cartridges/accumulator");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Cartridges/accumulator");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/accumulator");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 70;
		base.DescriptionSubject = "Энергетические элементы, использующие в качестве источника энергии капсулированный фрагмент артефакта «Вспышка». Изготовлены в заводских условиях при помощи высокотехнологичного оборудования.";
		base.TypeSubj = TypeSubject.Catridge;
		base.WeightSubject = 0.009f;
	}
}
