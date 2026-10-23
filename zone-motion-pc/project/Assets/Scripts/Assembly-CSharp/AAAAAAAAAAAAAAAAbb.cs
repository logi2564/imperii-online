using UnityEngine;

public class AAAAAAAAAAAAAAAAbb : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAbb()
	{
		base.NameSubject = "Снежинка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/icefly");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 8000;
		base.DescriptionSubject = "Внешне артефакт похож на «Колобок». Существует мнение что это и есть «Колобок», свойства которого усилились после воздействия мощного электрического поля. Благодаря своим качествам способен резко увеличивать мышечный тонус носителя. Радиоактивен.";
		base.WeightSubject = 0.4f;
		base.Force = 12f;
		base.TypeSubj = TypeSubject.Artefact;
		base.XrayNegatife = 2;
	}
}
