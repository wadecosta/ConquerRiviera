using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class TeleType : MonoBehaviour
    {


        //[Range(0, 100)]
        //public int RevealSpeed = 50;

        private string label01 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=1>";
        private string label02 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=2>";


<<<<<<< HEAD
        private TMP_Text mTextMeshPro;
=======
        private TMP_Text m_textMeshPro;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


        void Awake()
        {
            // Get Reference to TextMeshPro Component
<<<<<<< HEAD
            mTextMeshPro = GetComponent<TMP_Text>();
            mTextMeshPro.text = label01;
            mTextMeshPro.enableWordWrapping = true;
            mTextMeshPro.alignment = TextAlignmentOptions.Top;
=======
            m_textMeshPro = GetComponent<TMP_Text>();
            m_textMeshPro.text = label01;
            m_textMeshPro.enableWordWrapping = true;
            m_textMeshPro.alignment = TextAlignmentOptions.Top;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc



            //if (GetComponentInParent(typeof(Canvas)) as Canvas == null)
            //{
            //    GameObject canvas = new GameObject("Canvas", typeof(Canvas));
            //    gameObject.transform.SetParent(canvas.transform);
            //    canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

            //    // Set RectTransform Size
            //    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
            //    m_textMeshPro.fontSize = 48;
            //}


        }


        IEnumerator Start()
        {

            // Force and update of the mesh to get valid information.
<<<<<<< HEAD
            mTextMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = mTextMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
=======
            m_textMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            int counter = 0;
            int visibleCount = 0;

            while (true)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

<<<<<<< HEAD
                mTextMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
=======
                m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                // Once the last character has been revealed, wait 1.0 second and start over.
                if (visibleCount >= totalVisibleCharacters)
                {
                    yield return new WaitForSeconds(1.0f);
<<<<<<< HEAD
                    mTextMeshPro.text = label02;
                    yield return new WaitForSeconds(1.0f);
                    mTextMeshPro.text = label01;
=======
                    m_textMeshPro.text = label02;
                    yield return new WaitForSeconds(1.0f);
                    m_textMeshPro.text = label01;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    yield return new WaitForSeconds(1.0f);
                }

                counter += 1;

                yield return new WaitForSeconds(0.05f);
            }

            //Debug.Log("Done revealing the text.");
        }

    }
}