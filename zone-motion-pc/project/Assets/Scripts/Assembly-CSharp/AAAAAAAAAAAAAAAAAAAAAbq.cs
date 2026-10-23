using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbq : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAAAAAAbq()
	{
		base.NameSubject = "ПСИ-блокада";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/PSIblockade");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.AudioFire = (AudioClip)Resources.Load("Sound/Suit/inv_properties");
		base.CostSubject = 290;
		base.DescriptionSubject = "Препарат, блокирующий нервные импульсы и подавляющий эмоции. Используется для противодействия ПСИ-активности. Для эффекта необходимо употреблять перед предполагаемым ПСИ-воздействием. Употреблять более 2 штук не имеет смысла. (Действие препарата ослабивает с каждым ходом. Максимальная защита - 4)";
		base.WeightSubject = 0.1f;
		base.Sanitation = 0f;
		base.PsiProtection = 2;
		base.Bleeding = 0f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.Hunger = 0;
		base.Thirst = -1;
	}
}
