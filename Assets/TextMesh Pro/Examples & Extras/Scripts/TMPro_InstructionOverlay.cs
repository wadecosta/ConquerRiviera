using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
<<<<<<< HEAD
    public class TMProInstructionOverlay : MonoBehaviour
=======
    public class TMPro_InstructionOverlay : MonoBehaviour
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
    {

        public enum FpsCounterAnchorPositions { TopLeft, BottomLeft, TopRight, BottomRight };

<<<<<<< HEAD
        [FormerlySerializedAs("AnchorPosition")] public FpsCounterAnchorPositions anchorPosition = FpsCounterAnchorPositions.BottomLeft;

        private const string INSTRUCTIONS = "Camera Control - <#ffff00>Shift + RMB\n</color>Zoom - <#ffff00>Mouse wheel.";

        private TextMeshPro mTextMeshPro;
        private TextContainer mTextContainer;
        private Transform mFrameCounterTransform;
        private Camera mCamera;
=======
        public FpsCounterAnchorPositions AnchorPosition = FpsCounterAnchorPositions.BottomLeft;

        private const string instructions = "Camera Control - <#ffff00>Shift + RMB\n</color>Zoom - <#ffff00>Mouse wheel.";

        private TextMeshPro m_TextMeshPro;
        private TextContainer m_textContainer;
        private Transform m_frameCounter_transform;
        private Camera m_camera;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        //private FpsCounterAnchorPositions last_AnchorPosition;

        void Awake()
        {
            if (!enabled)
                return;

<<<<<<< HEAD
            mCamera = Camera.main;

            GameObject frameCounter = new GameObject("Frame Counter");
            mFrameCounterTransform = frameCounter.transform;
            mFrameCounterTransform.parent = mCamera.transform;
            mFrameCounterTransform.localRotation = Quaternion.identity;


            mTextMeshPro = frameCounter.AddComponent<TextMeshPro>();
            mTextMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
            mTextMeshPro.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Overlay");

            mTextMeshPro.fontSize = 30;

            mTextMeshPro.isOverlay = true;
            mTextContainer = frameCounter.GetComponent<TextContainer>();

            Set_FrameCounter_Position(anchorPosition);
            //last_AnchorPosition = AnchorPosition;

            mTextMeshPro.text = INSTRUCTIONS;
=======
            m_camera = Camera.main;

            GameObject frameCounter = new GameObject("Frame Counter");
            m_frameCounter_transform = frameCounter.transform;
            m_frameCounter_transform.parent = m_camera.transform;
            m_frameCounter_transform.localRotation = Quaternion.identity;


            m_TextMeshPro = frameCounter.AddComponent<TextMeshPro>();
            m_TextMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
            m_TextMeshPro.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Overlay");

            m_TextMeshPro.fontSize = 30;

            m_TextMeshPro.isOverlay = true;
            m_textContainer = frameCounter.GetComponent<TextContainer>();

            Set_FrameCounter_Position(AnchorPosition);
            //last_AnchorPosition = AnchorPosition;

            m_TextMeshPro.text = instructions;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        }




<<<<<<< HEAD
        void Set_FrameCounter_Position(FpsCounterAnchorPositions anchorPosition)
        {

            switch (anchorPosition)
            {
                case FpsCounterAnchorPositions.TopLeft:
                    //m_TextMeshPro.anchor = AnchorPositions.TopLeft;
                    mTextContainer.anchorPosition = TextContainerAnchors.TopLeft;
                    mFrameCounterTransform.position = mCamera.ViewportToWorldPoint(new Vector3(0, 1, 100.0f));
                    break;
                case FpsCounterAnchorPositions.BottomLeft:
                    //m_TextMeshPro.anchor = AnchorPositions.BottomLeft;
                    mTextContainer.anchorPosition = TextContainerAnchors.BottomLeft;
                    mFrameCounterTransform.position = mCamera.ViewportToWorldPoint(new Vector3(0, 0, 100.0f));
                    break;
                case FpsCounterAnchorPositions.TopRight:
                    //m_TextMeshPro.anchor = AnchorPositions.TopRight;
                    mTextContainer.anchorPosition = TextContainerAnchors.TopRight;
                    mFrameCounterTransform.position = mCamera.ViewportToWorldPoint(new Vector3(1, 1, 100.0f));
                    break;
                case FpsCounterAnchorPositions.BottomRight:
                    //m_TextMeshPro.anchor = AnchorPositions.BottomRight;
                    mTextContainer.anchorPosition = TextContainerAnchors.BottomRight;
                    mFrameCounterTransform.position = mCamera.ViewportToWorldPoint(new Vector3(1, 0, 100.0f));
=======
        void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position)
        {

            switch (anchor_position)
            {
                case FpsCounterAnchorPositions.TopLeft:
                    //m_TextMeshPro.anchor = AnchorPositions.TopLeft;
                    m_textContainer.anchorPosition = TextContainerAnchors.TopLeft;
                    m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(0, 1, 100.0f));
                    break;
                case FpsCounterAnchorPositions.BottomLeft:
                    //m_TextMeshPro.anchor = AnchorPositions.BottomLeft;
                    m_textContainer.anchorPosition = TextContainerAnchors.BottomLeft;
                    m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(0, 0, 100.0f));
                    break;
                case FpsCounterAnchorPositions.TopRight:
                    //m_TextMeshPro.anchor = AnchorPositions.TopRight;
                    m_textContainer.anchorPosition = TextContainerAnchors.TopRight;
                    m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(1, 1, 100.0f));
                    break;
                case FpsCounterAnchorPositions.BottomRight:
                    //m_TextMeshPro.anchor = AnchorPositions.BottomRight;
                    m_textContainer.anchorPosition = TextContainerAnchors.BottomRight;
                    m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(1, 0, 100.0f));
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    break;
            }
        }
    }
}
