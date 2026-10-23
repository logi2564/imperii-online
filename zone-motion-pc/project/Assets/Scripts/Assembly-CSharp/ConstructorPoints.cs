using System;
using UnityEngine;

[Serializable]
public class ConstructorPoints
{
	public enum PointTypes
	{
		Construction = 0,
		Field = 1,
		Anomaly = 2,
		None = 3
	}

	public enum PointControl
	{
		None = 0,
		отсутствует = 1,
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
		Кровосос = 15,
		Контролер = 16,
		Мутанты = 17,
		Ученые = 18,
		Ренегаты = 19
	}

	public enum BaseOfGrouping
	{
		None = 0,
		Одиночки = 1,
		Бандиты = 2,
		Военные = 3,
		Долг = 4,
		Наемники = 5,
		Свобода = 6,
		Чистое_небо = 7,
		Монолит = 8,
		Зомби = 9,
		Плоть = 10,
		Пес = 11,
		Псевдособака = 12,
		Снорк = 13,
		Кровосос = 14,
		Контролер = 15,
		Ученые = 16
	}

	private string _curMap;

	private string _namePoint;

	private string _descriptionPoint = "None";

	private Texture2D _texturePoint;

	private GameObject _pointUnits;

	private PointTypes _pointTypes;

	private PointControl _pointControl;

	private bool _exchange;

	private bool _repair;

	private bool _medic;

	private bool _taskChoise;

	private int _dealerInt;

	private int _controlInt;

	private AAAAAAAAAAAAAAAAAAk[] _cache = new AAAAAAAAAAAAAAAAAAk[20];

	private ConstructorGex _curGexPoint;

	private int _xRay;

	private int _chemicalBurn;

	private int _burn;

	private string _teleport = "None";

	private string _teleportName = "None";

	private ConstructorGex _teleportGex;

	private string _teleportDouble = "None";

	private string _teleportNameDouble = "None";

	private ConstructorGex _teleportGexDouble;

	public string namePoint
	{
		get
		{
			return _namePoint;
		}
		set
		{
			_namePoint = value;
		}
	}

	public string DescriptionPoint
	{
		get
		{
			return _descriptionPoint;
		}
		set
		{
			_descriptionPoint = value;
		}
	}

	public Texture2D TexturePoint
	{
		get
		{
			return _texturePoint;
		}
		set
		{
			_texturePoint = value;
		}
	}

	public GameObject PointUnits
	{
		get
		{
			return _pointUnits;
		}
		set
		{
			_pointUnits = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk[] Cache
	{
		get
		{
			return _cache;
		}
		set
		{
			_cache = value;
		}
	}

	public PointTypes pointTypes
	{
		get
		{
			return _pointTypes;
		}
		set
		{
			_pointTypes = value;
		}
	}

	public PointControl pointControl
	{
		get
		{
			return _pointControl;
		}
		set
		{
			_pointControl = value;
		}
	}

	public int ControlInt
	{
		get
		{
			return _controlInt;
		}
		set
		{
			_controlInt = value;
		}
	}

	public int DealerInt
	{
		get
		{
			return _dealerInt;
		}
		set
		{
			_dealerInt = value;
		}
	}

	public bool TaskChoise
	{
		get
		{
			return _taskChoise;
		}
		set
		{
			_taskChoise = value;
		}
	}

	public bool Medic
	{
		get
		{
			return _medic;
		}
		set
		{
			_medic = value;
		}
	}

	public bool exchange
	{
		get
		{
			return _exchange;
		}
		set
		{
			_exchange = value;
		}
	}

	public bool Repair
	{
		get
		{
			return _repair;
		}
		set
		{
			_repair = value;
		}
	}

	public int XRay
	{
		get
		{
			return _xRay;
		}
		set
		{
			_xRay = value;
		}
	}

	public int Burn
	{
		get
		{
			return _burn;
		}
		set
		{
			_burn = value;
		}
	}

	public int ChemicalBurn
	{
		get
		{
			return _chemicalBurn;
		}
		set
		{
			_chemicalBurn = value;
		}
	}

	public ConstructorGex curGexPoint
	{
		get
		{
			return _curGexPoint;
		}
		set
		{
			_curGexPoint = value;
		}
	}

	public string Teleport
	{
		get
		{
			return _teleport;
		}
		set
		{
			_teleport = value;
		}
	}

	public string TeleportName
	{
		get
		{
			return _teleportName;
		}
		set
		{
			_teleportName = value;
		}
	}

	public ConstructorGex TeleportGex
	{
		get
		{
			return _teleportGex;
		}
		set
		{
			_teleportGex = value;
		}
	}

	public string TeleportDouble
	{
		get
		{
			return _teleportDouble;
		}
		set
		{
			_teleportDouble = value;
		}
	}

	public string TeleportNameDouble
	{
		get
		{
			return _teleportNameDouble;
		}
		set
		{
			_teleportNameDouble = value;
		}
	}

	public ConstructorGex TeleportGexDouble
	{
		get
		{
			return _teleportGexDouble;
		}
		set
		{
			_teleportGexDouble = value;
		}
	}

	public string CurMap
	{
		get
		{
			return _curMap;
		}
		set
		{
			_curMap = value;
		}
	}
}
