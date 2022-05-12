﻿using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{

    public class WarpTextExample : MonoBehaviour
    {

<<<<<<< HEAD
        private TMP_Text mTextComponent;

        [FormerlySerializedAs("VertexCurve")] public AnimationCurve vertexCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.25f, 2.0f), new Keyframe(0.5f, 0), new Keyframe(0.75f, 2.0f), new Keyframe(1, 0f));
        [FormerlySerializedAs("AngleMultiplier")] public float angleMultiplier = 1.0f;
        [FormerlySerializedAs("SpeedMultiplier")] public float speedMultiplier = 1.0f;
        [FormerlySerializedAs("CurveScale")] public float curveScale = 1.0f;

        void Awake()
        {
            mTextComponent = gameObject.GetComponent<TMP_Text>();
=======
        private TMP_Text m_TextComponent;

        public AnimationCurve VertexCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.25f, 2.0f), new Keyframe(0.5f, 0), new Keyframe(0.75f, 2.0f), new Keyframe(1, 0f));
        public float AngleMultiplier = 1.0f;
        public float SpeedMultiplier = 1.0f;
        public float CurveScale = 1.0f;

        void Awake()
        {
            m_TextComponent = gameObject.GetComponent<TMP_Text>();
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }


        void Start()
        {
            StartCoroutine(WarpText());
        }


        private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
        {
            AnimationCurve newCurve = new AnimationCurve();

            newCurve.keys = curve.keys;

            return newCurve;
        }


        /// <summary>
        ///  Method to curve text along a Unity animation curve.
        /// </summary>
        /// <param name="textComponent"></param>
        /// <returns></returns>
        IEnumerator WarpText()
        {
<<<<<<< HEAD
            vertexCurve.preWrapMode = WrapMode.Clamp;
            vertexCurve.postWrapMode = WrapMode.Clamp;
=======
            VertexCurve.preWrapMode = WrapMode.Clamp;
            VertexCurve.postWrapMode = WrapMode.Clamp;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            //Mesh mesh = m_TextComponent.textInfo.meshInfo[0].mesh;

            Vector3[] vertices;
            Matrix4x4 matrix;

<<<<<<< HEAD
            mTextComponent.havePropertiesChanged = true; // Need to force the TextMeshPro Object to be updated.
            curveScale *= 10;
            float oldCurveScale = curveScale;
            AnimationCurve oldCurve = CopyAnimationCurve(vertexCurve);

            while (true)
            {
                if (!mTextComponent.havePropertiesChanged && oldCurveScale == curveScale && oldCurve.keys[1].value == vertexCurve.keys[1].value)
=======
            m_TextComponent.havePropertiesChanged = true; // Need to force the TextMeshPro Object to be updated.
            CurveScale *= 10;
            float old_CurveScale = CurveScale;
            AnimationCurve old_curve = CopyAnimationCurve(VertexCurve);

            while (true)
            {
                if (!m_TextComponent.havePropertiesChanged && old_CurveScale == CurveScale && old_curve.keys[1].value == VertexCurve.keys[1].value)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                {
                    yield return null;
                    continue;
                }

<<<<<<< HEAD
                oldCurveScale = curveScale;
                oldCurve = CopyAnimationCurve(vertexCurve);

                mTextComponent.ForceMeshUpdate(); // Generate the mesh and populate the textInfo with data we can use and manipulate.

                TMP_TextInfo textInfo = mTextComponent.textInfo;
=======
                old_CurveScale = CurveScale;
                old_curve = CopyAnimationCurve(VertexCurve);

                m_TextComponent.ForceMeshUpdate(); // Generate the mesh and populate the textInfo with data we can use and manipulate.

                TMP_TextInfo textInfo = m_TextComponent.textInfo;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                int characterCount = textInfo.characterCount;


                if (characterCount == 0) continue;

                //vertices = textInfo.meshInfo[0].vertices;
                //int lastVertexIndex = textInfo.characterInfo[characterCount - 1].vertexIndex;

<<<<<<< HEAD
                float boundsMinX = mTextComponent.bounds.min.x;  //textInfo.meshInfo[0].mesh.bounds.min.x;
                float boundsMaxX = mTextComponent.bounds.max.x;  //textInfo.meshInfo[0].mesh.bounds.max.x;
=======
                float boundsMinX = m_TextComponent.bounds.min.x;  //textInfo.meshInfo[0].mesh.bounds.min.x;
                float boundsMaxX = m_TextComponent.bounds.max.x;  //textInfo.meshInfo[0].mesh.bounds.max.x;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc



                for (int i = 0; i < characterCount; i++)
                {
                    if (!textInfo.characterInfo[i].isVisible)
                        continue;

                    int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                    // Get the index of the mesh used by this character.
                    int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

                    vertices = textInfo.meshInfo[materialIndex].vertices;

                    // Compute the baseline mid point for each character
                    Vector3 offsetToMidBaseline = new Vector2((vertices[vertexIndex + 0].x + vertices[vertexIndex + 2].x) / 2, textInfo.characterInfo[i].baseLine);
                    //float offsetY = VertexCurve.Evaluate((float)i / characterCount + loopCount / 50f); // Random.Range(-0.25f, 0.25f);

                    // Apply offset to adjust our pivot point.
                    vertices[vertexIndex + 0] += -offsetToMidBaseline;
                    vertices[vertexIndex + 1] += -offsetToMidBaseline;
                    vertices[vertexIndex + 2] += -offsetToMidBaseline;
                    vertices[vertexIndex + 3] += -offsetToMidBaseline;

                    // Compute the angle of rotation for each character based on the animation curve
                    float x0 = (offsetToMidBaseline.x - boundsMinX) / (boundsMaxX - boundsMinX); // Character's position relative to the bounds of the mesh.
                    float x1 = x0 + 0.0001f;
<<<<<<< HEAD
                    float y0 = vertexCurve.Evaluate(x0) * curveScale;
                    float y1 = vertexCurve.Evaluate(x1) * curveScale;
=======
                    float y0 = VertexCurve.Evaluate(x0) * CurveScale;
                    float y1 = VertexCurve.Evaluate(x1) * CurveScale;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    Vector3 horizontal = new Vector3(1, 0, 0);
                    //Vector3 normal = new Vector3(-(y1 - y0), (x1 * (boundsMaxX - boundsMinX) + boundsMinX) - offsetToMidBaseline.x, 0);
                    Vector3 tangent = new Vector3(x1 * (boundsMaxX - boundsMinX) + boundsMinX, y1) - new Vector3(offsetToMidBaseline.x, y0);

                    float dot = Mathf.Acos(Vector3.Dot(horizontal, tangent.normalized)) * 57.2957795f;
                    Vector3 cross = Vector3.Cross(horizontal, tangent);
                    float angle = cross.z > 0 ? dot : 360 - dot;

                    matrix = Matrix4x4.TRS(new Vector3(0, y0, 0), Quaternion.Euler(0, 0, angle), Vector3.one);

                    vertices[vertexIndex + 0] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 0]);
                    vertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
                    vertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
                    vertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);

                    vertices[vertexIndex + 0] += offsetToMidBaseline;
                    vertices[vertexIndex + 1] += offsetToMidBaseline;
                    vertices[vertexIndex + 2] += offsetToMidBaseline;
                    vertices[vertexIndex + 3] += offsetToMidBaseline;
                }


                // Upload the mesh with the revised information
<<<<<<< HEAD
                mTextComponent.UpdateVertexData();
=======
                m_TextComponent.UpdateVertexData();
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                yield return new WaitForSeconds(0.025f);
            }
        }
    }
}
