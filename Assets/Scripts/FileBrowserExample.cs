using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FileBrowserExample : MonoBehaviour
{
    public InputField file;

    [MenuItem("MyMenu/Open File Browser")]
    public void OpenFileBrowser()
    {
        string title = "Select a file";
        string directory = Application.streamingAssetsPath; // You can specify the starting directory for the file browser
        string extension = "Video files (*.mp4, *.avi, *.mov, *.mkv, *.wmv, *.flv, *.webm)|*.mp4;*.avi;*.mov;*.mkv;*.wmv;*.flv;*.webm";

        string path = EditorUtility.OpenFilePanel(title, directory, extension);

        if (!string.IsNullOrEmpty(path))
        {
            file.text= path;
        }
    }
}
