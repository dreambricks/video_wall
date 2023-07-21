using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManagerSender : MonoBehaviour
{
    private VideoPlayer player;
    public UDPSend udpSend1;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.url = "C:\\Users\\julio\\Documents\\DB\\Unity\\video_wall\\Assets\\Video\\dgo.mp4";
    }

    // Update is called once per frame
    void Update()
    {
        PlayVideo();
    }

    void PlayVideo()
    {
        
        if (player.isPlaying == false)
        {
            //player.Play();
            StartCoroutine(PlayCoroutine());
        }
        
    }
    
    IEnumerator PlayCoroutine()
    {
        for(int i = 10; i > 0; i--)
        {
            // send numbers from 10 to 1 by UDP
            udpSend1.sendString(i.ToString());
            yield return new WaitForSeconds(0.01F);
        }
        
        player.Play();

        //yield WaitForSeconds(0);
    }
    
}
