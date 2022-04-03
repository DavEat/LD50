using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogsManager : Singleton<DialogsManager>
{
    [SerializeField] bool m_startWithDialog;

    [SerializeField] SO_Dialogs m_dialogs;
    [SerializeField] DialogQueue[] m_queues;
    [SerializeField] Vector3 m_offset = Vector3.up * 2;

    DialogQueue m_previousQueue;

    int m_dialogIndex;

    public bool InDialog => m_inDialog;
    bool m_inDialog;

    public void StartDialog()
    {
        m_inDialog = true;
        NextDialog();
    }

    void Start()
    {
        if (m_startWithDialog)
        {
            StartDialog();
        }
    }

    void Update()
    {
        if (m_inDialog && Input.GetButtonDown(GameManager.inst.NextDialogButton))
        {
            m_previousQueue?.mEvent?.Invoke();
            if (m_inDialog)
                NextDialog();
            else m_previousQueue = null;
        }
    }

    void NextDialog()
    {
        if (m_dialogs != null && m_dialogIndex < m_dialogs.mDialogs.Length)
        {
            m_previousQueue = m_queues[m_dialogIndex];

            DialogBox.inst.SetText(m_previousQueue.mSpeaker, m_offset, m_dialogs.GetText(m_previousQueue.mDialogIndex), m_previousQueue.italic);
            m_dialogIndex++;

            DialogBox.inst.gameObject.SetActive(true);
        }
        else
        {
            StopDialog();
        }
    }

    public void StopDialog()
    {
        DialogBox.inst.gameObject.SetActive(false);
        m_inDialog = false;
    }

    [System.Serializable]
    public class DialogQueue
    {
        public string mDialogIndex;
        public Transform mSpeaker;
        public bool italic;
        [Tooltip("will be play on validate")]
        public UnityEvent mEvent;
    }
}