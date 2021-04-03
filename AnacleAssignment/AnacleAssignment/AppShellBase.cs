using Xamarin.Forms.Xaml;

namespace AnacleAssignment
{
    [XamlCompilation(XamlCompilationOptions.Compile), XamlFilePath("AppShell.xaml")]
    public class AppShellBase
    {

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent()
        {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(AppShell));
        }
    }
}