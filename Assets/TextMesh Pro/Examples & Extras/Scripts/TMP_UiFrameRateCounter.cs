using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
<<<<<<< HEAD
    public class TMPUiFrameRateCounter : MonoBehaviour
    {
        [FormerlySerializedAs("UpdateInterval")] public float updateInterval = 5.0f;
        private float mLastInterval = 0;
        private int mFrames = 0;

        public enum FpsCounterAnchorPositions { TopLeft, BottomLeft, TopRight, BottomRight };

        [FormerlySerializedAs("AnchorPosition")] public FpsCounterAnchorPositions anchorPosition = FpsCounterAnchorPositions.TopRight;

        private string htmlColorTag;
        private const string FPS_LABEL = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS";

        private TextMeshProUGUI mTextMeshPro;
        private RectTransform mFrameCounterTransform;

        private FpsCounterAnchorPositions lastAnchorPosition;
=======
    public class TMP_UiFrameRateCounter : MonoBehaviour
    {
        public float UpdateInterval = 5.0f;
        private float m_LastInterval = 0;
        private int m_Frames = 0;

        public enum FpsCounterAnchorPositions { TopLeft, BottomLeft, TopRight, BottomRight };

        public FpsCounterAnchorPositions AnchorPosition = FpsCounterAnchorPositions.TopRight;

        private string htmlColorTag;
        private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS";

        private TextMeshProUGUI m_TextMeshPro;
        private RectTransform m_frameCounter_transform;

        private FpsCounterAnchorPositions last_AnchorPosition;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        void Awake()
        {
            if (!enabled)
                return;

            Application.targetFrameRate = 1000;

            GameObject frameCounter = new GameObject("Frame Counter");
<<<<<<< HEAD
            mFrameCounterTransform = frameCounter.AddComponent<RectTransform>();

            mFrameCounterTransform.SetParent(this.transform, false);

            mTextMeshPro = frameCounter.AddComponent<TextMeshProUGUI>();
            mTextMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
            mTextMeshPro.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Overlay");

            mTextMeshPro.enableWordWrapping = false;
            mTextMeshPro.fontSize = 36;

            mTextMeshPro.isOverlay = true;

            Set_FrameCounter_Position(anchorPosition);
            lastAnchorPosition = anchorPosition;
=======
            m_frameCounter_transform = frameCounter.AddComponent<RectTransform>();

            m_frameCounter_transform.SetParent(this.transform, false);

            m_TextMeshPro = frameCounter.AddComponent<TextMeshProUGUI>();
            m_TextMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
            m_TextMeshPro.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Overlay");

            m_TextMeshPro.enableWordWrapping = false;
            m_TextMeshPro.fontSize = 36;

            m_TextMeshPro.isOverlay = true;

            Set_FrameCounter_Position(AnchorPosition);
            last_AnchorPosition = AnchorPosition;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }


        void Start()
        {
<<<<<<< HEAD
            mLastInterval = Time.realtimeSinceStartup;
            mFrames = 0;
=======
            m_LastInterval = Time.realtimeSinceStartup;
            m_Frames = 0;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }


        void Update()
        {
<<<<<<< HEAD
            if (anchorPosition != lastAnchorPosition)
                Set_FrameCounter_Position(anchorPosition);

            lastAnchorPosition = anchorPosition;

            mFrames += 1;
            float timeNow = Time.realtimeSinceStartup;

            if (timeNow > mLastInterval + updateInterval)
            {
                // display two fractional digits (f2 format)
                float fps = mFrames / (timeNow - mLastInterval);
=======
            if (AnchorPosition != last_AnchorPosition)
                Set_FrameCounter_Position(AnchorPosition);

            last_AnchorPosition = AnchorPosition;

            m_Frames += 1;
            float timeNow = Time.realtimeSinceStartup;

            if (timeNow > m_LastInterval + UpdateInterval)
            {
                // display two fractional digits (f2 format)
                float fps = m_Frames / (timeNow - m_LastInterval);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                float ms = 1000.0f / Mathf.Max(fps, 0.00001f);

                if (fps < 30)
                    htmlColorTag = "<color=yellow>";
                else if (fps < 10)
                    htmlColorTag = "<color=red>";
                else
                    htmlColorTag = "<color=green>";

<<<<<<< HEAD
                mTextMeshPro.SetText(htmlColorTag + FPS_LABEL, fps, ms);

                mFrames = 0;
                mLastInterval = timeNow;
=======
                m_TextMeshPro.SetText(htmlColorTag + fpsLabel, fps, ms);

                m_Frames = 0;
                m_LastInterval = timeNow;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }
        }


<<<<<<< HEAD
        void Set_FrameCounter_Position(FpsCounterAnchorPositions anchorPosition)
        {
            switch (anchorPosition)
            {
                case FpsCounterAnchorPositions.TopLeft:
                    mTextMeshPro.alignment = TextAlignmentOptions.TopLeft;
                    mFrameCounterTransform.pivot = new Vector2(0, 1);
                    mFrameCounterTransform.anchorMin = new Vector2(0.01f, 0.99f);
                    mFrameCounterTransform.anchorMax = new Vector2(0.01f, 0.99f);
                    mFrameCounterTransform.anchoredPosition = new Vector2(0, 1);
                    break;
                case FpsCounterAnchorPositions.BottomLeft:
                    mTextMeshPro.alignment = TextAlignmentOptions.BottomLeft;
                    mFrameCounterTransform.pivot = new Vector2(0, 0);
                    mFrameCounterTransform.anchorMin = new Vector2(0.01f, 0.01f);
                    mFrameCounterTransform.anchorMax = new Vector2(0.01f, 0.01f);
                    mFrameCounterTransform.anchoredPosition = new Vector2(0, 0);
                    break;
                case FpsCounterAnchorPositions.TopRight:
                    mTextMeshPro.alignment = TextAlignmentOptions.TopRight;
                    mFrameCounterTransform.pivot = new Vector2(1, 1);
                    mFrameCounterTransform.anchorMin = new Vector2(0.99f, 0.99f);
                    mFrameCounterTransform.anchorMax = new Vector2(0.99f, 0.99f);
                    mFrameCounterTransform.anchoredPosition = new Vector2(1, 1);
                    break;
                case FpsCounterAnchorPositions.BottomRight:
                    mTextMeshPro.alignment = TextAlignmentOptions.BottomRight;
                    mFrameCounterTransform.pivot = new Vector2(1, 0);
                    mFrameCounterTransform.anchorMin = new Vector2(0.99f, 0.01f);
                    mFrameCounterTransform.anchorMax = new Vector2(0.99f, 0.01f);
                    mFrameCounterTransform.anchoredPosition = new Vector2(1, 0);
=======
        void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position)
        {
            switch (anchor_position)
            {
                case FpsCounterAnchorPositions.TopLeft:
                    m_TextMeshPro.alignment = TextAlignmentOptions.TopLeft;
                    m_frameCounter_transform.pivot = new Vector2(0, 1);
                    m_frameCounter_transform.anchorMin = new Vector2(0.01f, 0.99f);
                    m_frameCounter_transform.anchorMax = new Vector2(0.01f, 0.99f);
                    m_frameCounter_transform.anchoredPosition = new Vector2(0, 1);
                    break;
                case FpsCounterAnchorPositions.BottomLeft:
                    m_TextMeshPro.alignment = TextAlignmentOptions.BottomLeft;
                    m_frameCounter_transform.pivot = new Vector2(0, 0);
                    m_frameCounter_transform.anchorMin = new Vector2(0.01f, 0.01f);
                    m_frameCounter_transform.anchorMax = new Vector2(0.01f, 0.01f);
                    m_frameCounter_transform.anchoredPosition = new Vector2(0, 0);
                    break;
                case FpsCounterAnchorPositions.TopRight:
                    m_TextMeshPro.alignment = TextAlignmentOptions.TopRight;
                    m_frameCounter_transform.pivot = new Vector2(1, 1);
                    m_frameCounter_transform.anchorMin = new Vector2(0.99f, 0.99f);
                    m_frameCounter_transform.anchorMax = new Vector2(0.99f, 0.99f);
                    m_frameCounter_transform.anchoredPosition = new Vector2(1, 1);
                    break;
                case FpsCounterAnchorPositions.BottomRight:
                    m_TextMeshPro.alignment = TextAlignmentOptions.BottomRight;
                    m_frameCounter_transform.pivot = new Vector2(1, 0);
                    m_frameCounter_transform.anchorMin = new Vector2(0.99f, 0.01f);
                    m_frameCounter_transform.anchorMax = new Vector2(0.99f, 0.01f);
                    m_frameCounter_transform.anchoredPosition = new Vector2(1, 0);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    break;
            }
        }
    }
}