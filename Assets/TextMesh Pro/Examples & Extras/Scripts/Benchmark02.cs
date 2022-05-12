using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{

    public class Benchmark02 : MonoBehaviour
    {

<<<<<<< HEAD
        [FormerlySerializedAs("SpawnType")] public int spawnType = 0;
        [FormerlySerializedAs("NumberOfNPC")] public int numberOfNpc = 12;

        [FormerlySerializedAs("IsTextObjectScaleStatic")] public bool isTextObjectScaleStatic;
        private TextMeshProFloatingText floatingTextScript;
=======
        public int SpawnType = 0;
        public int NumberOfNPC = 12;

        public bool IsTextObjectScaleStatic;
        private TextMeshProFloatingText floatingText_Script;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


        void Start()
        {

<<<<<<< HEAD
            for (int i = 0; i < numberOfNpc; i++)
            {


                if (spawnType == 0)
=======
            for (int i = 0; i < NumberOfNPC; i++)
            {


                if (SpawnType == 0)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                {
                    // TextMesh Pro Implementation
                    GameObject go = new GameObject();
                    go.transform.position = new Vector3(Random.Range(-95f, 95f), 0.25f, Random.Range(-95f, 95f));

                    TextMeshPro textMeshPro = go.AddComponent<TextMeshPro>();

                    textMeshPro.autoSizeTextContainer = true;
                    textMeshPro.rectTransform.pivot = new Vector2(0.5f, 0);

                    textMeshPro.alignment = TextAlignmentOptions.Bottom;
                    textMeshPro.fontSize = 96;
                    textMeshPro.enableKerning = false;

                    textMeshPro.color = new Color32(255, 255, 0, 255);
                    textMeshPro.text = "!";
<<<<<<< HEAD
                    textMeshPro.isTextObjectScaleStatic = isTextObjectScaleStatic;

                    // Spawn Floating Text
                    floatingTextScript = go.AddComponent<TextMeshProFloatingText>();
                    floatingTextScript.spawnType = 0;
                    floatingTextScript.isTextObjectScaleStatic = isTextObjectScaleStatic;
                }
                else if (spawnType == 1)
=======
                    textMeshPro.isTextObjectScaleStatic = IsTextObjectScaleStatic;

                    // Spawn Floating Text
                    floatingText_Script = go.AddComponent<TextMeshProFloatingText>();
                    floatingText_Script.SpawnType = 0;
                    floatingText_Script.IsTextObjectScaleStatic = IsTextObjectScaleStatic;
                }
                else if (SpawnType == 1)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                {
                    // TextMesh Implementation
                    GameObject go = new GameObject();
                    go.transform.position = new Vector3(Random.Range(-95f, 95f), 0.25f, Random.Range(-95f, 95f));

                    TextMesh textMesh = go.AddComponent<TextMesh>();
                    textMesh.font = Resources.Load<Font>("Fonts/ARIAL");
                    textMesh.GetComponent<Renderer>().sharedMaterial = textMesh.font.material;

                    textMesh.anchor = TextAnchor.LowerCenter;
                    textMesh.fontSize = 96;

                    textMesh.color = new Color32(255, 255, 0, 255);
                    textMesh.text = "!";

                    // Spawn Floating Text
<<<<<<< HEAD
                    floatingTextScript = go.AddComponent<TextMeshProFloatingText>();
                    floatingTextScript.spawnType = 1;
                }
                else if (spawnType == 2)
=======
                    floatingText_Script = go.AddComponent<TextMeshProFloatingText>();
                    floatingText_Script.SpawnType = 1;
                }
                else if (SpawnType == 2)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                {
                    // Canvas WorldSpace Camera
                    GameObject go = new GameObject();
                    Canvas canvas = go.AddComponent<Canvas>();
                    canvas.worldCamera = Camera.main;

                    go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    go.transform.position = new Vector3(Random.Range(-95f, 95f), 5f, Random.Range(-95f, 95f));

                    TextMeshProUGUI textObject = new GameObject().AddComponent<TextMeshProUGUI>();
                    textObject.rectTransform.SetParent(go.transform, false);

                    textObject.color = new Color32(255, 255, 0, 255);
                    textObject.alignment = TextAlignmentOptions.Bottom;
                    textObject.fontSize = 96;
                    textObject.text = "!";

                    // Spawn Floating Text
<<<<<<< HEAD
                    floatingTextScript = go.AddComponent<TextMeshProFloatingText>();
                    floatingTextScript.spawnType = 0;
=======
                    floatingText_Script = go.AddComponent<TextMeshProFloatingText>();
                    floatingText_Script.SpawnType = 0;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }



            }
        }
    }
}
