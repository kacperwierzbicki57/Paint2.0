using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

//#nullable disable
namespace Paint2._0.Properties
{

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal Resources()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (Paint2._0.Properties.Resources.resourceMan == null)
        Paint2._0.Properties.Resources.resourceMan = new ResourceManager("Paint2._0.Properties.Resources", typeof (Paint2._0.Properties.Resources).Assembly);
      return Paint2._0.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => Paint2._0.Properties.Resources.resourceCulture;
    set => Paint2._0.Properties.Resources.resourceCulture = value;
  }
}

}