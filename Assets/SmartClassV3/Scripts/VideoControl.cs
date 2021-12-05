using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
namespace YoutubePlayer
{
    public class VideoControl : MonoBehaviour
    {
        public YoutubePlayer youtubePlayer;

        VideoPlayer videoPlayer;

        public GameObject quad;
        public Button playBtn;
        public Button pauseBtn;
        public Button stopBtn;
        public Button showHideBtn;

        public void Awake()
        {
            playBtn.interactable = false;
            pauseBtn.interactable = false;
            stopBtn.interactable = false;

            videoPlayer = youtubePlayer.GetComponent<VideoPlayer>();
            videoPlayer.prepareCompleted += VideoPlayerPreparedCompleted;
        }

        void VideoPlayerPreparedCompleted(VideoPlayer source)
        {
            playBtn.interactable = source.isPrepared;
            pauseBtn.interactable = source.isPrepared;
            stopBtn.interactable = source.isPrepared;
        }

        public async void Prepare()
        {
            print("loading video....");
            try
            {
                await youtubePlayer.PrepareVideoAsync();
                print("video loaded");
            }
            catch
            {
                print("ERROR loading video");
            }
        }

        public void PlayVideo()
        {
            videoPlayer.Play();
        }

        public void StopVideo()
        {
            videoPlayer.Stop();
            videoPlayer.Play();
        }

        public void PauseVideo()
        {
            videoPlayer.Pause();
        }

        private void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerPreparedCompleted;
        }

        public void ShowHide()
        {
            if(quad.activeSelf== true)
            {
                quad.SetActive(false);
            } else
            {
                quad.SetActive(true);
            }
        }
    }
}


