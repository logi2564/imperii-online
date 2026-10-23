using UnityEngine;

public class AAAAAAAAAAAAAAbb : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAbb()
	{
		base.NameSubject = "Анабиотик";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/anabiotic");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.AudioFire = (AudioClip)Resources.Load("Sound/Suit/inv_properties");
		base.CostSubject = 800;
		base.DescriptionSubject = "Экспериментальный препарат, разработанный для научно-исследовательских групп, действующих в Зоне. Лежащий в основе препарата тетрадотоксин, известный как ''Порошок Зомби'', вызывает полный паралич центральной нервной системы, что может помочь пережить выброс вне укрытия.";
		base.WeightSubject = 0.1f;
		base.Sanitation = 0f;
		base.XRaySanitation = -1;
		base.ProtectionFromEject = 39;
		base.Bleeding = 0f;
		base.TypeSubj = TypeSubject.OtherSubject;
	}
}
