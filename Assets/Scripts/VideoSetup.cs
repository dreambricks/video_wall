using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VideoSetup : MonoBehaviour
{
    private VideoManagerSender videoManagerSender;
    private VideoManagerReceiver videoManagerReceiver;
    private DisplaySetup displaySetup;

    public UDPReceiver udpReceiver;
    public UDPSend udpSend;

    void Awake()
    {
        videoManagerSender = GetComponent<VideoManagerSender>();
        videoManagerReceiver = GetComponent<VideoManagerReceiver>();

        DisplaySetup loadedData = LoadFromJsonFile<DisplaySetup>("display_data.json");

        string masterOrSlave = loadedData.NetworkDisplay.MasterOrSlave;
        if (masterOrSlave == "Slave")
        {
            videoManagerSender.enabled = false;
            udpReceiver.gameObject.SetActive(true);
        }
        else
        {
            videoManagerReceiver.enabled = false;
            udpSend.gameObject.SetActive(true);
        }

    }

    private T LoadFromJsonFile<T>(string fileName)
    {
        // Define o caminho do arquivo onde queremos carregar
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(jsonData); // Desserializa a string JSON para o objeto
        }
        else
        {
            Debug.LogWarning("Arquivo não encontrado: " + path);
            return default(T);
        }
    }
}
