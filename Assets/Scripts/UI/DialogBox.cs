using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : Singleton<DialogBox>
{
    [SerializeField] RectTransform m_tip;
    [SerializeField] TextMeshProUGUI m_text;

    Vector3 m_offset;
    Transform m_speaker;

    //[SerializeField] AudioSource m_source;
    //[SerializeField] AudioClip[] m_clips;

    public void SetText(Transform speaker, Vector3 offset, string text, bool italic = false)
    {
        if (speaker == null)
        {
            gameObject.SetActive(false);
            return;
        }
        else gameObject.SetActive(true);

        m_offset = offset;
        m_speaker = speaker;

        m_tip.position = (Vector2)Camera.main.WorldToScreenPoint(speaker.position + offset);
        m_text.text = text;
        m_text.fontStyle = italic ? FontStyles.Italic : FontStyles.Normal;

        //SoundManager.PlaySound(m_source, m_clips, false);
    }
    //-public void SetText(SO_Dialogs.Dialog dialog, Vector3 offset)
    //-{
    //-    m_tip.position = (Vector2)Camera.main.WorldToScreenPoint(dialog.mSpeaker.position + offset);
    //-    m_text.text = dialog.text;
    //-    m_text.fontStyle = dialog.italic ? FontStyles.Italic : FontStyles.Normal;
    //-}

    void Update()
    {
        if (m_speaker != null)
            m_tip.position = (Vector2)Camera.main.WorldToScreenPoint(m_speaker.position + m_offset);
    }
}