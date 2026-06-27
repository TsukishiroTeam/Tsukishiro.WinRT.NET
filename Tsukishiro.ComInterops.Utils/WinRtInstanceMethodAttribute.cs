using System;

namespace Tsukishiro.Windows.Runtime;

[AttributeUsage(AttributeTargets.Method)]
public class WinRtInstanceMethodAttribute(string EntryPoint) : Attribute;