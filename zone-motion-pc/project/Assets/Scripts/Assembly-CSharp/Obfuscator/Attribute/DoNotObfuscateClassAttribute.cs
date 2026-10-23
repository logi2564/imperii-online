using System;

namespace Obfuscator.Attribute
{
	[AttributeUsage(AttributeTargets.Class)]
	public class DoNotObfuscateClassAttribute : System.Attribute
	{
	}
}
