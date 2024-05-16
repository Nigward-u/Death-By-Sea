using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startconversation : MonoBehaviour
{
    // Start is called before the first frame update
    public NPCConversation Conversation;
    void Start()
    {
        ConversationManager.Instance.StartConversation(Conversation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
