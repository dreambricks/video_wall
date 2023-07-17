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
        player= GetComponent<VideoPlayer>();
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
            StartCoroutine(PlayCoroutine());
        }
        
    }
    
    IEnumerator PlayCoroutine()
    {
        for(int i = 10; i > 0; i--)
        {
            // send numbers from 10 to 1 by UDP
            udpSend1.sendString(i.ToString());
            return yield new WaitForSeconds(0.01);
        }
        player.Play();
    }
    
}
