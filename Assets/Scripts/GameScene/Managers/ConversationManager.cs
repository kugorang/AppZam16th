using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConversationData
{
    public List<string> text;
}

public class ConversationManager : SingleTon<ConversationManager>
{
    public List<ConversationData> conversationData_Throwers = new List<ConversationData>();
    public List<ConversationData> conversationData_Receivers = new List<ConversationData>();
}

