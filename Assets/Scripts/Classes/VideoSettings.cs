
[System.Serializable]
public class VideoSettings
{
    private string filename;
    private string[] position;
    private string[] videoSize;

    public VideoSettings()
    {
    }

    public VideoSettings(string filename, string[] position, string[] videoSize)
    {
        this.filename = filename;
        this.position = position;
        this.videoSize = videoSize;
    }

    public string Filename { get => filename; set => filename = value; }
    public string[] Position { get => position; set => position = value; }
    public string[] VideoSize { get => videoSize; set => videoSize = value; }
}
