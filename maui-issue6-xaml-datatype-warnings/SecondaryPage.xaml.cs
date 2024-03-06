using maui_issue6_xaml_datatype_warnings.ViewModels;

namespace maui_issue6_xaml_datatype_warnings;

public partial class SecondaryPage : ContentPage
{
    public SecondaryPage()
    {
        InitializeComponent();
        BindingContext = new PageViewModel();
    }
}