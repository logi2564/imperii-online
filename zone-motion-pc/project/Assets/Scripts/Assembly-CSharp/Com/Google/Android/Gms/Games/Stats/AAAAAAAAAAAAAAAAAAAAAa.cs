using System;
using Com.Google.Android.Gms.Common.Api;
using Google.Developers;

namespace Com.Google.Android.Gms.Games.Stats
{
	public class AAAAAAAAAAAAAAAAAAAAAa : JavaObjWrapper, AAAAAAAAAAAAAAAAAAAb, AAAAAAAAAAAAAAAAAAAAAAa
	{
		private const string AAAAAAAAAAAAAAAAAAAa = "com/google/android/gms/games/stats/Stats$LoadPlayerStatsResult";

		public AAAAAAAAAAAAAAAAAAAAAa(IntPtr ptr)
			: base(ptr)
		{
		}

		public AAAAAAAAAAAAAAAAAAAAAb getPlayerStats()
		{
			IntPtr ptr = InvokeCall<IntPtr>("getPlayerStats", "()Lcom/google/android/gms/games/stats/PlayerStats;", new object[0]);
			return new AAAAAAAAAAAAAAAAa(ptr);
		}

		public AAAAAAAAAAAAAAAAAa getStatus()
		{
			IntPtr ptr = InvokeCall<IntPtr>("getStatus", "()Lcom/google/android/gms/common/api/Status;", new object[0]);
			return new AAAAAAAAAAAAAAAAAa(ptr);
		}
	}
}
