using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource m_source;
    [SerializeField] AudioClip[] m_clips_dialog;

    public static void PlaySound(AudioSource source, AudioClip[] clips, bool skip)
    {
        if (source != null)
        {            
            if (source.isPlaying)
            {
                if(skip)
                    source.Stop();
                else return;
            }

            AudioClip clip = clips[Random.Range(0, clips.Length)];
            source.clip = clip;
            source.Play();
        }
    }
    public void DialogSound()
    {
        PlaySound(m_source, m_clips_dialog, true);
    }

}