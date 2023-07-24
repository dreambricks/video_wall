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
    }

    // Update is called once per frame
    void Update()
    {
        PlayVideo();
    }

    void PlayVideo()
    {
        //string data = udpReceiver.GetLastestData();
        string data = udpReceiver.GetLastestNewData(1.0f);// don't get data that is older than 1 second
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
