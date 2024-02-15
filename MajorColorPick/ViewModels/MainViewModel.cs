using Avalonia.Media;
using Avalonia.Media.Imaging;
using MajorColorPick.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Windows.Input;

namespace MajorColorPick.ViewModels;

public class MainViewModel : ViewModelBase
{
    private Bitmap? _image;
	private IBrush _color1;
	private IBrush _color2;
	private IBrush _color3;
	private IBrush _color4;

	public Bitmap? Image
    {
		get => _image;
		set => this.RaiseAndSetIfChanged(ref _image, value);
	}

	public IBrush Color1
	{
		get => _color1;
		set => this.RaiseAndSetIfChanged(ref _color1, value);
	}
	public IBrush Color2
	{
		get => _color2;
		set => this.RaiseAndSetIfChanged(ref _color2, value);
	}
	public IBrush Color3
	{
		get => _color3;
		set => this.RaiseAndSetIfChanged(ref _color3, value);
	}
	public IBrush Color4
	{
		get => _color4;
		set => this.RaiseAndSetIfChanged(ref _color4, value);
	}

	public MainViewModel()
	{

	}

	public async void SetImagePreview(Bitmap image)
	{
		Image = image;
		List<Color> colors = await BitmapAnalysis.MajorColor(image, 50);
		Color1 = Brush.Parse(colors[0].ToString());
		Color2 = Brush.Parse(colors[1].ToString());
		Color3 = Brush.Parse(colors[2].ToString());
		Color4 = Brush.Parse(colors[3].ToString());
	}
}
