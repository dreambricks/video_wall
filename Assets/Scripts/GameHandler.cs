using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    private DisplaySetup displaySetup;
    public SetupUI setupUI;
    public GameObject quad;
    void Awake()
    {
        quad.SetActive(false);

        DisplaySetup loadedData = LoadFromJsonFile<DisplaySetup>("display_data.json");
        Debug.Log(loadedData);
        if (loadedData == null)
        {
            setupUI.gameObject.SetActive(true);
        }
        else
        {
            quad.SetActive(true);
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
