namespace Tsukishiro.Windows.Runtime;

[AttributeUsage(AttributeTargets.Class)]
public class WinRtClassImportAttribute(string ns, string className) : Attribute;
