using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
    public class Benchmark04 : MonoBehaviour
    {

<<<<<<< HEAD
        [FormerlySerializedAs("SpawnType")] public int spawnType = 0;

        [FormerlySerializedAs("MinPointSize")] public int minPointSize = 12;
        [FormerlySerializedAs("MaxPointSize")] public int maxPointSize = 64;
        [FormerlySerializedAs("Steps")] public int steps = 4;

        private Transform mTransform;
=======
        public int SpawnType = 0;

        public int MinPointSize = 12;
        public int MaxPointSize = 64;
        public int Steps = 4;

        private Transform m_Transform;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        //private TextMeshProFloatingText floatingText_Script;
        //public Material material;


        void Start()
        {
<<<<<<< HEAD
            mTransform = transform;
=======
            m_Transform = transform;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

            float lineHeight = 0;
            float orthoSize = Camera.main.orthographicSize = Screen.height / 2;
            float ratio = (float)Screen.width / Screen.height;

<<<<<<< HEAD
            for (int i = minPointSize; i <= maxPointSize; i += steps)
            {
                if (spawnType == 0)
=======
            for (int i = MinPointSize; i <= MaxPointSize; i += Steps)
            {
                if (SpawnType == 0)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                {
                    // TextMesh Pro Implementation
                    GameObject go = new GameObject("Text - " + i + " Pts");

                    if (lineHeight > orthoSize * 2) return;

<<<<<<< HEAD
                    go.transform.position = mTransform.position + new Vector3(ratio * -orthoSize * 0.975f, orthoSize * 0.975f - lineHeight, 0);
=======
                    go.transform.position = m_Transform.position + new Vector3(ratio * -orthoSize * 0.975f, orthoSize * 0.975f - lineHeight, 0);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    TextMeshPro textMeshPro = go.AddComponent<TextMeshPro>();

                    //textMeshPro.fontSharedMaterial = material;
                    //textMeshPro.font = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TextMeshProFont)) as TextMeshProFont;
                    //textMeshPro.anchor = AnchorPositions.Left;
                    textMeshPro.rectTransform.pivot = new Vector2(0, 0.5f);

                    textMeshPro.enableWordWrapping = false;
                    textMeshPro.extraPadding = true;
                    textMeshPro.isOrthographic = true;
                    textMeshPro.fontSize = i;

                    textMeshPro.text = i + " pts - Lorem ipsum dolor sit...";
                    textMeshPro.color = new Color32(255, 255, 255, 255);

                    lineHeight += i;
                }
                else
                {
                    // TextMesh Implementation
                    // Causes crashes since atlas needed exceeds 4096 X 4096
                    /*
                    GameObject go = new GameObject("Arial " + i);

                    //if (lineHeight > orthoSize * 2 * 0.9f) return;

                    go.transform.position = m_Transform.position + new Vector3(ratio * -orthoSize * 0.975f, orthoSize * 0.975f - lineHeight, 1);
                                       
                    TextMesh textMesh = go.AddComponent<TextMesh>();
                    textMesh.font = Resources.Load("Fonts/ARIAL", typeof(Font)) as Font;
                    textMesh.renderer.sharedMaterial = textMesh.font.material;
                    textMesh.anchor = TextAnchor.MiddleLeft;
                    textMesh.fontSize = i * 10;

                    textMesh.color = new Color32(255, 255, 255, 255);
                    textMesh.text = i + " pts - Lorem ipsum dolor sit...";

                    lineHeight += i;
                    */
                }
            }
        }

    }
}
