using UnityEngine;
using UnityEngine.UI;
using TMPro;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

public class ChatController : MonoBehaviour {


<<<<<<< HEAD
    [FormerlySerializedAs("ChatInputField")] public TMP_InputField chatInputField;

    [FormerlySerializedAs("ChatDisplayOutput")] public TMP_Text chatDisplayOutput;

    [FormerlySerializedAs("ChatScrollbar")] public Scrollbar chatScrollbar;

    void OnEnable()
    {
        chatInputField.onSubmit.AddListener(AddToChatOutput);
=======
    public TMP_InputField ChatInputField;

    public TMP_Text ChatDisplayOutput;

    public Scrollbar ChatScrollbar;

    void OnEnable()
    {
        ChatInputField.onSubmit.AddListener(AddToChatOutput);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
    }

    void OnDisable()
    {
<<<<<<< HEAD
        chatInputField.onSubmit.RemoveListener(AddToChatOutput);
=======
        ChatInputField.onSubmit.RemoveListener(AddToChatOutput);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
    }


    void AddToChatOutput(string newText)
    {
        // Clear Input Field
<<<<<<< HEAD
        chatInputField.text = string.Empty;
=======
        ChatInputField.text = string.Empty;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        var timeNow = System.DateTime.Now;

        string formattedInput = "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] " + newText;

<<<<<<< HEAD
        if (chatDisplayOutput != null)
        {
            // No special formatting for first entry
            // Add line feed before each subsequent entries
            if (chatDisplayOutput.text == string.Empty)
                chatDisplayOutput.text = formattedInput;
            else
                chatDisplayOutput.text += "\n" + formattedInput;
        }

        // Keep Chat input field active
        chatInputField.ActivateInputField();

        // Set the scrollbar to the bottom when next text is submitted.
        chatScrollbar.value = 0;
=======
        if (ChatDisplayOutput != null)
        {
            // No special formatting for first entry
            // Add line feed before each subsequent entries
            if (ChatDisplayOutput.text == string.Empty)
                ChatDisplayOutput.text = formattedInput;
            else
                ChatDisplayOutput.text += "\n" + formattedInput;
        }

        // Keep Chat input field active
        ChatInputField.ActivateInputField();

        // Set the scrollbar to the bottom when next text is submitted.
        ChatScrollbar.value = 0;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
    }

}
