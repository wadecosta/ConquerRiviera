using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
    public class TextMeshSpawner : MonoBehaviour
    {

<<<<<<< HEAD
        [FormerlySerializedAs("SpawnType")] public int spawnType = 0;
        [FormerlySerializedAs("NumberOfNPC")] public int numberOfNpc = 12;

        [FormerlySerializedAs("TheFont")] public Font theFont;

        private TextMeshProFloatingText floatingTextScript;
=======
        public int SpawnType = 0;
        public int NumberOfNPC = 12;

        public Font TheFont;

        private TextMeshProFloatingText floatingText_Script;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        void Awake()
        {

        }

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
                    //go.transform.localScale = new Vector3(2, 2, 2);
                    GameObject go = new GameObject(); //"NPC " + i);
                    go.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));

                    //go.transform.position = new Vector3(0, 1.01f, 0);
                    //go.renderer.castShadows = false;
                    //go.renderer.receiveShadows = false;
                    //go.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

                    TextMeshPro textMeshPro = go.AddComponent<TextMeshPro>();
                    //textMeshPro.FontAsset = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TextMeshProFont)) as TextMeshProFont;
                    //textMeshPro.anchor = AnchorPositions.Bottom;
                    textMeshPro.fontSize = 96;

                    textMeshPro.text = "!";
                    textMeshPro.color = new Color32(255, 255, 0, 255);
                    //textMeshPro.Text = "!";


                    // Spawn Floating Text
<<<<<<< HEAD
                    floatingTextScript = go.AddComponent<TextMeshProFloatingText>();
                    floatingTextScript.spawnType = 0;
=======
                    floatingText_Script = go.AddComponent<TextMeshProFloatingText>();
                    floatingText_Script.SpawnType = 0;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }
                else
                {
                    // TextMesh Implementation
                    GameObject go = new GameObject(); //"NPC " + i);
                    go.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));

                    //go.transform.position = new Vector3(0, 1.01f, 0);

                    TextMesh textMesh = go.AddComponent<TextMesh>();
<<<<<<< HEAD
                    textMesh.GetComponent<Renderer>().sharedMaterial = theFont.material;
                    textMesh.font = theFont;
=======
                    textMesh.GetComponent<Renderer>().sharedMaterial = TheFont.material;
                    textMesh.font = TheFont;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    textMesh.anchor = TextAnchor.LowerCenter;
                    textMesh.fontSize = 96;

                    textMesh.color = new Color32(255, 255, 0, 255);
                    textMesh.text = "!";

                    // Spawn Floating Text
<<<<<<< HEAD
                    floatingTextScript = go.AddComponent<TextMeshProFloatingText>();
                    floatingTextScript.spawnType = 1;
=======
                    floatingText_Script = go.AddComponent<TextMeshProFloatingText>();
                    floatingText_Script.SpawnType = 1;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }
            }
        }

    }
}
