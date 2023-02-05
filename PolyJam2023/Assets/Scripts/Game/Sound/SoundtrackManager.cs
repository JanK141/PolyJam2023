using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using static Unity.Burst.Intrinsics.X86.Avx;

public class SoundtrackManager : MonoBehaviour
{
    [SerializeField, Tooltip("Melodia, Perkusja, Progresja, Final")] private List<AudioClip> clipList = new List<AudioClip> {null, null, null, null};
    [SerializeField] private IntVariable BPM;
    [SerializeField] private int TrackBPM;

    private List<AudioSource> audioSources;
    private int stage = 0;
    private PlayerFire pf;
    private bool playMelody = true;

    private void Awake()
    {
        BPM.Value = TrackBPM;
        audioSources = new List<AudioSource>();
    }

    void Start()
    {
        pf = GameManager.instance.PlayerFire;
        for(int i = 0; i < clipList.Count; i++)
        {
            var tmp = this.AddComponent<AudioSource>();
            tmp.playOnAwake = false;
            tmp.loop = true;
            tmp.clip = clipList[i];
            tmp.spatialBlend = 0f;
            tmp.volume = 0f;
            audioSources.Add(tmp);
        }
        audioSources[2].loop = false;
        audioSources[1].volume = 1f;
        audioSources[0].Play();
        audioSources[1].Play();
        audioSources[3].Play();
    }

    float ttw = 0f;
    void Update()
    {
        if(ttw != 0)
        {
            ttw -= Time.deltaTime;
            if(ttw <= 0)
            {
                audioSources[2].volume = 1f;
                audioSources[2].Play();
                audioSources[2].time = -ttw;
                audioSources[1].volume = 0f;
                ttw = 0f;
            }
        }
        
    }

    public void UpdateTrack(int i)
    {
        if (i > 0)
        {
            stage++;
            if(stage == 1)
            {
                var tmp = pf.Progression;
                if (tmp > 0)
                {
                     ttw = (60 / TrackBPM) * tmp;
                }
                else
                {
                    audioSources[2].volume = 1f;
                    audioSources[2].Play();
                    audioSources[2].time = (60 / TrackBPM) * -tmp;
                    audioSources[1].volume = 0f;
                }
            }else if(stage == 5)
            {
                SetMelodyVolume(-1);
                playMelody = false;
                var tmp = pf.Progression;
                if(tmp > 0)
                {
                    audioSources[2].volume = 0f;
                    audioSources[3].volume = 1f;
                }
                else
                {
                    audioSources[3].volume = 1f;
                }
            }
        }
        else
        {
            audioSources[0].volume = 0f;
            audioSources[2].volume = 0f;
            audioSources[3].volume = 0f;
            audioSources[1].volume = 1f;
            playMelody = true;
        }
    }

    public void SetMelodyVolume(float volume)
    {
        if (!playMelody) return;
        audioSources[0].volume = volume;
    }
}
