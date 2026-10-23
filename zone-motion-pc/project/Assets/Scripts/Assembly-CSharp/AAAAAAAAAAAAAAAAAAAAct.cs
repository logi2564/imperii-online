public static class AAAAAAAAAAAAAAAAAAAAct
{
	private static float AAAAAAAAAAAAAAAAAAAcl = 3f;

	public static float AAAAAAAAAAAAAAAAAcf = 6f;

	public static int[,] AAAAAAAAAAAAAAAAAa = new int[13, 13]
	{
		{
			9, 1, 0, 0, 1, 0, 1, 1, 0, 0,
			0, 1, 1
		},
		{
			1, 9, 0, 0, 1, 0, 1, 1, 0, 0,
			0, 1, 1
		},
		{
			0, 0, 9, 0, 0, 1, 1, 0, 0, 0,
			0, 1, 1
		},
		{
			0, 0, 0, 9, 1, 0, 0, 0, 0, 0,
			0, 1, 0
		},
		{
			1, 1, 0, 1, 9, 1, 0, 1, 0, 0,
			0, 1, 0
		},
		{
			0, 0, 1, 0, 1, 9, 1, 0, 0, 0,
			0, 0, 0
		},
		{
			1, 1, 1, 0, 0, 1, 9, 1, 0, 0,
			0, 1, 0
		},
		{
			1, 1, 0, 0, 1, 0, 1, 9, 0, 0,
			0, 1, 0
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 9, 1,
			1, 0, 0
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 9,
			1, 0, 0
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			9, 0, 0
		},
		{
			1, 1, 1, 1, 1, 0, 1, 1, 0, 0,
			0, 9, 1
		},
		{
			1, 1, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 9
		}
	};

	public static int[,] AAAAAAAAAAAAAAAAAcg = new int[13, 13]
	{
		{
			9, 1, 0, 0, 1, 0, 1, 1, 0, 0,
			0, 1, 1
		},
		{
			1, 9, 0, 0, 1, 0, 1, 1, 0, 0,
			0, 1, 1
		},
		{
			0, 0, 9, 0, 0, 1, 1, 0, 0, 0,
			0, 1, 1
		},
		{
			0, 0, 0, 9, 1, 0, 0, 0, 0, 0,
			0, 1, 0
		},
		{
			1, 1, 0, 1, 9, 1, 0, 1, 0, 0,
			0, 1, 0
		},
		{
			0, 0, 1, 0, 1, 9, 1, 0, 0, 0,
			0, 0, 0
		},
		{
			1, 1, 1, 0, 0, 1, 9, 1, 0, 0,
			0, 1, 0
		},
		{
			1, 1, 0, 0, 1, 0, 1, 9, 0, 0,
			0, 1, 0
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 9, 1,
			1, 0, 0
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 9,
			1, 0, 0
		},
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			9, 0, 0
		},
		{
			1, 1, 1, 1, 1, 0, 1, 1, 0, 0,
			0, 9, 1
		},
		{
			1, 1, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 9
		}
	};

	public static int[] AAAAAAAAAAAAAAAcd = new int[13];

	public static float GameSpeed
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAcl;
		}
		set
		{
			if (value <= 7.5f && value >= 1.5f)
			{
				AAAAAAAAAAAAAAAAAAAcl = value;
			}
			if (value > 7.5f)
			{
				AAAAAAAAAAAAAAAAAAAcl = 7.5f;
			}
			if (value < 1.5f)
			{
				AAAAAAAAAAAAAAAAAAAcl = 1.5f;
			}
		}
	}
}
