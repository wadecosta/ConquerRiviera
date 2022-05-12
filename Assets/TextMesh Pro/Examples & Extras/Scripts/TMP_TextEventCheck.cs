using UnityEngine;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
<<<<<<< HEAD
    public class TMPTextEventCheck : MonoBehaviour
    {

        [FormerlySerializedAs("TextEventHandler")] public TMPTextEventHandler textEventHandler;

        private TMP_Text mTextComponent;

        void OnEnable()
        {
            if (textEventHandler != null)
            {
                // Get a reference to the text component
                mTextComponent = textEventHandler.GetComponent<TMP_Text>();
                
                textEventHandler.OnCharacterSelection.AddListener(OnCharacterSelection);
                textEventHandler.OnSpriteSelection.AddListener(OnSpriteSelection);
                textEventHandler.OnWordSelection.AddListener(OnWordSelection);
                textEventHandler.OnLineSelection.AddListener(OnLineSelection);
                textEventHandler.OnLinkSelection.AddListener(OnLinkSelection);
=======
    public class TMP_TextEventCheck : MonoBehaviour
    {

        public TMP_TextEventHandler TextEventHandler;

        private TMP_Text m_TextComponent;

        void OnEnable()
        {
            if (TextEventHandler != null)
            {
                // Get a reference to the text component
                m_TextComponent = TextEventHandler.GetComponent<TMP_Text>();
                
                TextEventHandler.onCharacterSelection.AddListener(OnCharacterSelection);
                TextEventHandler.onSpriteSelection.AddListener(OnSpriteSelection);
                TextEventHandler.onWordSelection.AddListener(OnWordSelection);
                TextEventHandler.onLineSelection.AddListener(OnLineSelection);
                TextEventHandler.onLinkSelection.AddListener(OnLinkSelection);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }
        }


        void OnDisable()
        {
<<<<<<< HEAD
            if (textEventHandler != null)
            {
                textEventHandler.OnCharacterSelection.RemoveListener(OnCharacterSelection);
                textEventHandler.OnSpriteSelection.RemoveListener(OnSpriteSelection);
                textEventHandler.OnWordSelection.RemoveListener(OnWordSelection);
                textEventHandler.OnLineSelection.RemoveListener(OnLineSelection);
                textEventHandler.OnLinkSelection.RemoveListener(OnLinkSelection);
=======
            if (TextEventHandler != null)
            {
                TextEventHandler.onCharacterSelection.RemoveListener(OnCharacterSelection);
                TextEventHandler.onSpriteSelection.RemoveListener(OnSpriteSelection);
                TextEventHandler.onWordSelection.RemoveListener(OnWordSelection);
                TextEventHandler.onLineSelection.RemoveListener(OnLineSelection);
                TextEventHandler.onLinkSelection.RemoveListener(OnLinkSelection);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }
        }


        void OnCharacterSelection(char c, int index)
        {
            Debug.Log("Character [" + c + "] at Index: " + index + " has been selected.");
        }

        void OnSpriteSelection(char c, int index)
        {
            Debug.Log("Sprite [" + c + "] at Index: " + index + " has been selected.");
        }

        void OnWordSelection(string word, int firstCharacterIndex, int length)
        {
            Debug.Log("Word [" + word + "] with first character index of " + firstCharacterIndex + " and length of " + length + " has been selected.");
        }

        void OnLineSelection(string lineText, int firstCharacterIndex, int length)
        {
            Debug.Log("Line [" + lineText + "] with first character index of " + firstCharacterIndex + " and length of " + length + " has been selected.");
        }

        void OnLinkSelection(string linkID, string linkText, int linkIndex)
        {
<<<<<<< HEAD
            if (mTextComponent != null)
            {
                TMP_LinkInfo linkInfo = mTextComponent.textInfo.linkInfo[linkIndex];
=======
            if (m_TextComponent != null)
            {
                TMP_LinkInfo linkInfo = m_TextComponent.textInfo.linkInfo[linkIndex];
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }
            
            Debug.Log("Link Index: " + linkIndex + " with ID [" + linkID + "] and Text \"" + linkText + "\" has been selected.");
        }

    }
}
