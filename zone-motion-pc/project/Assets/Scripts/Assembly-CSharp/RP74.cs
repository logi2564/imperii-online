using UnityEngine;

public class RP74 : ConstructorWeapon
{
	public RP74()
	{
		base.NameSubject = "РП-74";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/rp-74");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/rp-74");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/rpFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/7.62x54-7H1");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/rpk74_shot_1");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/rpk74_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/rpk_reload");
		base.CostSubject = 50000;
		base.CartridgeType = "7,62x54 мм 7H1";
		base.DescriptionSubject = "Ручной пулемёт, несмотря на свою высокую массу и низкую точность боя, нашел себе применение и в Зоне. Используется в основном для борьбы с превосходящим по силе противником или при зачистке логов мутантов. Однако подобного оружия в Зоне крайне мало, его сложно купить у торговцев или можно получить в награду за сложную работенку... Патроны: " + base.CartridgeType;
		base.Damage = 22f;
		base.Range = 5;
		base.MinRange = 1;
		base.PossibilityOfInstallation = false;
		base.SightInstallation = false;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 50;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 8f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.23f;
		base.RateOfFire = 0.4f;
	}
}
