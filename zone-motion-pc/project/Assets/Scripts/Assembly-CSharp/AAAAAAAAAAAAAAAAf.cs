using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAf
{
	public enum TypeCharacter
	{
		None = 0,
		Странник = 1,
		Одиночки = 2,
		Бандиты = 3,
		Военные = 4,
		Долг = 5,
		Наемники = 6,
		Свобода = 7,
		Чистое_небо = 8,
		Монолит = 9,
		Зомби = 10,
		Плоть = 11,
		Пес = 12,
		Псевдособака = 13,
		Снорк = 14,
		Кабан = 15,
		Кровосос = 16,
		Контролер = 17,
		Мутанты = 18,
		Ученые = 19,
		Ренегаты = 20
	}

	private string AAAAAAAAAAAAAAAAAAAx;

	private bool AAAAAAAAAAAAAAAAAAAAj;

	private bool AAAAAAAAAAAAAAAAAAAAAo = true;

	private AudioClip AAAAAAAAAAAAAAAAAAAAk;

	private AudioClip AAAAAAAAAAAAAAAAAAAAAAk;

	private AudioClip AAAAAAAAAAAAAAAAAn;

	private AudioClip AAAAAAAAAAAAAAAAAo;

	private AudioClip AAAAAAAAAAAAAAAAAAe;

	private List<AudioClip> AAAAAAAAAAAAAAAAAAAAl;

	private TypeCharacter AAAAAAAAAAAAAAAAAAAAAAl;

	private int AAAAAAAAAAAAAAAAAp;

	private string AAAAAAAAAAAAAAAAAAf = string.Empty;

	private string AAAAAAAAAAAAAAAAAAAAm = string.Empty;

	private ConstructorGex AAAAAAAAAAAAAAAAAAAAAAm;

	private ConstructorGex AAAAAAAAAAAAAAAAAAAAAp;

	private ConstructorGex AAAAAAAAAAAAAAAAAAAAAq;

	private string AAAAAAAAAAAAAAAd;

	private Texture2D AAAAAAAAAAAAAAAAAAAAAAn;

	private GameObject AAAAAAAAAAAAAAAe;

	private int AAAAAAAAAAAAAAAAAq;

	private AAAAAAAAAAAAAAAAAAk AAAAAAAAAAAAAAAAAAAAAr;

	private AAAAAAAAAAAAAAAAAAk AAAAAAAAAAAAAAAAAAAAAAo;

	private AAAAAAAAAAAAAAAAAAk AAAAAAAAAAAAAAAAAAAy;

	private AAAAAAAAAAAAAAAAAAk[] AAAAAAAAAAAAAAAf = new AAAAAAAAAAAAAAAAAAk[4];

	private AAAAAAAAAAAAAAAAAAk AAAAAAAAAAAAAAAAAAAAn;

	private int AAAAAAAAAAAAAAAAAAg = 1800;

	private float AAAAAAAAAAAAAAAAAAAAAs = 50f;

	private float AAAAAAAAAAAAAAAAAAh;

	private int AAAAAAAAAAAAAAAAg;

	private int AAAAAAAAAAAAAAAg;

	private int AAAAAAAAAAAAAAAAAAAAAAp;

	private int AAAAAAAAAAAAAAAAAAAAAt;

	private int AAAAAAAAAAAAAAAAAAAAAu = 65;

	private int AAAAAAAAAAAAAAAAAAAAAv = 65;

	private bool AAAAAAAAAAAAAAAAh;

	private bool AAAAAAAAAAAAAAAAAAAAo;

	private int AAAAAAAAAAAAAAAAAAAAp;

	private int AAAAAAAAAAAAAAAh;

	private float AAAAAAAAAAAAAAAAAAAAAAq;

	private int AAAAAAAAAAAAAAAAi;

	private float AAAAAAAAAAAAAAAAAr;

	private AAAAAAAAAAAAAAAAAAk[] AAAAAAAAAAAAAAAAAAAAAAr = new AAAAAAAAAAAAAAAAAAk[20];

	public List<AudioClip> NPSattackVoice
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAl;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAl = value;
		}
	}

	public float Accuracy
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAq;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAq = value;
		}
	}

	public int Andurance
	{
		get
		{
			return AAAAAAAAAAAAAAAAi;
		}
		set
		{
			AAAAAAAAAAAAAAAAi = value;
		}
	}

	public float HealthAdditional
	{
		get
		{
			return AAAAAAAAAAAAAAAAAr;
		}
		set
		{
			if (value <= 100f)
			{
				AAAAAAAAAAAAAAAAAr = value;
			}
			if (value > 100f)
			{
				AAAAAAAAAAAAAAAAAr = 100f;
			}
		}
	}

	public AudioClip AudioPain_R
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAe;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAe = value;
		}
	}

	public AudioClip AudioPain_L
	{
		get
		{
			return AAAAAAAAAAAAAAAAAo;
		}
		set
		{
			AAAAAAAAAAAAAAAAAo = value;
		}
	}

	public AudioClip AudioStep_L
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAk;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAk = value;
		}
	}

	public AudioClip AudioStep_R
	{
		get
		{
			return AAAAAAAAAAAAAAAAAn;
		}
		set
		{
			AAAAAAAAAAAAAAAAAn = value;
		}
	}

	public AudioClip AudioDeath
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAk;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAk = value;
		}
	}

	public bool Bonus
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAo;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAo = value;
		}
	}

	public int AgeOfDeath
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAp;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAp = value;
		}
	}

	public bool Alarm
	{
		get
		{
			return AAAAAAAAAAAAAAAAh;
		}
		set
		{
			AAAAAAAAAAAAAAAAh = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk[] ArtContainers
	{
		get
		{
			return AAAAAAAAAAAAAAAf;
		}
		set
		{
			AAAAAAAAAAAAAAAf = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk[] CharBackpack
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAr;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAr = value;
		}
	}

	public int DiseaseXRay
	{
		get
		{
			return AAAAAAAAAAAAAAAAg;
		}
		set
		{
			if (value >= 0)
			{
				AAAAAAAAAAAAAAAAg = value;
			}
			if (value < 0)
			{
				AAAAAAAAAAAAAAAAg = 0;
			}
		}
	}

	public int ChemicalBurnCh
	{
		get
		{
			return AAAAAAAAAAAAAAAg;
		}
		set
		{
			if (value >= 0)
			{
				AAAAAAAAAAAAAAAg = value;
			}
			if (value < 0)
			{
				AAAAAAAAAAAAAAAg = 0;
			}
		}
	}

	public int BurnCh
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAp;
		}
		set
		{
			if (value >= 0)
			{
				AAAAAAAAAAAAAAAAAAAAAAp = value;
			}
			if (value < 0)
			{
				AAAAAAAAAAAAAAAAAAAAAAp = 0;
			}
		}
	}

	public bool ControlGamer
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAj;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAj = value;
		}
	}

	public bool Life
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAo;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAo = value;
		}
	}

	public int PritectionEjectEffect
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAt;
		}
		set
		{
			if (value >= 0)
			{
				AAAAAAAAAAAAAAAAAAAAAt = value;
			}
			if (value < 0)
			{
				AAAAAAAAAAAAAAAAAAAAAt = 0;
			}
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
			if (value >= 0f)
			{
				AAAAAAAAAAAAAAAAAAh = value;
			}
			if (value < 0f)
			{
				AAAAAAAAAAAAAAAAAAh = 0f;
			}
		}
	}

	public TypeCharacter TypeChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAl;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAl = value;
		}
	}

	public string NameCharac
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAf;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAf = value;
		}
	}

	public string NameU
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAm;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAm = value;
		}
	}

	public string Aggressor
	{
		get
		{
			return AAAAAAAAAAAAAAAd;
		}
		set
		{
			AAAAAAAAAAAAAAAd = value;
		}
	}

	public ConstructorGex CurGexChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAm;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAm = value;
		}
	}

	public ConstructorGex TaskGexChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAp;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAp = value;
		}
	}

	public ConstructorGex AggressorGexChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAq;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAq = value;
		}
	}

	public Texture2D TextureChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAn;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAn = value;
		}
	}

	public GameObject CharUnits
	{
		get
		{
			return AAAAAAAAAAAAAAAe;
		}
		set
		{
			AAAAAAAAAAAAAAAe = value;
		}
	}

	public int Skill
	{
		get
		{
			return AAAAAAAAAAAAAAAAAq;
		}
		set
		{
			AAAAAAAAAAAAAAAAAq = value;
		}
	}

	public int PSIprotection
	{
		get
		{
			return AAAAAAAAAAAAAAAh;
		}
		set
		{
			if (value < 0)
			{
				AAAAAAAAAAAAAAAh = 0;
			}
			if (value >= 0 && value <= 4)
			{
				AAAAAAAAAAAAAAAh = value;
			}
			if (value > 4)
			{
				AAAAAAAAAAAAAAAh = 4;
			}
		}
	}

	public AAAAAAAAAAAAAAAAAAk SuitChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAr;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAr = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk WeaponChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAAo;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAAAo = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk ArtChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAy;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAy = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk DetectorChar
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAn;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAAn = value;
		}
	}

	public int Cash
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAg;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAg = value;
		}
	}

	public float CurHealth
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAs;
		}
		set
		{
			if (value <= 50f)
			{
				AAAAAAAAAAAAAAAAAAAAAs = value;
			}
			if (value > 50f)
			{
				AAAAAAAAAAAAAAAAAAAAAs = 50f;
			}
		}
	}

	public int TypeChInt
	{
		get
		{
			return AAAAAAAAAAAAAAAAAp;
		}
		set
		{
			AAAAAAAAAAAAAAAAAp = value;
		}
	}

	public string CurMap
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAx;
		}
		set
		{
			AAAAAAAAAAAAAAAAAAAx = value;
		}
	}

	public int Satiety
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAAu;
		}
		set
		{
			if (value <= 65)
			{
				AAAAAAAAAAAAAAAAAAAAAu = value;
			}
			if (value > 65)
			{
				AAAAAAAAAAAAAAAAAAAAAu = 65;
			}
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
			if (value <= 65)
			{
				AAAAAAAAAAAAAAAAAAAAAv = value;
			}
			if (value > 65)
			{
				AAAAAAAAAAAAAAAAAAAAAv = 65;
			}
		}
	}
}
