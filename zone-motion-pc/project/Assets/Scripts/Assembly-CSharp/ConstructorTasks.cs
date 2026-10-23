using System;
using UnityEngine;

[Serializable]
public class ConstructorTasks
{
	private string _nameTask = "None";

	private string _textTask = "None";

	private string _descriptionTask = "None";

	private AAAAAAAAAAAAAAAAAAk _questSubject;

	private AAAAAAAAAAAAAAAAAAk _rewardSubject;

	private int _rewardMoney;

	private Texture2D _imageTask;

	private bool _additionalTask;

	private bool _subjectQuest;

	private bool _manySubjectsQuest;

	private bool _balansQuest;

	private bool _killQuest;

	private bool _guideQuest;

	private bool _captureQuest;

	private bool _getToPointQuest;

	private int _numberInLib;

	private int _numberPointOfGuide;

	private int _numberDealer;

	private int _numberTurgetInData;

	private int _numberEnemy;

	private string _namePointTask;

	private string _killCharacterName;

	private string _mapName;

	private string _groupName;

	public string GroupName
	{
		get
		{
			return _groupName;
		}
		set
		{
			_groupName = value;
		}
	}

	public int NumberEnemy
	{
		get
		{
			return _numberEnemy;
		}
		set
		{
			_numberEnemy = value;
		}
	}

	public string MapName
	{
		get
		{
			return _mapName;
		}
		set
		{
			_mapName = value;
		}
	}

	public int NumberPointOfGuide
	{
		get
		{
			return _numberPointOfGuide;
		}
		set
		{
			_numberPointOfGuide = value;
		}
	}

	public int NumberTurgetInData
	{
		get
		{
			return _numberTurgetInData;
		}
		set
		{
			_numberTurgetInData = value;
		}
	}

	public string KillCharacterName
	{
		get
		{
			return _killCharacterName;
		}
		set
		{
			_killCharacterName = value;
		}
	}

	public int NumberDealer
	{
		get
		{
			return _numberDealer;
		}
		set
		{
			_numberDealer = value;
		}
	}

	public string NamePointTask
	{
		get
		{
			return _namePointTask;
		}
		set
		{
			_namePointTask = value;
		}
	}

	public int NumberInLib
	{
		get
		{
			return _numberInLib;
		}
		set
		{
			_numberInLib = value;
		}
	}

	public bool AdditionalTask
	{
		get
		{
			return _additionalTask;
		}
		set
		{
			_additionalTask = value;
		}
	}

	public bool SubjectQuest
	{
		get
		{
			return _subjectQuest;
		}
		set
		{
			_subjectQuest = value;
		}
	}

	public bool ManySubjectsQuest
	{
		get
		{
			return _manySubjectsQuest;
		}
		set
		{
			_manySubjectsQuest = value;
		}
	}

	public bool KillQuest
	{
		get
		{
			return _killQuest;
		}
		set
		{
			_killQuest = value;
		}
	}

	public bool BalansQuest
	{
		get
		{
			return _balansQuest;
		}
		set
		{
			_balansQuest = value;
		}
	}

	public bool GuideQuest
	{
		get
		{
			return _guideQuest;
		}
		set
		{
			_guideQuest = value;
		}
	}

	public bool CaptureQuest
	{
		get
		{
			return _captureQuest;
		}
		set
		{
			_captureQuest = value;
		}
	}

	public bool GetToPointQuest
	{
		get
		{
			return _getToPointQuest;
		}
		set
		{
			_getToPointQuest = value;
		}
	}

	public string NameTask
	{
		get
		{
			return _nameTask;
		}
		set
		{
			_nameTask = value;
		}
	}

	public string TextTask
	{
		get
		{
			return _textTask;
		}
		set
		{
			_textTask = value;
		}
	}

	public string DescriptionTask
	{
		get
		{
			return _descriptionTask;
		}
		set
		{
			_descriptionTask = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk QuestSubject
	{
		get
		{
			return _questSubject;
		}
		set
		{
			_questSubject = value;
		}
	}

	public AAAAAAAAAAAAAAAAAAk RewardSubject
	{
		get
		{
			return _rewardSubject;
		}
		set
		{
			_rewardSubject = value;
		}
	}

	public int RewardMoney
	{
		get
		{
			return _rewardMoney;
		}
		set
		{
			_rewardMoney = value;
		}
	}

	public Texture2D ImageTask
	{
		get
		{
			return _imageTask;
		}
		set
		{
			_imageTask = value;
		}
	}
}
