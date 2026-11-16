namespace BenailuTech;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCaptureClicked(object sender, EventArgs e)
    {
        try
        {
            StatusLabel.Text = "Solicitando acceso a la cámara...";
            var permission = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (permission != PermissionStatus.Granted)
                permission = await Permissions.RequestAsync<Permissions.Camera>();

            if (permission != PermissionStatus.Granted)
            {
                StatusLabel.Text = "Permiso de cámara denegado.";
                return;
            }

            if (!MediaPicker.Default.IsCaptureSupported)
            {
                StatusLabel.Text = "Cámara no disponible.";
                return;
            }

            var photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo == null)
            {
                StatusLabel.Text = "Captura cancelada.";
                return;
            }

            using var stream = await photo.OpenReadAsync();
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();
            PhotoPreview.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            StatusLabel.Text = "Fotografía capturada correctamente.";
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error: {ex.Message}";
        }
    }

    private void OnRepeatClicked(object sender, EventArgs e)
    {
        PhotoPreview.Source = null;
        StatusLabel.Text = "Esperando nueva captura...";
    }
}