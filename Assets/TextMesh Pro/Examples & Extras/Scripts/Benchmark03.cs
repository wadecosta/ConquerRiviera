using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
using UnityEngine.TextCore.LowLevel;


namespace TMPro.Examples
{

    public class Benchmark03 : MonoBehaviour
    {
<<<<<<< HEAD
        public enum BenchmarkType { TMPSDFMobile = 0, TMPSDFMobileSsd = 1, TMPSDF = 2, TMPBitmapMobile = 3, TextmeshBitmap = 4 }

        [FormerlySerializedAs("NumberOfSamples")] public int numberOfSamples = 100;
        [FormerlySerializedAs("Benchmark")] public BenchmarkType benchmark;

        [FormerlySerializedAs("SourceFont")] public Font sourceFont;
=======
        public enum BenchmarkType { TMP_SDF_MOBILE = 0, TMP_SDF__MOBILE_SSD = 1, TMP_SDF = 2, TMP_BITMAP_MOBILE = 3, TEXTMESH_BITMAP = 4 }

        public int NumberOfSamples = 100;
        public BenchmarkType Benchmark;

        public Font SourceFont;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


        void Awake()
        {

        }


        void Start()
        {
            TMP_FontAsset fontAsset = null;

            // Create Dynamic Font Asset for the given font file.
<<<<<<< HEAD
            switch (benchmark)
            {
                case BenchmarkType.TMPSDFMobile:
                    fontAsset = TMP_FontAsset.CreateFontAsset(sourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    break;
                case BenchmarkType.TMPSDFMobileSsd:
                    fontAsset = TMP_FontAsset.CreateFontAsset(sourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    fontAsset.material.shader = Shader.Find("TextMeshPro/Mobile/Distance Field SSD");
                    break;
                case BenchmarkType.TMPSDF:
                    fontAsset = TMP_FontAsset.CreateFontAsset(sourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    fontAsset.material.shader = Shader.Find("TextMeshPro/Distance Field");
                    break;
                case BenchmarkType.TMPBitmapMobile:
                    fontAsset = TMP_FontAsset.CreateFontAsset(sourceFont, 90, 9, GlyphRenderMode.SMOOTH, 256, 256, AtlasPopulationMode.Dynamic);
                    break;
            }

            for (int i = 0; i < numberOfSamples; i++)
            {
                switch (benchmark)
                {
                    case BenchmarkType.TMPSDFMobile:
                    case BenchmarkType.TMPSDFMobileSsd:
                    case BenchmarkType.TMPSDF:
                    case BenchmarkType.TMPBitmapMobile:
=======
            switch (Benchmark)
            {
                case BenchmarkType.TMP_SDF_MOBILE:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    break;
                case BenchmarkType.TMP_SDF__MOBILE_SSD:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    fontAsset.material.shader = Shader.Find("TextMeshPro/Mobile/Distance Field SSD");
                    break;
                case BenchmarkType.TMP_SDF:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    fontAsset.material.shader = Shader.Find("TextMeshPro/Distance Field");
                    break;
                case BenchmarkType.TMP_BITMAP_MOBILE:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SMOOTH, 256, 256, AtlasPopulationMode.Dynamic);
                    break;
            }

            for (int i = 0; i < NumberOfSamples; i++)
            {
                switch (Benchmark)
                {
                    case BenchmarkType.TMP_SDF_MOBILE:
                    case BenchmarkType.TMP_SDF__MOBILE_SSD:
                    case BenchmarkType.TMP_SDF:
                    case BenchmarkType.TMP_BITMAP_MOBILE:
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                        {
                            GameObject go = new GameObject();
                            go.transform.position = new Vector3(0, 1.2f, 0);

                            TextMeshPro textComponent = go.AddComponent<TextMeshPro>();
                            textComponent.font = fontAsset;
                            textComponent.fontSize = 128;
                            textComponent.text = "@";
                            textComponent.alignment = TextAlignmentOptions.Center;
                            textComponent.color = new Color32(255, 255, 0, 255);

<<<<<<< HEAD
                            if (benchmark == BenchmarkType.TMPBitmapMobile)
=======
                            if (Benchmark == BenchmarkType.TMP_BITMAP_MOBILE)
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                                textComponent.fontSize = 132;

                        }
                        break;
<<<<<<< HEAD
                    case BenchmarkType.TextmeshBitmap:
=======
                    case BenchmarkType.TEXTMESH_BITMAP:
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                        {
                            GameObject go = new GameObject();
                            go.transform.position = new Vector3(0, 1.2f, 0);

                            TextMesh textMesh = go.AddComponent<TextMesh>();
<<<<<<< HEAD
                            textMesh.GetComponent<Renderer>().sharedMaterial = sourceFont.material;
                            textMesh.font = sourceFont;
=======
                            textMesh.GetComponent<Renderer>().sharedMaterial = SourceFont.material;
                            textMesh.font = SourceFont;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                            textMesh.anchor = TextAnchor.MiddleCenter;
                            textMesh.fontSize = 130;

                            textMesh.color = new Color32(255, 255, 0, 255);
                            textMesh.text = "@";
                        }
                        break;
                }
            }
        }

    }
}
