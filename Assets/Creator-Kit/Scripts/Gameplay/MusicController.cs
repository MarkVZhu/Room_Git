using UnityEngine;
using UnityEngine.Audio;

namespace RPGM.Gameplay
{
    public class MusicController : MonoBehaviour
    {
        public AudioMixerGroup audioMixerGroup;
        public AudioClip audioClip;
        [Range(0.0f, 1.0f)] public float audioVolume;
        public float crossFadeTime = 3;
        private bool stopUpdate = false;

        AudioSource audioSourceA, audioSourceB;
        float audioSourceAVolumeVelocity, audioSourceBVolumeVelocity;

        public void CrossFade(AudioClip audioClip)
        {
            var t = audioSourceA;
            audioSourceA = audioSourceB;
            audioSourceB = t;
            audioSourceA.clip = audioClip;
            audioSourceA.Play();
        }

        void Update()
        {
            if (!stopUpdate)
            {
                audioSourceA.volume = Mathf.SmoothDamp(audioSourceA.volume, audioVolume, ref audioSourceAVolumeVelocity, crossFadeTime, 1);
            }
        }

        void OnEnable()
        {
            audioSourceA = gameObject.AddComponent<AudioSource>();
            audioSourceA.spatialBlend = 0;
            audioSourceA.clip = audioClip;
            audioSourceA.loop = true;
            audioSourceA.outputAudioMixerGroup = audioMixerGroup;
            audioSourceA.volume = 0;
            audioSourceA.Play();
            Invoke("stopUp", crossFadeTime * 2);
        }

        void stopUp()
        {
            stopUpdate = true;
        }
    }
}