using System;
using UnityEngine;

[Serializable]
public class ConstructorGex
{
	private int _xGex;

	private int _yGex;

	private string _nameGex;

	private int _id;

	private GameObject _gexGO;

	public int _XGex
	{
		get
		{
			return _xGex;
		}
		set
		{
			_xGex = value;
		}
	}

	public int _YGex
	{
		get
		{
			return _yGex;
		}
		set
		{
			_yGex = value;
		}
	}

	public string NameGex
	{
		get
		{
			return _nameGex;
		}
		set
		{
			_nameGex = value;
		}
	}

	public GameObject GexGO
	{
		get
		{
			return _gexGO;
		}
		set
		{
			_gexGO = value;
		}
	}

	public int ID
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}
}
