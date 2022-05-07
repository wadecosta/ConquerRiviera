using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{

    public class TextMeshProFloatingText : MonoBehaviour
    {
<<<<<<< HEAD
        [FormerlySerializedAs("TheFont")] public Font theFont;

        private GameObject mFloatingText;
        private TextMeshPro mTextMeshPro;
        private TextMesh mTextMesh;

        private Transform mTransform;
        private Transform mFloatingTextTransform;
        private Transform mCameraTransform;

        Vector3 lastPos = Vector3.zero;
        Quaternion lastRotation = Quaternion.identity;

        [FormerlySerializedAs("SpawnType")] public int spawnType;
        [FormerlySerializedAs("IsTextObjectScaleStatic")] public bool isTextObjectScaleStatic;

        //private int m_frame = 0;

        static WaitForEndOfFrame kWaitForEndOfFrame = new WaitForEndOfFrame();
        static WaitForSeconds[] kWaitForSecondsRandom = new WaitForSeconds[]
=======
        public Font TheFont;

        private GameObject m_floatingText;
        private TextMeshPro m_textMeshPro;
        private TextMesh m_textMesh;

        private Transform m_transform;
        private Transform m_floatingText_Transform;
        private Transform m_cameraTransform;

        Vector3 lastPOS = Vector3.zero;
        Quaternion lastRotation = Quaternion.identity;

        public int SpawnType;
        public bool IsTextObjectScaleStatic;

        //private int m_frame = 0;

        static WaitForEndOfFrame k_WaitForEndOfFrame = new WaitForEndOfFrame();
        static WaitForSeconds[] k_WaitForSecondsRandom = new WaitForSeconds[]
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        {
            new WaitForSeconds(0.05f), new WaitForSeconds(0.1f), new WaitForSeconds(0.15f), new WaitForSeconds(0.2f), new WaitForSeconds(0.25f),
            new WaitForSeconds(0.3f), new WaitForSeconds(0.35f), new WaitForSeconds(0.4f), new WaitForSeconds(0.45f), new WaitForSeconds(0.5f),
            new WaitForSeconds(0.55f), new WaitForSeconds(0.6f), new WaitForSeconds(0.65f), new WaitForSeconds(0.7f), new WaitForSeconds(0.75f),
            new WaitForSeconds(0.8f), new WaitForSeconds(0.85f), new WaitForSeconds(0.9f), new WaitForSeconds(0.95f), new WaitForSeconds(1.0f),
        };

        void Awake()
        {
<<<<<<< HEAD
            mTransform = transform;
            mFloatingText = new GameObject(this.name + " floating text");
=======
            m_transform = transform;
            m_floatingText = new GameObject(this.name + " floating text");
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            // Reference to Transform is lost when TMP component is added since it replaces it by a RectTransform.
            //m_floatingText_Transform = m_floatingText.transform;
            //m_floatingText_Transform.position = m_transform.position + new Vector3(0, 15f, 0);

<<<<<<< HEAD
            mCameraTransform = Camera.main.transform;
=======
            m_cameraTransform = Camera.main.transform;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }

        void Start()
        {
<<<<<<< HEAD
            if (spawnType == 0)
            {
                // TextMesh Pro Implementation
                mTextMeshPro = mFloatingText.AddComponent<TextMeshPro>();
                mTextMeshPro.rectTransform.sizeDelta = new Vector2(3, 3);

                mFloatingTextTransform = mFloatingText.transform;
                mFloatingTextTransform.position = mTransform.position + new Vector3(0, 15f, 0);
=======
            if (SpawnType == 0)
            {
                // TextMesh Pro Implementation
                m_textMeshPro = m_floatingText.AddComponent<TextMeshPro>();
                m_textMeshPro.rectTransform.sizeDelta = new Vector2(3, 3);

                m_floatingText_Transform = m_floatingText.transform;
                m_floatingText_Transform.position = m_transform.position + new Vector3(0, 15f, 0);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                //m_textMeshPro.fontAsset = Resources.Load("Fonts & Materials/JOKERMAN SDF", typeof(TextMeshProFont)) as TextMeshProFont; // User should only provide a string to the resource.
                //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(Material)) as Material;

<<<<<<< HEAD
                mTextMeshPro.alignment = TextAlignmentOptions.Center;
                mTextMeshPro.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                mTextMeshPro.fontSize = 24;
                //m_textMeshPro.enableExtraPadding = true;
                //m_textMeshPro.enableShadows = false;
                mTextMeshPro.enableKerning = false;
                mTextMeshPro.text = string.Empty;
                mTextMeshPro.isTextObjectScaleStatic = isTextObjectScaleStatic;

                StartCoroutine(DisplayTextMeshProFloatingText());
            }
            else if (spawnType == 1)
            {
                //Debug.Log("Spawning TextMesh Objects.");

                mFloatingTextTransform = mFloatingText.transform;
                mFloatingTextTransform.position = mTransform.position + new Vector3(0, 15f, 0);

                mTextMesh = mFloatingText.AddComponent<TextMesh>();
                mTextMesh.font = Resources.Load<Font>("Fonts/ARIAL");
                mTextMesh.GetComponent<Renderer>().sharedMaterial = mTextMesh.font.material;
                mTextMesh.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                mTextMesh.anchor = TextAnchor.LowerCenter;
                mTextMesh.fontSize = 24;

                StartCoroutine(DisplayTextMeshFloatingText());
            }
            else if (spawnType == 2)
=======
                m_textMeshPro.alignment = TextAlignmentOptions.Center;
                m_textMeshPro.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                m_textMeshPro.fontSize = 24;
                //m_textMeshPro.enableExtraPadding = true;
                //m_textMeshPro.enableShadows = false;
                m_textMeshPro.enableKerning = false;
                m_textMeshPro.text = string.Empty;
                m_textMeshPro.isTextObjectScaleStatic = IsTextObjectScaleStatic;

                StartCoroutine(DisplayTextMeshProFloatingText());
            }
            else if (SpawnType == 1)
            {
                //Debug.Log("Spawning TextMesh Objects.");

                m_floatingText_Transform = m_floatingText.transform;
                m_floatingText_Transform.position = m_transform.position + new Vector3(0, 15f, 0);

                m_textMesh = m_floatingText.AddComponent<TextMesh>();
                m_textMesh.font = Resources.Load<Font>("Fonts/ARIAL");
                m_textMesh.GetComponent<Renderer>().sharedMaterial = m_textMesh.font.material;
                m_textMesh.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                m_textMesh.anchor = TextAnchor.LowerCenter;
                m_textMesh.fontSize = 24;

                StartCoroutine(DisplayTextMeshFloatingText());
            }
            else if (SpawnType == 2)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            {

            }

        }


        //void Update()
        //{
        //    if (SpawnType == 0)
        //    {
        //        m_textMeshPro.SetText("{0}", m_frame);
        //    }
        //    else
        //    {
        //        m_textMesh.text = m_frame.ToString();
        //    }
        //    m_frame = (m_frame + 1) % 1000;

        //}


        public IEnumerator DisplayTextMeshProFloatingText()
        {
<<<<<<< HEAD
            float countDuration = 2.0f; // How long is the countdown alive.
            float startingCount = Random.Range(5f, 20f); // At what number is the counter starting at.
            float currentCount = startingCount;

            Vector3 startPos = mFloatingTextTransform.position;
            Color32 startColor = mTextMeshPro.color;
            float alpha = 255;
            int intCounter = 0;


            float fadeDuration = 3 / startingCount * countDuration;

            while (currentCount > 0)
            {
                currentCount -= (Time.deltaTime / countDuration) * startingCount;

                if (currentCount <= 3)
=======
            float CountDuration = 2.0f; // How long is the countdown alive.
            float starting_Count = Random.Range(5f, 20f); // At what number is the counter starting at.
            float current_Count = starting_Count;

            Vector3 start_pos = m_floatingText_Transform.position;
            Color32 start_color = m_textMeshPro.color;
            float alpha = 255;
            int int_counter = 0;


            float fadeDuration = 3 / starting_Count * CountDuration;

            while (current_Count > 0)
            {
                current_Count -= (Time.deltaTime / CountDuration) * starting_Count;

                if (current_Count <= 3)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                {
                    //Debug.Log("Fading Counter ... " + current_Count.ToString("f2"));
                    alpha = Mathf.Clamp(alpha - (Time.deltaTime / fadeDuration) * 255, 0, 255);
                }

<<<<<<< HEAD
                intCounter = (int)currentCount;
                mTextMeshPro.text = intCounter.ToString();
                //m_textMeshPro.SetText("{0}", (int)current_Count);

                mTextMeshPro.color = new Color32(startColor.r, startColor.g, startColor.b, (byte)alpha);

                // Move the floating text upward each update
                mFloatingTextTransform.position += new Vector3(0, startingCount * Time.deltaTime, 0);

                // Align floating text perpendicular to Camera.
                if (!lastPos.Compare(mCameraTransform.position, 1000) || !lastRotation.Compare(mCameraTransform.rotation, 1000))
                {
                    lastPos = mCameraTransform.position;
                    lastRotation = mCameraTransform.rotation;
                    mFloatingTextTransform.rotation = lastRotation;
                    Vector3 dir = mTransform.position - lastPos;
                    mTransform.forward = new Vector3(dir.x, 0, dir.z);
                }

                yield return kWaitForEndOfFrame;
=======
                int_counter = (int)current_Count;
                m_textMeshPro.text = int_counter.ToString();
                //m_textMeshPro.SetText("{0}", (int)current_Count);

                m_textMeshPro.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);

                // Move the floating text upward each update
                m_floatingText_Transform.position += new Vector3(0, starting_Count * Time.deltaTime, 0);

                // Align floating text perpendicular to Camera.
                if (!lastPOS.Compare(m_cameraTransform.position, 1000) || !lastRotation.Compare(m_cameraTransform.rotation, 1000))
                {
                    lastPOS = m_cameraTransform.position;
                    lastRotation = m_cameraTransform.rotation;
                    m_floatingText_Transform.rotation = lastRotation;
                    Vector3 dir = m_transform.position - lastPOS;
                    m_transform.forward = new Vector3(dir.x, 0, dir.z);
                }

                yield return k_WaitForEndOfFrame;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }

            //Debug.Log("Done Counting down.");

<<<<<<< HEAD
            yield return kWaitForSecondsRandom[Random.Range(0, 19)];

            mFloatingTextTransform.position = startPos;
=======
            yield return k_WaitForSecondsRandom[Random.Range(0, 19)];

            m_floatingText_Transform.position = start_pos;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            StartCoroutine(DisplayTextMeshProFloatingText());
        }


        public IEnumerator DisplayTextMeshFloatingText()
        {
<<<<<<< HEAD
            float countDuration = 2.0f; // How long is the countdown alive.
            float startingCount = Random.Range(5f, 20f); // At what number is the counter starting at.
            float currentCount = startingCount;

            Vector3 startPos = mFloatingTextTransform.position;
            Color32 startColor = mTextMesh.color;
            float alpha = 255;
            int intCounter = 0;

            float fadeDuration = 3 / startingCount * countDuration;

            while (currentCount > 0)
            {
                currentCount -= (Time.deltaTime / countDuration) * startingCount;

                if (currentCount <= 3)
=======
            float CountDuration = 2.0f; // How long is the countdown alive.
            float starting_Count = Random.Range(5f, 20f); // At what number is the counter starting at.
            float current_Count = starting_Count;

            Vector3 start_pos = m_floatingText_Transform.position;
            Color32 start_color = m_textMesh.color;
            float alpha = 255;
            int int_counter = 0;

            float fadeDuration = 3 / starting_Count * CountDuration;

            while (current_Count > 0)
            {
                current_Count -= (Time.deltaTime / CountDuration) * starting_Count;

                if (current_Count <= 3)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                {
                    //Debug.Log("Fading Counter ... " + current_Count.ToString("f2"));
                    alpha = Mathf.Clamp(alpha - (Time.deltaTime / fadeDuration) * 255, 0, 255);
                }

<<<<<<< HEAD
                intCounter = (int)currentCount;
                mTextMesh.text = intCounter.ToString();
                //Debug.Log("Current Count:" + current_Count.ToString("f2"));

                mTextMesh.color = new Color32(startColor.r, startColor.g, startColor.b, (byte)alpha);

                // Move the floating text upward each update
                mFloatingTextTransform.position += new Vector3(0, startingCount * Time.deltaTime, 0);

                // Align floating text perpendicular to Camera.
                if (!lastPos.Compare(mCameraTransform.position, 1000) || !lastRotation.Compare(mCameraTransform.rotation, 1000))
                {
                    lastPos = mCameraTransform.position;
                    lastRotation = mCameraTransform.rotation;
                    mFloatingTextTransform.rotation = lastRotation;
                    Vector3 dir = mTransform.position - lastPos;
                    mTransform.forward = new Vector3(dir.x, 0, dir.z);
                }

                yield return kWaitForEndOfFrame;
=======
                int_counter = (int)current_Count;
                m_textMesh.text = int_counter.ToString();
                //Debug.Log("Current Count:" + current_Count.ToString("f2"));

                m_textMesh.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);

                // Move the floating text upward each update
                m_floatingText_Transform.position += new Vector3(0, starting_Count * Time.deltaTime, 0);

                // Align floating text perpendicular to Camera.
                if (!lastPOS.Compare(m_cameraTransform.position, 1000) || !lastRotation.Compare(m_cameraTransform.rotation, 1000))
                {
                    lastPOS = m_cameraTransform.position;
                    lastRotation = m_cameraTransform.rotation;
                    m_floatingText_Transform.rotation = lastRotation;
                    Vector3 dir = m_transform.position - lastPOS;
                    m_transform.forward = new Vector3(dir.x, 0, dir.z);
                }

                yield return k_WaitForEndOfFrame;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }

            //Debug.Log("Done Counting down.");

<<<<<<< HEAD
            yield return kWaitForSecondsRandom[Random.Range(0, 20)];

            mFloatingTextTransform.position = startPos;
=======
            yield return k_WaitForSecondsRandom[Random.Range(0, 20)];

            m_floatingText_Transform.position = start_pos;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            StartCoroutine(DisplayTextMeshFloatingText());
        }
    }
}
