using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class SimpleScript : MonoBehaviour
    {

<<<<<<< HEAD
        private TextMeshPro mTextMeshPro;
        //private TMP_FontAsset m_FontAsset;

        private const string LABEL = "The <#0050FF>count is: </color>{0:2}";
        private float mFrame;
=======
        private TextMeshPro m_textMeshPro;
        //private TMP_FontAsset m_FontAsset;

        private const string label = "The <#0050FF>count is: </color>{0:2}";
        private float m_frame;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


        void Start()
        {
            // Add new TextMesh Pro Component
<<<<<<< HEAD
            mTextMeshPro = gameObject.AddComponent<TextMeshPro>();

            mTextMeshPro.autoSizeTextContainer = true;
=======
            m_textMeshPro = gameObject.AddComponent<TextMeshPro>();

            m_textMeshPro.autoSizeTextContainer = true;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            // Load the Font Asset to be used.
            //m_FontAsset = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
            //m_textMeshPro.font = m_FontAsset;

            // Assign Material to TextMesh Pro Component
            //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF - Bevel", typeof(Material)) as Material;
            //m_textMeshPro.fontSharedMaterial.EnableKeyword("BEVEL_ON");
            
            // Set various font settings.
<<<<<<< HEAD
            mTextMeshPro.fontSize = 48;

            mTextMeshPro.alignment = TextAlignmentOptions.Center;
=======
            m_textMeshPro.fontSize = 48;

            m_textMeshPro.alignment = TextAlignmentOptions.Center;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            
            //m_textMeshPro.anchorDampening = true; // Has been deprecated but under consideration for re-implementation.
            //m_textMeshPro.enableAutoSizing = true;

            //m_textMeshPro.characterSpacing = 0.2f;
            //m_textMeshPro.wordSpacing = 0.1f;

            //m_textMeshPro.enableCulling = true;
<<<<<<< HEAD
            mTextMeshPro.enableWordWrapping = false;
=======
            m_textMeshPro.enableWordWrapping = false;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            //textMeshPro.fontColor = new Color32(255, 255, 255, 255);
        }


        void Update()
        {
<<<<<<< HEAD
            mTextMeshPro.SetText(LABEL, mFrame % 1000);
            mFrame += 1 * Time.deltaTime;
=======
            m_textMeshPro.SetText(label, m_frame % 1000);
            m_frame += 1 * Time.deltaTime;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }

    }
}
