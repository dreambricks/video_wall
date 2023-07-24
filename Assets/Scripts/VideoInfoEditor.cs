using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

[CustomEditor(typeof(VideoPlayer))]
public class VideoInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        VideoPlayer videoPlayer = (VideoPlayer)target;
        string path = AssetDatabase.GetAssetPath(videoPlayer.clip);

        if (!string.IsNullOrEmpty(path))
        {
            MediaInfo mediaInfo = GetVideoMediaInfo(path);
            GUILayout.Label("Video Resolution: " + mediaInfo.width + "x" + mediaInfo.height);
            GUILayout.Label("Video Codec: " + mediaInfo.codecName);
            GUILayout.Label("Video Duration: " + mediaInfo.duration + " seconds");
        }
    }

    private MediaInfo GetVideoMediaInfo(string videoPath)
    {
        MediaInfo mediaInfo = new MediaInfo();

        using (var mediaInfoProcess = new System.Diagnostics.Process())
        {
            mediaInfoProcess.StartInfo.FileName = "ffprobe"; // FFprobe executable
            mediaInfoProcess.StartInfo.Arguments = "-v error -select_streams v:0 -show_entries stream=width,height,codec_name,duration -of default=noprint_wrappers=1 " + videoPath;
            mediaInfoProcess.StartInfo.UseShellExecute = false;
            mediaInfoProcess.StartInfo.RedirectStandardOutput = true;
            mediaInfoProcess.StartInfo.CreateNoWindow = true;
            mediaInfoProcess.Start();

            while (!mediaInfoProcess.StandardOutput.EndOfStream)
            {
                string line = mediaInfoProcess.StandardOutput.ReadLine();

                if (line.Contains("width="))
                {
                    mediaInfo.width = int.Parse(line.Split('=')[1]);
                }
                else if (line.Contains("height="))
                {
                    mediaInfo.height = int.Parse(line.Split('=')[1]);
                }
                else if (line.Contains("codec_name="))
                {
                    mediaInfo.codecName = line.Split('=')[1];
                }
                else if (line.Contains("duration="))
                {
                    mediaInfo.duration = float.Parse(line.Split('=')[1]);
                }
            }
        }

        return mediaInfo;
    }
}

public class MediaInfo
{
    public int width;
    public int height;
    public string codecName;
    public float duration;
}
