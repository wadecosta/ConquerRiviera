using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
    public class ShaderPropAnimator : MonoBehaviour
    {

<<<<<<< HEAD
        private Renderer mRenderer;
        private Material mMaterial;

        [FormerlySerializedAs("GlowCurve")] public AnimationCurve glowCurve;

        [FormerlySerializedAs("m_frame")] public float mFrame;
=======
        private Renderer m_Renderer;
        private Material m_Material;

        public AnimationCurve GlowCurve;

        public float m_frame;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        void Awake()
        {
            // Cache a reference to object's renderer
<<<<<<< HEAD
            mRenderer = GetComponent<Renderer>();

            // Cache a reference to object's material and create an instance by doing so.
            mMaterial = mRenderer.material;
=======
            m_Renderer = GetComponent<Renderer>();

            // Cache a reference to object's material and create an instance by doing so.
            m_Material = m_Renderer.material;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }

        void Start()
        {
            StartCoroutine(AnimateProperties());
        }

        IEnumerator AnimateProperties()
        {
            //float lightAngle;
            float glowPower;
<<<<<<< HEAD
            mFrame = Random.Range(0f, 1f);
=======
            m_frame = Random.Range(0f, 1f);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            while (true)
            {
                //lightAngle = (m_Material.GetFloat(ShaderPropertyIDs.ID_LightAngle) + Time.deltaTime) % 6.2831853f;
                //m_Material.SetFloat(ShaderPropertyIDs.ID_LightAngle, lightAngle);

<<<<<<< HEAD
                glowPower = glowCurve.Evaluate(mFrame);
                mMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);

                mFrame += Time.deltaTime * Random.Range(0.2f, 0.3f);
=======
                glowPower = GlowCurve.Evaluate(m_frame);
                m_Material.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);

                m_frame += Time.deltaTime * Random.Range(0.2f, 0.3f);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
