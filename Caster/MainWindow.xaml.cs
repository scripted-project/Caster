using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;
using Caster.Components;

namespace Caster;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        InitializeAudioSources();

        string jsonString = File.ReadAllText("./data/data.json");
        DataJSON jsonData = JsonSerializer.Deserialize<DataJSON>(jsonString)!;

        if (jsonData.Version != null) { versionLabel.Content = jsonData.Version; }
        if (jsonData.Profiles != null && jsonData.Profiles["base"] != null)
        {
            Profile baseProf = jsonData.Profiles["base"];
            if (baseProf.Defaults != null)
            {
                Defaults defaults = baseProf.Defaults;
                if (defaults.Audio != null) { audioSelection.SelectedItem = defaults.Audio; }
                if (defaults.Video != null) { videoSelection.SelectedItem = defaults.Video; }
            }
        }
    }
}