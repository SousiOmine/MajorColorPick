using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using MajorColorPick.ViewModels;

namespace MajorColorPick.Views;

public partial class MainView : UserControl
{
    private MainViewModel VM
    {
        get { return DataContext as MainViewModel; }
	}

    public MainView()
    {
        InitializeComponent();
    }

    private async void OpenImageDialog(object sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open image",
			AllowMultiple = false,
		});

		if (files.Count > 0)
        {
            await using var stream = await files[0].OpenReadAsync();

            Bitmap bmp = new(stream);
            VM.SetImagePreview(bmp);
		}
	}
}
