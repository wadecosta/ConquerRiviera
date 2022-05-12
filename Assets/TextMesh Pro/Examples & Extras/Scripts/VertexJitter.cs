using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{

    public class VertexJitter : MonoBehaviour
    {

<<<<<<< HEAD
        [FormerlySerializedAs("AngleMultiplier")] public float angleMultiplier = 1.0f;
        [FormerlySerializedAs("SpeedMultiplier")] public float speedMultiplier = 1.0f;
        [FormerlySerializedAs("CurveScale")] public float curveScale = 1.0f;

        private TMP_Text mTextComponent;
=======
        public float AngleMultiplier = 1.0f;
        public float SpeedMultiplier = 1.0f;
        public float CurveScale = 1.0f;

        private TMP_Text m_TextComponent;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        private bool hasTextChanged;

        /// <summary>
        /// Structure to hold pre-computed animation data.
        /// </summary>
        private struct VertexAnim
        {
<<<<<<< HEAD
            public float AngleRange;
            public float Angle;
            public float Speed;
=======
            public float angleRange;
            public float angle;
            public float speed;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }

        void Awake()
        {
<<<<<<< HEAD
            mTextComponent = GetComponent<TMP_Text>();
=======
            m_TextComponent = GetComponent<TMP_Text>();
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }

        void OnEnable()
        {
            // Subscribe to event fired when text object has been regenerated.
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
        }

        void OnDisable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
        }


        void Start()
        {
            StartCoroutine(AnimateVertexColors());
        }


        void ON_TEXT_CHANGED(Object obj)
        {
<<<<<<< HEAD
            if (obj == mTextComponent)
=======
            if (obj == m_TextComponent)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                hasTextChanged = true;
        }

        /// <summary>
        /// Method to animate vertex colors of a TMP Text object.
        /// </summary>
        /// <returns></returns>
        IEnumerator AnimateVertexColors()
        {

            // We force an update of the text object since it would only be updated at the end of the frame. Ie. before this code is executed on the first frame.
            // Alternatively, we could yield and wait until the end of the frame when the text object will be generated.
<<<<<<< HEAD
            mTextComponent.ForceMeshUpdate();

            TMP_TextInfo textInfo = mTextComponent.textInfo;
=======
            m_TextComponent.ForceMeshUpdate();

            TMP_TextInfo textInfo = m_TextComponent.textInfo;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            Matrix4x4 matrix;

            int loopCount = 0;
            hasTextChanged = true;

            // Create an Array which contains pre-computed Angle Ranges and Speeds for a bunch of characters.
            VertexAnim[] vertexAnim = new VertexAnim[1024];
            for (int i = 0; i < 1024; i++)
            {
<<<<<<< HEAD
                vertexAnim[i].AngleRange = Random.Range(10f, 25f);
                vertexAnim[i].Speed = Random.Range(1f, 3f);
=======
                vertexAnim[i].angleRange = Random.Range(10f, 25f);
                vertexAnim[i].speed = Random.Range(1f, 3f);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }

            // Cache the vertex data of the text object as the Jitter FX is applied to the original position of the characters.
            TMP_MeshInfo[] cachedMeshInfo = textInfo.CopyMeshInfoVertexData();

            while (true)
            {
                // Get new copy of vertex data if the text has changed.
                if (hasTextChanged)
                {
                    // Update the copy of the vertex data for the text object.
                    cachedMeshInfo = textInfo.CopyMeshInfoVertexData();

                    hasTextChanged = false;
                }

                int characterCount = textInfo.characterCount;

                // If No Characters then just yield and wait for some text to be added
                if (characterCount == 0)
                {
                    yield return new WaitForSeconds(0.25f);
                    continue;
                }


                for (int i = 0; i < characterCount; i++)
                {
                    TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

                    // Skip characters that are not visible and thus have no geometry to manipulate.
                    if (!charInfo.isVisible)
                        continue;

                    // Retrieve the pre-computed animation data for the given character.
                    VertexAnim vertAnim = vertexAnim[i];

                    // Get the index of the material used by the current character.
                    int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

                    // Get the index of the first vertex used by this text element.
                    int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                    // Get the cached vertices of the mesh used by this text element (character or sprite).
                    Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;

                    // Determine the center point of each character at the baseline.
                    //Vector2 charMidBasline = new Vector2((sourceVertices[vertexIndex + 0].x + sourceVertices[vertexIndex + 2].x) / 2, charInfo.baseLine);
                    // Determine the center point of each character.
                    Vector2 charMidBasline = (sourceVertices[vertexIndex + 0] + sourceVertices[vertexIndex + 2]) / 2;

                    // Need to translate all 4 vertices of each quad to aligned with middle of character / baseline.
                    // This is needed so the matrix TRS is applied at the origin for each character.
                    Vector3 offset = charMidBasline;

                    Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

                    destinationVertices[vertexIndex + 0] = sourceVertices[vertexIndex + 0] - offset;
                    destinationVertices[vertexIndex + 1] = sourceVertices[vertexIndex + 1] - offset;
                    destinationVertices[vertexIndex + 2] = sourceVertices[vertexIndex + 2] - offset;
                    destinationVertices[vertexIndex + 3] = sourceVertices[vertexIndex + 3] - offset;

<<<<<<< HEAD
                    vertAnim.Angle = Mathf.SmoothStep(-vertAnim.AngleRange, vertAnim.AngleRange, Mathf.PingPong(loopCount / 25f * vertAnim.Speed, 1f));
                    Vector3 jitterOffset = new Vector3(Random.Range(-.25f, .25f), Random.Range(-.25f, .25f), 0);

                    matrix = Matrix4x4.TRS(jitterOffset * curveScale, Quaternion.Euler(0, 0, Random.Range(-5f, 5f) * angleMultiplier), Vector3.one);
=======
                    vertAnim.angle = Mathf.SmoothStep(-vertAnim.angleRange, vertAnim.angleRange, Mathf.PingPong(loopCount / 25f * vertAnim.speed, 1f));
                    Vector3 jitterOffset = new Vector3(Random.Range(-.25f, .25f), Random.Range(-.25f, .25f), 0);

                    matrix = Matrix4x4.TRS(jitterOffset * CurveScale, Quaternion.Euler(0, 0, Random.Range(-5f, 5f) * AngleMultiplier), Vector3.one);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    destinationVertices[vertexIndex + 0] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 0]);
                    destinationVertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 1]);
                    destinationVertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 2]);
                    destinationVertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 3]);

                    destinationVertices[vertexIndex + 0] += offset;
                    destinationVertices[vertexIndex + 1] += offset;
                    destinationVertices[vertexIndex + 2] += offset;
                    destinationVertices[vertexIndex + 3] += offset;

                    vertexAnim[i] = vertAnim;
                }

                // Push changes into meshes
                for (int i = 0; i < textInfo.meshInfo.Length; i++)
                {
                    textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
<<<<<<< HEAD
                    mTextComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
=======
                    m_TextComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }

                loopCount += 1;

                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}