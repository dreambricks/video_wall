using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class ProgramSetup : MonoBehaviour
{

    public DisplaySetup displaySetup;
    public GameObject quad;
    public SetupUI setupUI;

    public InputField port;
    public InputField broadCastAddress;
    public Dropdown masterOrSlave;
    public InputField masterExtraDelay;

    public InputField fileName;
    public InputField positionX;
    public InputField positionY;
    public InputField videoSizeW;
    public InputField videoSizeH;

    public void SaveSettings()
    {
        DisplaySetup displaySetup = new DisplaySetup();
        NetworkDisplay networkDisplay = new NetworkDisplay();
        VideoSettings videoSettings = new VideoSettings();

        networkDisplay.Port = port.text;
        networkDisplay.BroadCastAddress = broadCastAddress.text;
        int selectedIndex = masterOrSlave.value;
        networkDisplay.MasterOrSlave = masterOrSlave.options[selectedIndex].text;
        networkDisplay.MasterExtraDelay = masterExtraDelay.text;
        displaySetup.NetworkDisplay= networkDisplay;

        videoSettings.Filename= fileName.text;
        videoSettings.Position = new string[2];
        videoSettings.Position[0] = positionX.text;
        videoSettings.Position[1] = positionY.text;
        videoSettings.VideoSize = new string[2];
        videoSettings.VideoSize[0] = videoSizeW.text;
        videoSettings.VideoSize[1] = videoSizeH.text;
        displaySetup.VideoSettings= videoSettings;

        SaveToJsonFile(displaySetup, "display_data.json");

        
        quad.gameObject.SetActive(true);

        setupUI.gameObject.SetActive(false);
    }


    private void SaveToJsonFile<T>(T data, string fileName)
    {
        string jsonData = JsonConvert.SerializeObject(data); // Converte o objeto para uma string JSON

        // Define o caminho do arquivo onde queremos salvar
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        // Salva o arquivo em disco
        File.WriteAllText(path, jsonData);

        Debug.Log("Objeto salvo como JSON em: " + path);
    }


}
