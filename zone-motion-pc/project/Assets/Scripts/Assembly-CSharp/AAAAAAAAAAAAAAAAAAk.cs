using UnityEngine;

public class AAAAAAAAAAAAAAAAAAk
{
	public enum TypeWeapon
	{
		Weapon = 0,
		Gun = 1,
		None = 2,
		Control = 3
	}

	public enum TypeSubject
	{
		None = 0,
		Suit = 1,
		Weapon = 2,
		Artefact = 3,
		Detector = 4,
		MutantsSubject = 5,
		OtherSubject = 6,
		QuestSubject = 7,
		Grenade = 8,
		Catridge = 9,
		Money = 10,
		InformationSubject = 11
	}

	public enum TypeGrenade
	{
		None = 0,
		NATO = 1,
		USSR = 2
	}

	private string AAAAAAAAAAAAAAAAAAAAu = "None";

	private string AAAAAAAAAAAAAAAAAAAAAAw = "None";

	private Texture2D AAAAAAAAAAAAAAAAAAAAAAx;

	private Texture2D AAAAAAAAAAAAAAAk;

	private Texture2D AAAAAAAAAAAAAAAAAAbc;

	private Texture2D AAAAAAAAAAAAAAAAAAAAAAy;

	private Texture2D AAAAAAAAAAAAAAAAAAAAAAz;

	private Texture2D AAAAAAAAAAAAAAAAAAAAv;

	private AudioClip AAAAAAAAAAAAAAAAAAbd;

	private AudioClip AAAAAAAAAAAAAAAAAu;

	private AudioClip AAAAAAAAAAAAAAAAAAl;

	private int AAAAAAAAAAAAAAAl;

	private string AAAAAAAAAAAAAAAAj = "None";

	private string AAAAAAAAAAAAAAAAk;

	private float AAAAAAAAAAAAAAAm;

	private float AAAAAAAAAAAAAAAAAAm;

	private TypeSubject AAAAAAAAAAAAAAAAAAAAw;

	private float AAAAAAAAAAAAAAAAAAAAAba;

	private float AAAAAAAAAAAAAAAAl;

	private float AAAAAAAAAAAAAAAAAAbe;

	private int AAAAAAAAAAAAAAAn;

	private int AAAAAAAAAAAAAAAAAAAAAbb;

	private float AAAAAAAAAAAAAAAAm = 100f;

	private float AAAAAAAAAAAAAAAo = 0.3f;

	private int AAAAAAAAAAAAAAAAAv;

	private int AAAAAAAAAAAAAAAAn;

	private int AAAAAAAAAAAAAAAAo;

	private int AAAAAAAAAAAAAAAAAAn;

	private int AAAAAAAAAAAAAAAp;

	private float AAAAAAAAAAAAAAAAAAAAAbc;

	private bool AAAAAAAAAAAAAAAAp;

	private int AAAAAAAAAAAAAAAAAAo = 1;

	private bool AAAAAAAAAAAAAAAAAAAAba;

	private bool AAAAAAAAAAAAAAAAAAAAbb;

	private string AAAAAAAAAAAAAAAAAAAAx;

	private bool AAAAAAAAAAAAAAAAq;

	private bool AAAAAAAAAAAAAAAAAAbf;

	private string AAAAAAAAAAAAAAAAAAAAbc;

	private int AAAAAAAAAAAAAAAAAAAAAbd;

	private int AAAAAAAAAAAAAAAAAAAAAbe;

	private bool AAAAAAAAAAAAAAAq;

	private string AAAAAAAAAAAAAAAAAAbg;

	private TypeGrenade AAAAAAAAAAAAAAAr;

	private int AAAAAAAAAAAAAAAAAAp;

	private float AAAAAAAAAAAAAAAAAAbh;

	private float AAAAAAAAAAAAAAAAAAh;

	private float AAAAAAAAAAAAAAAAAAAAy;

	private int AAAAAAAAAAAAAAAAAAAAbd;

	private int AAAAAAAAAAAAAAAAAAAAAv;

	private int AAAAAAAAAAAAAAAh;

	private TypeWeapon AAAAAAAAAAAAAAAAAAq;

