using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManagerReceiver : MonoBehaviour
{
    private VideoPlayer player;
    public UDPReceiver udpReceiver;

    void Start()
    {
        player= GetComponent<VideoPlayer>();
        player.url = "C:\\Users\\julio\\Documents\\DB\\Unity\\video_wall\\Assets\\Video\\dgo.mp4";
    }

    // Update is called once per frame
    void Update()
    {
        PlayVideo();
    }

    void PlayVideo()
    {
        string data = udpReceiver.GetLastestData();
        int value;
        if (int.TryParse(data, out value))
        {
            StartCoroutine(PlayCoroutine(value));
        }
    }
    
    IEnumerator PlayCoroutine(int wait)
    {
        yield return new WaitForSeconds(wait * 0.01F);
        udpReceiver.GetLastestData(); // clear the buffer
        player.Play();
    }
}
