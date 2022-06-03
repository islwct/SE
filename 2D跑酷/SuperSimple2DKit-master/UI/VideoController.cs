using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/*告诉过场动画开始播放，然后在完成时加载一个场景。*/

public class VideoController : MonoBehaviour
{

    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] string whichLevel;
    [SerializeField] GameObject activateObjectAfterPlaying;
    public long playerCurrentFrame;
    public long playerFrameCount;

    void Start()
    {
        InvokeRepeating("CheckOver", .1f, .1f);
    }

    private void CheckOver()
    {
        playerCurrentFrame = videoPlayer.frame;
        playerFrameCount = (int)videoPlayer.frameCount;

        if (playerCurrentFrame != 0 && playerFrameCount != 0)
        {
            if (playerCurrentFrame >= playerFrameCount - 1)
            {
                if (activateObjectAfterPlaying != null)
                {
                    activateObjectAfterPlaying.SetActive(true);
                    gameObject.SetActive(false);
                }
                else if (whichLevel != "")
                {
                    SceneManager.LoadScene(whichLevel);
                }

                CancelInvoke("checkOver");
            }
        }
    }

}
