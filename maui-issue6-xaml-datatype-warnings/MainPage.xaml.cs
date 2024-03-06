using maui_issue6_xaml_datatype_warnings.ViewModels;

namespace maui_issue6_xaml_datatype_warnings;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new PageViewModel();
	}
}

