using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogs", menuName = "ScriptableObjects/Dialogs", order = 1)]
public class SO_Dialogs : ScriptableObject
{
    public Dialog[] mDialogs;

    public string GetText(string id)
    {
        Dialog d = mDialogs.FirstOrDefault(t => t.id.Equals(id));
        return (d == null ? "" : d.text);
    }

    [System.Serializable]
    public class Dialog
    {
        public string id;
        [TextArea]
        public string text;
    }
}