using System;

namespace Obfuscator.Attribute
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class DoNotObfuscateMethodBodyAttribute : System.Attribute
	{
	}
}