	public TypeWeapon Type_Weapon
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAq;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAq = value;
		}
	}

	public string CartridgeType
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAbg;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAbg = value;
		}
	}

	public bool SingModification
	{
		get
		{
			return AAAAAAAAAAAAAAAq;
		}
		set
		{
			AAAAAAAAAAAAAAAq = value;
		}
	}

	public float WeightUpGrade
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAm;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAm = value;
		}
	}

	public float UpGrade
	{
		get
		{
			return AAAAAAAAAAAAAAAAl;
		}
		set
		{
			AAAAAAAAAAAAAAAAl = value;
		}
	}

	public int ArtContainer
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAbe;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAbe = value;
		}
	}

	public int ProtectionFromEject
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAbd;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAbd = value;
		}
	}

	public string NameOfgrenadeInstallation
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAbc;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAbc = value;
		}
	}

	public bool GrenadePossibilityOfInstallation
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAbf;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAbf = value;
		}
	}

	public bool GrenadeInstallation
	{
		get
		{
			return AAAAAAAAAAAAAAAAq;
		}
		set
		{
			AAAAAAAAAAAAAAAAq = value;
		}
	}

	public string NameOfSightInstallation
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAx;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAx = value;
		}
	}

	public bool PossibilityOfInstallation
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAbb;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAbb = value;
		}
	}

	public bool SightInstallation
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAba;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAba = value;
		}
	}

	public int Stack
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAo;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAo = value;
		}
	}

	public float RateOfFire
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAbc;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAbc = value;
		}
	}

	public AudioClip AudioFire
	{
		get
		{
			return AAAAAAAAAAAAAAAAAu;
		}
		set
		{
			AAAAAAAAAAAAAAAAAu = value;
		}
	}

	public AudioClip AudioReload
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAl;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAl = value;
		}
	}

	public AudioClip AudioSlot
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAbd;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAbd = value;
		}
	}

	public bool AutomaticFire
	{
		get
		{
			return AAAAAAAAAAAAAAAAp;
		}
		set
		{
			AAAAAAAAAAAAAAAAp = value;
		}
	}

	public int CartridgeInMagazineFull
	{
		get
		{
			return AAAAAAAAAAAAAAAp;
		}
		set
		{
			AAAAAAAAAAAAAAAp = value;
		}
	}

	public int Cartridge
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAn;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAn = value;
		}
	}

	public int XRayProtection
	{
		get
		{
			return AAAAAAAAAAAAAAAAAv;
		}
		set
		{
			AAAAAAAAAAAAAAAAAv = value;
		}
	}

	public int XRaySanitation
	{
		get
		{
			return AAAAAAAAAAAAAAAAn;
		}
		set
		{
			AAAAAAAAAAAAAAAAn = value;
		}
	}

	public int XrayNegatife
	{
		get
		{
			return AAAAAAAAAAAAAAAAo;
		}
		set
		{
			AAAAAAAAAAAAAAAAo = value;
		}
	}

	public int PsiProtection
	{
		get
		{
			return AAAAAAAAAAAAAAAh;
		}
		set
		{
			AAAAAAAAAAAAAAAh = value;
		}
	}

	public float Sanitation
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAbh;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAbh = value;
		}
	}

	public float Bleeding
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAh;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAh = value;
		}
	}

	public float Force
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAy;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAy = value;
		}
	}

	public float State
	{
		get
		{
			return AAAAAAAAAAAAAAAAm;
		}
		set
		{
			if (AAAAAAAAAAAAAAAAm >= 0f && AAAAAAAAAAAAAAAAm <= 100f)
			{
				AAAAAAAAAAAAAAAAm = value;
			}
			if (AAAAAAAAAAAAAAAAm < 0f)
			{
				AAAAAAAAAAAAAAAAm = 0f;
			}
			if (AAAAAAAAAAAAAAAAm > 100f)
			{
				AAAAAAAAAAAAAAAAm = 100f;
			}
		}
	}

	public float Protection
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAba;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAba = value;
		}
	}

	public int Doping
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAp;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAp = value;
		}
	}

	public string IngNameSubject
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAu;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAu = value;
		}
	}

	public string NameSubject
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAw;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAw = value;
		}
	}

	public string TextOfDocument
	{
		get
		{
			return AAAAAAAAAAAAAAAAk;
		}
		set
		{
			AAAAAAAAAAAAAAAAk = value;
		}
	}

	public Texture2D TextureSubject
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAx;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAx = value;
		}
	}

	public Texture2D TextureSubjectSniper
	{
		get
		{
			return AAAAAAAAAAAAAAAk;
		}
		set
		{
			AAAAAAAAAAAAAAAk = value;
		}
	}

	public Texture2D IconCharacter
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAbc;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAbc = value;
		}
	}

	public Texture2D IconCharacterDead
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAy;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAy = value;
		}
	}

	public Texture2D FireButton
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAz;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAz = value;
		}
	}

	public Texture2D CartridgesImage
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAv;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAv = value;
		}
	}

	public int CostSubject
	{
		get
		{
			return AAAAAAAAAAAAAAAl;
		}
		set
		{
			AAAAAAAAAAAAAAAl = value;
		}
	}

	public string DescriptionSubject
	{
		get
		{
			return AAAAAAAAAAAAAAAAj;
		}
		set
		{
			AAAAAAAAAAAAAAAAj = value;
		}
	}

	public float WeightSubject
	{
		get
		{
			return AAAAAAAAAAAAAAAm;
		}
		set
		{
			AAAAAAAAAAAAAAAm = value;
		}
	}

	public TypeSubject TypeSubj
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAw;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAw = value;
		}
	}

	public TypeGrenade TypeGren
	{
		get
		{
			return AAAAAAAAAAAAAAAr;
		}
		set
		{
			AAAAAAAAAAAAAAAr = value;
		}
	}

	public float Damage
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAbe;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAbe = value;
		}
	}

	public int Range
	{
		get
		{
			return AAAAAAAAAAAAAAAn;
		}
		set
		{
			AAAAAAAAAAAAAAAn = value;
		}
	}

	public int MinRange
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAbb;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAbb = value;
		}
	}

	public float Wear
	{
		get
		{
			return AAAAAAAAAAAAAAAo;
		}
		set
		{
			AAAAAAAAAAAAAAAo = value;
		}
	}

	public int Hunger
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAbd;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAbd = value;
		}
	}

	public int Thirst
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAv;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAv = value;
		}
	}
}
