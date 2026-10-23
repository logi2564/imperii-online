using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbg : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAbg()
	{
		base.NameSubject = "Научный костюм «Броня Монолита»";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/SevaMonolith");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharSevaMonolith");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 29000;
		base.DescriptionSubject = "Полностью готовые к бою бронекостюмы группировки «Монолит». Имеет усовершенственную систему замкнутого дыхания. Пулестойкость тут дошла до самой высокой степени для научного костюма. Прокаченная версия может тягаться с экзоскелетом в плане пулестойкости и превосходит в плане защиты от аномалий.";
		base.WeightSubject = 7.5f;
		base.Protection = 68f;
		base.ProtectionFromEject = 10;
		base.XRayProtection = 5;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 3;
		base.PsiProtection = 1;
	}
}
