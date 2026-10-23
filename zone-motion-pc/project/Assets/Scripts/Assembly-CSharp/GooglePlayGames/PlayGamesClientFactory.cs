using GooglePlayGames.Android;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames
{
	internal class PlayGamesClientFactory
	{
		internal static IPlayGamesClient GetPlatformPlayGamesClient(PlayGamesClientConfiguration config)
		{
			if (Application.isEditor || Application.platform != RuntimePlatform.Android)
			{
				GooglePlayGames.OurUtils.Logger.d("Google Play is unavailable on this platform; using the offline client.");
				return new DummyClient();
			}
			GooglePlayGames.OurUtils.Logger.d("Creating Android IPlayGamesClient Client");
			return new NativeClient(config, new AndroidClient());
		}
	}
}
