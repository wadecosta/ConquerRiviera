using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
    public class Benchmark01 : MonoBehaviour
    {

<<<<<<< HEAD
        [FormerlySerializedAs("BenchmarkType")] public int benchmarkType = 0;

        [FormerlySerializedAs("TMProFont")] public TMP_FontAsset tmProFont;
        [FormerlySerializedAs("TextMeshFont")] public Font textMeshFont;

        private TextMeshPro mTextMeshPro;
        private TextContainer mTextContainer;
        private TextMesh mTextMesh;

        private const string LABEL01 = "The <#0050FF>count is: </color>{0}";
        private const string LABEL02 = "The <color=#0050FF>count is: </color>";
=======
        public int BenchmarkType = 0;

        public TMP_FontAsset TMProFont;
        public Font TextMeshFont;

        private TextMeshPro m_textMeshPro;
        private TextContainer m_textContainer;
        private TextMesh m_textMesh;

        private const string label01 = "The <#0050FF>count is: </color>{0}";
        private const string label02 = "The <color=#0050FF>count is: </color>";
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        //private string m_string;
        //private int m_frame;

<<<<<<< HEAD
        private Material mMaterial01;
        private Material mMaterial02;
=======
        private Material m_material01;
        private Material m_material02;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc



        IEnumerator Start()
        {



<<<<<<< HEAD
            if (benchmarkType == 0) // TextMesh Pro Component
            {
                mTextMeshPro = gameObject.AddComponent<TextMeshPro>();
                mTextMeshPro.autoSizeTextContainer = true;

                //m_textMeshPro.anchorDampening = true;

                if (tmProFont != null)
                    mTextMeshPro.font = tmProFont;
=======
            if (BenchmarkType == 0) // TextMesh Pro Component
            {
                m_textMeshPro = gameObject.AddComponent<TextMeshPro>();
                m_textMeshPro.autoSizeTextContainer = true;

                //m_textMeshPro.anchorDampening = true;

                if (TMProFont != null)
                    m_textMeshPro.font = TMProFont;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                //m_textMeshPro.font = Resources.Load("Fonts & Materials/Anton SDF", typeof(TextMeshProFont)) as TextMeshProFont; // Make sure the Anton SDF exists before calling this...
                //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/Anton SDF", typeof(Material)) as Material; // Same as above make sure this material exists.

<<<<<<< HEAD
                mTextMeshPro.fontSize = 48;
                mTextMeshPro.alignment = TextAlignmentOptions.Center;
                //m_textMeshPro.anchor = AnchorPositions.Center;
                mTextMeshPro.extraPadding = true;
=======
                m_textMeshPro.fontSize = 48;
                m_textMeshPro.alignment = TextAlignmentOptions.Center;
                //m_textMeshPro.anchor = AnchorPositions.Center;
                m_textMeshPro.extraPadding = true;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                //m_textMeshPro.outlineWidth = 0.25f;
                //m_textMeshPro.fontSharedMaterial.SetFloat("_OutlineWidth", 0.2f);
                //m_textMeshPro.fontSharedMaterial.EnableKeyword("UNDERLAY_ON");
                //m_textMeshPro.lineJustification = LineJustificationTypes.Center;
<<<<<<< HEAD
                mTextMeshPro.enableWordWrapping = false;    
=======
                m_textMeshPro.enableWordWrapping = false;    
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                //m_textMeshPro.lineLength = 60;          
                //m_textMeshPro.characterSpacing = 0.2f;
                //m_textMeshPro.fontColor = new Color32(255, 255, 255, 255);

<<<<<<< HEAD
                mMaterial01 = mTextMeshPro.font.material;
                mMaterial02 = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Drop Shadow"); // Make sure the LiberationSans SDF exists before calling this...  


            }
            else if (benchmarkType == 1) // TextMesh
            {
                mTextMesh = gameObject.AddComponent<TextMesh>();

                if (textMeshFont != null)
                {
                    mTextMesh.font = textMeshFont;
                    mTextMesh.GetComponent<Renderer>().sharedMaterial = mTextMesh.font.material;
                }
                else
                {
                    mTextMesh.font = Resources.Load("Fonts/ARIAL", typeof(Font)) as Font;
                    mTextMesh.GetComponent<Renderer>().sharedMaterial = mTextMesh.font.material;
                }

                mTextMesh.fontSize = 48;
                mTextMesh.anchor = TextAnchor.MiddleCenter;
=======
                m_material01 = m_textMeshPro.font.material;
                m_material02 = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Drop Shadow"); // Make sure the LiberationSans SDF exists before calling this...  


            }
            else if (BenchmarkType == 1) // TextMesh
            {
                m_textMesh = gameObject.AddComponent<TextMesh>();

                if (TextMeshFont != null)
                {
                    m_textMesh.font = TextMeshFont;
                    m_textMesh.GetComponent<Renderer>().sharedMaterial = m_textMesh.font.material;
                }
                else
                {
                    m_textMesh.font = Resources.Load("Fonts/ARIAL", typeof(Font)) as Font;
                    m_textMesh.GetComponent<Renderer>().sharedMaterial = m_textMesh.font.material;
                }

                m_textMesh.fontSize = 48;
                m_textMesh.anchor = TextAnchor.MiddleCenter;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                //m_textMesh.color = new Color32(255, 255, 0, 255);
            }



            for (int i = 0; i <= 1000000; i++)
            {
<<<<<<< HEAD
                if (benchmarkType == 0)
                {
                    mTextMeshPro.SetText(LABEL01, i % 1000);
                    if (i % 1000 == 999)
                        mTextMeshPro.fontSharedMaterial = mTextMeshPro.fontSharedMaterial == mMaterial01 ? mTextMeshPro.fontSharedMaterial = mMaterial02 : mTextMeshPro.fontSharedMaterial = mMaterial01;
=======
                if (BenchmarkType == 0)
                {
                    m_textMeshPro.SetText(label01, i % 1000);
                    if (i % 1000 == 999)
                        m_textMeshPro.fontSharedMaterial = m_textMeshPro.fontSharedMaterial == m_material01 ? m_textMeshPro.fontSharedMaterial = m_material02 : m_textMeshPro.fontSharedMaterial = m_material01;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc



                }
<<<<<<< HEAD
                else if (benchmarkType == 1)
                    mTextMesh.text = LABEL02 + (i % 1000).ToString();
=======
                else if (BenchmarkType == 1)
                    m_textMesh.text = label02 + (i % 1000).ToString();
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                yield return null;
            }


            yield return null;
        }


        /*
        void Update()
        {
            if (BenchmarkType == 0)
            {
                m_textMeshPro.text = (m_frame % 1000).ToString();
            }
            else if (BenchmarkType == 1)
            {
                m_textMesh.text = (m_frame % 1000).ToString();
            }

            m_frame += 1;
        }
        */
    }
}
