using System;
using System.Collections.Generic;

[Serializable]
public class SaveToulsAndStatus
{
	public bool helpBool;

	public float gameSpeed;

	public float sizeMap;

	public string CurrentScene;

	public int _PointsMove;

	public int _curCharacter;

	public float _difficultyLevel;

	public int _ejectTime;

	public int[] statusG = new int[13];

	public List<int> statusGroups = new List<int>();

	public List<TaskForSave> _task = new List<TaskForSave>();

	public List<string> ListOldTask = new List<string>();
}
