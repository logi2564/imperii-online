using System;
using Com.Google.Android.Gms.Common.Api;
using Google.Developers;

namespace Com.Google.Android.Gms.Games.Stats
{
	public class AAAAAAAAAAAAAAAAb : JavaObjWrapper, Stats
	{
		private const string AAAAAAAAAAAAAAAAAAAa = "com/google/android/gms/games/stats/Stats";

		public AAAAAAAAAAAAAAAAb(IntPtr ptr)
			: base(ptr)
		{
		}

		public PendingResult<AAAAAAAAAAAAAAAAAAAAAa> loadPlayerStats(AAAAAAAAAAAAAAAAAAAAa arg_GoogleApiClient_1, bool arg_bool_2)
		{
			IntPtr ptr = InvokeCall<IntPtr>("loadPlayerStats", "(Lcom/google/android/gms/common/api/GoogleApiClient;Z)Lcom/google/android/gms/common/api/PendingResult;", new object[2] { arg_GoogleApiClient_1, arg_bool_2 });
			return new PendingResult<AAAAAAAAAAAAAAAAAAAAAa>(ptr);
		}
	}
}
