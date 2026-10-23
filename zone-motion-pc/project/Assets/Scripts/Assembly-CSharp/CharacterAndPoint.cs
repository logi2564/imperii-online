using System;

[Serializable]
public class CharacterAndPoint
{
	public string _curMap;

	public string _nameU;

	public string _nameCharac;

	public int _typeCharInt;

	public bool _controlGamer;

	public bool _life;

	public string _curGexCharName;

	public int _skill;

	public string _suitCharName;

	public float _suitCharState;

	public int _suitCharContainer;

	public bool SingUG_suit;

	public string[] _ArtContainer = new string[4];

	public float WeightUpGrade;

	public float WeightUpGradeWeapon;

	public float UpGrade;

	public float WeaponUpGrade;

	public string _weaponCharName;

	public float _weaponCharState;

	public bool _weaponCharSightInstallation;

	public bool SingUG_weapon;

	public int CartridgeInt;

	public string _detectorCharName;

	public int _cash = 1800;

	public float _curHealth = 50f;

	public float _bleeding;

	public int _diseaseXRay;

	public int _chemicalBurn;

	public int _burn;

	public bool _bonus;

	public int _ageOfDeath;

	public int _satietyCh;

	public int _thirst;

	public bool _exchange;

	public bool _repair;

	public bool _medic;

	public bool _taskChoise;

	public string[] _CharBackpack = new string[20];

	public int[] _StateCharBackpack = new int[20];

	public int[] _StackCharBackpack = new int[20];

	public bool[] _StackCharBackpackWSI = new bool[20];

	public int[] _StackCharBackpackContainer = new int[20];

	public float[] _StackCharWeightUpGrade = new float[20];

	public float[] _StackCharUpGrade = new float[20];

	public bool[] _SingUG = new bool[20];

	public int[] _StackCartridge = new int[20];

	public int PSIprotection;

	public float Accuracy;

	public int Andurance;

	public float HealthAdditional;
}
