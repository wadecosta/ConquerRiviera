using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


#pragma warning disable 0618 // Disabled warning due to SetVertices being deprecated until new release with SetMesh() is available.

namespace TMPro.Examples
{

<<<<<<< HEAD
    public class TMPTextSelectorB : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
    {
        [FormerlySerializedAs("TextPopup_Prefab_01")] public RectTransform textPopupPrefab01;

        private RectTransform mTextPopupRectTransform;
        private TextMeshProUGUI mTextPopupTMPComponent;
        private const string K_LINK_TEXT = "You have selected link <#ffff00>";
        private const string K_WORD_TEXT = "Word Index: <#ffff00>";


        private TextMeshProUGUI mTextMeshPro;
        private Canvas mCanvas;
        private Camera mCamera;

        // Flags
        private bool isHoveringObject;
        private int mSelectedWord = -1;
        private int mSelectedLink = -1;
        private int mLastIndex = -1;

        private Matrix4x4 mMatrix;

        private TMP_MeshInfo[] mCachedMeshInfoVertexData;

        void Awake()
        {
            mTextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();


            mCanvas = gameObject.GetComponentInParent<Canvas>();

            // Get a reference to the camera if Canvas Render Mode is not ScreenSpace Overlay.
            if (mCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
                mCamera = null;
            else
                mCamera = mCanvas.worldCamera;

            // Create pop-up text object which is used to show the link information.
            mTextPopupRectTransform = Instantiate(textPopupPrefab01) as RectTransform;
            mTextPopupRectTransform.SetParent(mCanvas.transform, false);
            mTextPopupTMPComponent = mTextPopupRectTransform.GetComponentInChildren<TextMeshProUGUI>();
            mTextPopupRectTransform.gameObject.SetActive(false);
=======
    public class TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
    {
        public RectTransform TextPopup_Prefab_01;

        private RectTransform m_TextPopup_RectTransform;
        private TextMeshProUGUI m_TextPopup_TMPComponent;
        private const string k_LinkText = "You have selected link <#ffff00>";
        private const string k_WordText = "Word Index: <#ffff00>";


        private TextMeshProUGUI m_TextMeshPro;
        private Canvas m_Canvas;
        private Camera m_Camera;

        // Flags
        private bool isHoveringObject;
        private int m_selectedWord = -1;
        private int m_selectedLink = -1;
        private int m_lastIndex = -1;

        private Matrix4x4 m_matrix;

        private TMP_MeshInfo[] m_cachedMeshInfoVertexData;

        void Awake()
        {
            m_TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();


            m_Canvas = gameObject.GetComponentInParent<Canvas>();

            // Get a reference to the camera if Canvas Render Mode is not ScreenSpace Overlay.
            if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
                m_Camera = null;
            else
                m_Camera = m_Canvas.worldCamera;

            // Create pop-up text object which is used to show the link information.
            m_TextPopup_RectTransform = Instantiate(TextPopup_Prefab_01) as RectTransform;
            m_TextPopup_RectTransform.SetParent(m_Canvas.transform, false);
            m_TextPopup_TMPComponent = m_TextPopup_RectTransform.GetComponentInChildren<TextMeshProUGUI>();
            m_TextPopup_RectTransform.gameObject.SetActive(false);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }


        void OnEnable()
        {
            // Subscribe to event fired when text object has been regenerated.
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
        }

        void OnDisable()
        {
            // UnSubscribe to event fired when text object has been regenerated.
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
        }


        void ON_TEXT_CHANGED(Object obj)
        {
<<<<<<< HEAD
            if (obj == mTextMeshPro)
            {
                // Update cached vertex data.
                mCachedMeshInfoVertexData = mTextMeshPro.textInfo.CopyMeshInfoVertexData();
=======
            if (obj == m_TextMeshPro)
            {
                // Update cached vertex data.
                m_cachedMeshInfoVertexData = m_TextMeshPro.textInfo.CopyMeshInfoVertexData();
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }
        }


        void LateUpdate()
        {
            if (isHoveringObject)
            {
                // Check if Mouse Intersects any of the characters. If so, assign a random color.
                #region Handle Character Selection
<<<<<<< HEAD
                int charIndex = TMP_TextUtilities.FindIntersectingCharacter(mTextMeshPro, Input.mousePosition, mCamera, true);

                // Undo Swap and Vertex Attribute changes.
                if (charIndex == -1 || charIndex != mLastIndex)
                {
                    RestoreCachedVertexAttributes(mLastIndex);
                    mLastIndex = -1;
                }

                if (charIndex != -1 && charIndex != mLastIndex && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    mLastIndex = charIndex;

                    // Get the index of the material / sub text object used by this character.
                    int materialIndex = mTextMeshPro.textInfo.characterInfo[charIndex].materialReferenceIndex;

                    // Get the index of the first vertex of the selected character.
                    int vertexIndex = mTextMeshPro.textInfo.characterInfo[charIndex].vertexIndex;

                    // Get a reference to the vertices array.
                    Vector3[] vertices = mTextMeshPro.textInfo.meshInfo[materialIndex].vertices;
=======
                int charIndex = TMP_TextUtilities.FindIntersectingCharacter(m_TextMeshPro, Input.mousePosition, m_Camera, true);

                // Undo Swap and Vertex Attribute changes.
                if (charIndex == -1 || charIndex != m_lastIndex)
                {
                    RestoreCachedVertexAttributes(m_lastIndex);
                    m_lastIndex = -1;
                }

                if (charIndex != -1 && charIndex != m_lastIndex && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    m_lastIndex = charIndex;

                    // Get the index of the material / sub text object used by this character.
                    int materialIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].materialReferenceIndex;

                    // Get the index of the first vertex of the selected character.
                    int vertexIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].vertexIndex;

                    // Get a reference to the vertices array.
                    Vector3[] vertices = m_TextMeshPro.textInfo.meshInfo[materialIndex].vertices;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    // Determine the center point of the character.
                    Vector2 charMidBasline = (vertices[vertexIndex + 0] + vertices[vertexIndex + 2]) / 2;

                    // Need to translate all 4 vertices of the character to aligned with middle of character / baseline.
                    // This is needed so the matrix TRS is applied at the origin for each character.
                    Vector3 offset = charMidBasline;

                    // Translate the character to the middle baseline.
                    vertices[vertexIndex + 0] = vertices[vertexIndex + 0] - offset;
                    vertices[vertexIndex + 1] = vertices[vertexIndex + 1] - offset;
                    vertices[vertexIndex + 2] = vertices[vertexIndex + 2] - offset;
                    vertices[vertexIndex + 3] = vertices[vertexIndex + 3] - offset;

                    float zoomFactor = 1.5f;

                    // Setup the Matrix for the scale change.
<<<<<<< HEAD
                    mMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * zoomFactor);

                    // Apply Matrix operation on the given character.
                    vertices[vertexIndex + 0] = mMatrix.MultiplyPoint3x4(vertices[vertexIndex + 0]);
                    vertices[vertexIndex + 1] = mMatrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
                    vertices[vertexIndex + 2] = mMatrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
                    vertices[vertexIndex + 3] = mMatrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
=======
                    m_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * zoomFactor);

                    // Apply Matrix operation on the given character.
                    vertices[vertexIndex + 0] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 0]);
                    vertices[vertexIndex + 1] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
                    vertices[vertexIndex + 2] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
                    vertices[vertexIndex + 3] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    // Translate the character back to its original position.
                    vertices[vertexIndex + 0] = vertices[vertexIndex + 0] + offset;
                    vertices[vertexIndex + 1] = vertices[vertexIndex + 1] + offset;
                    vertices[vertexIndex + 2] = vertices[vertexIndex + 2] + offset;
                    vertices[vertexIndex + 3] = vertices[vertexIndex + 3] + offset;

                    // Change Vertex Colors of the highlighted character
                    Color32 c = new Color32(255, 255, 192, 255);

                    // Get a reference to the vertex color
<<<<<<< HEAD
                    Color32[] vertexColors = mTextMeshPro.textInfo.meshInfo[materialIndex].colors32;
=======
                    Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[materialIndex].colors32;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    vertexColors[vertexIndex + 0] = c;
                    vertexColors[vertexIndex + 1] = c;
                    vertexColors[vertexIndex + 2] = c;
                    vertexColors[vertexIndex + 3] = c;


                    // Get a reference to the meshInfo of the selected character.
<<<<<<< HEAD
                    TMP_MeshInfo meshInfo = mTextMeshPro.textInfo.meshInfo[materialIndex];
=======
                    TMP_MeshInfo meshInfo = m_TextMeshPro.textInfo.meshInfo[materialIndex];
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    // Get the index of the last character's vertex attributes.
                    int lastVertexIndex = vertices.Length - 4;

                    // Swap the current character's vertex attributes with those of the last element in the vertex attribute arrays.
                    // We do this to make sure this character is rendered last and over other characters.
                    meshInfo.SwapVertexData(vertexIndex, lastVertexIndex);

                    // Need to update the appropriate 
<<<<<<< HEAD
                    mTextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
=======
                    m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }
                #endregion


                #region Word Selection Handling
                //Check if Mouse intersects any words and if so assign a random color to that word.
<<<<<<< HEAD
                int wordIndex = TMP_TextUtilities.FindIntersectingWord(mTextMeshPro, Input.mousePosition, mCamera);

                // Clear previous word selection.
                if (mTextPopupRectTransform != null && mSelectedWord != -1 && (wordIndex == -1 || wordIndex != mSelectedWord))
                {
                    TMP_WordInfo wInfo = mTextMeshPro.textInfo.wordInfo[mSelectedWord];
=======
                int wordIndex = TMP_TextUtilities.FindIntersectingWord(m_TextMeshPro, Input.mousePosition, m_Camera);

                // Clear previous word selection.
                if (m_TextPopup_RectTransform != null && m_selectedWord != -1 && (wordIndex == -1 || wordIndex != m_selectedWord))
                {
                    TMP_WordInfo wInfo = m_TextMeshPro.textInfo.wordInfo[m_selectedWord];
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    // Iterate through each of the characters of the word.
                    for (int i = 0; i < wInfo.characterCount; i++)
                    {
                        int characterIndex = wInfo.firstCharacterIndex + i;

                        // Get the index of the material / sub text object used by this character.
<<<<<<< HEAD
                        int meshIndex = mTextMeshPro.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                        // Get the index of the first vertex of this character.
                        int vertexIndex = mTextMeshPro.textInfo.characterInfo[characterIndex].vertexIndex;

                        // Get a reference to the vertex color
                        Color32[] vertexColors = mTextMeshPro.textInfo.meshInfo[meshIndex].colors32;
=======
                        int meshIndex = m_TextMeshPro.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                        // Get the index of the first vertex of this character.
                        int vertexIndex = m_TextMeshPro.textInfo.characterInfo[characterIndex].vertexIndex;

                        // Get a reference to the vertex color
                        Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                        Color32 c = vertexColors[vertexIndex + 0].Tint(1.33333f);

                        vertexColors[vertexIndex + 0] = c;
                        vertexColors[vertexIndex + 1] = c;
                        vertexColors[vertexIndex + 2] = c;
                        vertexColors[vertexIndex + 3] = c;
                    }

                    // Update Geometry
<<<<<<< HEAD
                    mTextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);

                    mSelectedWord = -1;
=======
                    m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);

                    m_selectedWord = -1;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }


                // Word Selection Handling
<<<<<<< HEAD
                if (wordIndex != -1 && wordIndex != mSelectedWord && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    mSelectedWord = wordIndex;

                    TMP_WordInfo wInfo = mTextMeshPro.textInfo.wordInfo[wordIndex];
=======
                if (wordIndex != -1 && wordIndex != m_selectedWord && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    m_selectedWord = wordIndex;

                    TMP_WordInfo wInfo = m_TextMeshPro.textInfo.wordInfo[wordIndex];
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    // Iterate through each of the characters of the word.
                    for (int i = 0; i < wInfo.characterCount; i++)
                    {
                        int characterIndex = wInfo.firstCharacterIndex + i;

                        // Get the index of the material / sub text object used by this character.
<<<<<<< HEAD
                        int meshIndex = mTextMeshPro.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                        int vertexIndex = mTextMeshPro.textInfo.characterInfo[characterIndex].vertexIndex;

                        // Get a reference to the vertex color
                        Color32[] vertexColors = mTextMeshPro.textInfo.meshInfo[meshIndex].colors32;
=======
                        int meshIndex = m_TextMeshPro.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                        int vertexIndex = m_TextMeshPro.textInfo.characterInfo[characterIndex].vertexIndex;

                        // Get a reference to the vertex color
                        Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                        Color32 c = vertexColors[vertexIndex + 0].Tint(0.75f);

                        vertexColors[vertexIndex + 0] = c;
                        vertexColors[vertexIndex + 1] = c;
                        vertexColors[vertexIndex + 2] = c;
                        vertexColors[vertexIndex + 3] = c;
                    }

                    // Update Geometry
<<<<<<< HEAD
                    mTextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
=======
                    m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                }
                #endregion


                #region Example of Link Handling
                // Check if mouse intersects with any links.
<<<<<<< HEAD
                int linkIndex = TMP_TextUtilities.FindIntersectingLink(mTextMeshPro, Input.mousePosition, mCamera);

                // Clear previous link selection if one existed.
                if ((linkIndex == -1 && mSelectedLink != -1) || linkIndex != mSelectedLink)
                {
                    mTextPopupRectTransform.gameObject.SetActive(false);
                    mSelectedLink = -1;
                }

                // Handle new Link selection.
                if (linkIndex != -1 && linkIndex != mSelectedLink)
                {
                    mSelectedLink = linkIndex;

                    TMP_LinkInfo linkInfo = mTextMeshPro.textInfo.linkInfo[linkIndex];
=======
                int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);

                // Clear previous link selection if one existed.
                if ((linkIndex == -1 && m_selectedLink != -1) || linkIndex != m_selectedLink)
                {
                    m_TextPopup_RectTransform.gameObject.SetActive(false);
                    m_selectedLink = -1;
                }

                // Handle new Link selection.
                if (linkIndex != -1 && linkIndex != m_selectedLink)
                {
                    m_selectedLink = linkIndex;

                    TMP_LinkInfo linkInfo = m_TextMeshPro.textInfo.linkInfo[linkIndex];
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    // Debug.Log("Link ID: \"" + linkInfo.GetLinkID() + "\"   Link Text: \"" + linkInfo.GetLinkText() + "\""); // Example of how to retrieve the Link ID and Link Text.

                    Vector3 worldPointInRectangle;
<<<<<<< HEAD
                    RectTransformUtility.ScreenPointToWorldPointInRectangle(mTextMeshPro.rectTransform, Input.mousePosition, mCamera, out worldPointInRectangle);
=======
                    RectTransformUtility.ScreenPointToWorldPointInRectangle(m_TextMeshPro.rectTransform, Input.mousePosition, m_Camera, out worldPointInRectangle);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                    switch (linkInfo.GetLinkID())
                    {
                        case "id_01": // 100041637: // id_01
<<<<<<< HEAD
                            mTextPopupRectTransform.position = worldPointInRectangle;
                            mTextPopupRectTransform.gameObject.SetActive(true);
                            mTextPopupTMPComponent.text = K_LINK_TEXT + " ID 01";
                            break;
                        case "id_02": // 100041638: // id_02
                            mTextPopupRectTransform.position = worldPointInRectangle;
                            mTextPopupRectTransform.gameObject.SetActive(true);
                            mTextPopupTMPComponent.text = K_LINK_TEXT + " ID 02";
=======
                            m_TextPopup_RectTransform.position = worldPointInRectangle;
                            m_TextPopup_RectTransform.gameObject.SetActive(true);
                            m_TextPopup_TMPComponent.text = k_LinkText + " ID 01";
                            break;
                        case "id_02": // 100041638: // id_02
                            m_TextPopup_RectTransform.position = worldPointInRectangle;
                            m_TextPopup_RectTransform.gameObject.SetActive(true);
                            m_TextPopup_TMPComponent.text = k_LinkText + " ID 02";
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                            break;
                    }
                }
                #endregion

            }
            else
            {
                // Restore any character that may have been modified
<<<<<<< HEAD
                if (mLastIndex != -1)
                {
                    RestoreCachedVertexAttributes(mLastIndex);
                    mLastIndex = -1;
=======
                if (m_lastIndex != -1)
                {
                    RestoreCachedVertexAttributes(m_lastIndex);
                    m_lastIndex = -1;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }
            }
            
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("OnPointerEnter()");
            isHoveringObject = true;
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("OnPointerExit()");
            isHoveringObject = false;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log("Click at POS: " + eventData.position + "  World POS: " + eventData.worldPosition);

            // Check if Mouse Intersects any of the characters. If so, assign a random color.
            #region Character Selection Handling
            /*
            int charIndex = TMP_TextUtilities.FindIntersectingCharacter(m_TextMeshPro, Input.mousePosition, m_Camera, true);
            if (charIndex != -1 && charIndex != m_lastIndex)
            {
                //Debug.Log("Character [" + m_TextMeshPro.textInfo.characterInfo[index].character + "] was selected at POS: " + eventData.position);
                m_lastIndex = charIndex;

                Color32 c = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                int vertexIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].vertexIndex;

                UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;

                uiVertices[vertexIndex + 0].color = c;
                uiVertices[vertexIndex + 1].color = c;
                uiVertices[vertexIndex + 2].color = c;
                uiVertices[vertexIndex + 3].color = c;

                m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);
            }
            */
            #endregion


            #region Word Selection Handling
            //Check if Mouse intersects any words and if so assign a random color to that word.
            /*
            int wordIndex = TMP_TextUtilities.FindIntersectingWord(m_TextMeshPro, Input.mousePosition, m_Camera);

            // Clear previous word selection.
            if (m_TextPopup_RectTransform != null && m_selectedWord != -1 && (wordIndex == -1 || wordIndex != m_selectedWord))
            {
                TMP_WordInfo wInfo = m_TextMeshPro.textInfo.wordInfo[m_selectedWord];

                // Get a reference to the uiVertices array.
                UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;

                // Iterate through each of the characters of the word.
                for (int i = 0; i < wInfo.characterCount; i++)
                {
                    int vertexIndex = m_TextMeshPro.textInfo.characterInfo[wInfo.firstCharacterIndex + i].vertexIndex;

                    Color32 c = uiVertices[vertexIndex + 0].color.Tint(1.33333f);

                    uiVertices[vertexIndex + 0].color = c;
                    uiVertices[vertexIndex + 1].color = c;
                    uiVertices[vertexIndex + 2].color = c;
                    uiVertices[vertexIndex + 3].color = c;
                }

                m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);

                m_selectedWord = -1;
            }

            // Handle word selection
            if (wordIndex != -1 && wordIndex != m_selectedWord)
            {
                m_selectedWord = wordIndex;

                TMP_WordInfo wInfo = m_TextMeshPro.textInfo.wordInfo[wordIndex];

                // Get a reference to the uiVertices array.
                UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;

                // Iterate through each of the characters of the word.
                for (int i = 0; i < wInfo.characterCount; i++)
                {
                    int vertexIndex = m_TextMeshPro.textInfo.characterInfo[wInfo.firstCharacterIndex + i].vertexIndex;

                    Color32 c = uiVertices[vertexIndex + 0].color.Tint(0.75f);

                    uiVertices[vertexIndex + 0].color = c;
                    uiVertices[vertexIndex + 1].color = c;
                    uiVertices[vertexIndex + 2].color = c;
                    uiVertices[vertexIndex + 3].color = c;
                }

                m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);
            }
            */
            #endregion


            #region Link Selection Handling
            /*
            // Check if Mouse intersects any words and if so assign a random color to that word.
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = m_TextMeshPro.textInfo.linkInfo[linkIndex];
                int linkHashCode = linkInfo.hashCode;

                //Debug.Log(TMP_TextUtilities.GetSimpleHashCode("id_02"));

                switch (linkHashCode)
                {
                    case 291445: // id_01
                        if (m_LinkObject01 == null)
                            m_LinkObject01 = Instantiate(Link_01_Prefab);
                        else
                        {
                            m_LinkObject01.gameObject.SetActive(true);
                        }

                        break;
                    case 291446: // id_02
                        break;

                }

                // Example of how to modify vertex attributes like colors
                #region Vertex Attribute Modification Example
                UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;

                Color32 c = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                for (int i = 0; i < linkInfo.characterCount; i++)
                {
                    TMP_CharacterInfo cInfo = m_TextMeshPro.textInfo.characterInfo[linkInfo.firstCharacterIndex + i];

                    if (!cInfo.isVisible) continue; // Skip invisible characters.

                    int vertexIndex = cInfo.vertexIndex;

                    uiVertices[vertexIndex + 0].color = c;
                    uiVertices[vertexIndex + 1].color = c;
                    uiVertices[vertexIndex + 2].color = c;
                    uiVertices[vertexIndex + 3].color = c;
                }

                m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);
                #endregion
            }
            */
            #endregion
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            //Debug.Log("OnPointerUp()");
        }


        void RestoreCachedVertexAttributes(int index)
        {
<<<<<<< HEAD
            if (index == -1 || index > mTextMeshPro.textInfo.characterCount - 1) return;

            // Get the index of the material / sub text object used by this character.
            int materialIndex = mTextMeshPro.textInfo.characterInfo[index].materialReferenceIndex;

            // Get the index of the first vertex of the selected character.
            int vertexIndex = mTextMeshPro.textInfo.characterInfo[index].vertexIndex;

            // Restore Vertices
            // Get a reference to the cached / original vertices.
            Vector3[] srcVertices = mCachedMeshInfoVertexData[materialIndex].vertices;

            // Get a reference to the vertices that we need to replace.
            Vector3[] dstVertices = mTextMeshPro.textInfo.meshInfo[materialIndex].vertices;

            // Restore / Copy vertices from source to destination
            dstVertices[vertexIndex + 0] = srcVertices[vertexIndex + 0];
            dstVertices[vertexIndex + 1] = srcVertices[vertexIndex + 1];
            dstVertices[vertexIndex + 2] = srcVertices[vertexIndex + 2];
            dstVertices[vertexIndex + 3] = srcVertices[vertexIndex + 3];

            // Restore Vertex Colors
            // Get a reference to the vertex colors we need to replace.
            Color32[] dstColors = mTextMeshPro.textInfo.meshInfo[materialIndex].colors32;

            // Get a reference to the cached / original vertex colors.
            Color32[] srcColors = mCachedMeshInfoVertexData[materialIndex].colors32;

            // Copy the vertex colors from source to destination.
            dstColors[vertexIndex + 0] = srcColors[vertexIndex + 0];
            dstColors[vertexIndex + 1] = srcColors[vertexIndex + 1];
            dstColors[vertexIndex + 2] = srcColors[vertexIndex + 2];
            dstColors[vertexIndex + 3] = srcColors[vertexIndex + 3];

            // Restore UV0S
            // UVS0
            Vector2[] srcUV0S = mCachedMeshInfoVertexData[materialIndex].uvs0;
            Vector2[] dstUV0S = mTextMeshPro.textInfo.meshInfo[materialIndex].uvs0;
            dstUV0S[vertexIndex + 0] = srcUV0S[vertexIndex + 0];
            dstUV0S[vertexIndex + 1] = srcUV0S[vertexIndex + 1];
            dstUV0S[vertexIndex + 2] = srcUV0S[vertexIndex + 2];
            dstUV0S[vertexIndex + 3] = srcUV0S[vertexIndex + 3];

            // UVS2
            Vector2[] srcUV2S = mCachedMeshInfoVertexData[materialIndex].uvs2;
            Vector2[] dstUV2S = mTextMeshPro.textInfo.meshInfo[materialIndex].uvs2;
            dstUV2S[vertexIndex + 0] = srcUV2S[vertexIndex + 0];
            dstUV2S[vertexIndex + 1] = srcUV2S[vertexIndex + 1];
            dstUV2S[vertexIndex + 2] = srcUV2S[vertexIndex + 2];
            dstUV2S[vertexIndex + 3] = srcUV2S[vertexIndex + 3];


            // Restore last vertex attribute as we swapped it as well
            int lastIndex = (srcVertices.Length / 4 - 1) * 4;

            // Vertices
            dstVertices[lastIndex + 0] = srcVertices[lastIndex + 0];
            dstVertices[lastIndex + 1] = srcVertices[lastIndex + 1];
            dstVertices[lastIndex + 2] = srcVertices[lastIndex + 2];
            dstVertices[lastIndex + 3] = srcVertices[lastIndex + 3];

            // Vertex Colors
            srcColors = mCachedMeshInfoVertexData[materialIndex].colors32;
            dstColors = mTextMeshPro.textInfo.meshInfo[materialIndex].colors32;
            dstColors[lastIndex + 0] = srcColors[lastIndex + 0];
            dstColors[lastIndex + 1] = srcColors[lastIndex + 1];
            dstColors[lastIndex + 2] = srcColors[lastIndex + 2];
            dstColors[lastIndex + 3] = srcColors[lastIndex + 3];

            // UVS0
            srcUV0S = mCachedMeshInfoVertexData[materialIndex].uvs0;
            dstUV0S = mTextMeshPro.textInfo.meshInfo[materialIndex].uvs0;
            dstUV0S[lastIndex + 0] = srcUV0S[lastIndex + 0];
            dstUV0S[lastIndex + 1] = srcUV0S[lastIndex + 1];
            dstUV0S[lastIndex + 2] = srcUV0S[lastIndex + 2];
            dstUV0S[lastIndex + 3] = srcUV0S[lastIndex + 3];

            // UVS2
            srcUV2S = mCachedMeshInfoVertexData[materialIndex].uvs2;
            dstUV2S = mTextMeshPro.textInfo.meshInfo[materialIndex].uvs2;
            dstUV2S[lastIndex + 0] = srcUV2S[lastIndex + 0];
            dstUV2S[lastIndex + 1] = srcUV2S[lastIndex + 1];
            dstUV2S[lastIndex + 2] = srcUV2S[lastIndex + 2];
            dstUV2S[lastIndex + 3] = srcUV2S[lastIndex + 3];

            // Need to update the appropriate 
            mTextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
=======
            if (index == -1 || index > m_TextMeshPro.textInfo.characterCount - 1) return;

            // Get the index of the material / sub text object used by this character.
            int materialIndex = m_TextMeshPro.textInfo.characterInfo[index].materialReferenceIndex;

            // Get the index of the first vertex of the selected character.
            int vertexIndex = m_TextMeshPro.textInfo.characterInfo[index].vertexIndex;

            // Restore Vertices
            // Get a reference to the cached / original vertices.
            Vector3[] src_vertices = m_cachedMeshInfoVertexData[materialIndex].vertices;

            // Get a reference to the vertices that we need to replace.
            Vector3[] dst_vertices = m_TextMeshPro.textInfo.meshInfo[materialIndex].vertices;

            // Restore / Copy vertices from source to destination
            dst_vertices[vertexIndex + 0] = src_vertices[vertexIndex + 0];
            dst_vertices[vertexIndex + 1] = src_vertices[vertexIndex + 1];
            dst_vertices[vertexIndex + 2] = src_vertices[vertexIndex + 2];
            dst_vertices[vertexIndex + 3] = src_vertices[vertexIndex + 3];

            // Restore Vertex Colors
            // Get a reference to the vertex colors we need to replace.
            Color32[] dst_colors = m_TextMeshPro.textInfo.meshInfo[materialIndex].colors32;

            // Get a reference to the cached / original vertex colors.
            Color32[] src_colors = m_cachedMeshInfoVertexData[materialIndex].colors32;

            // Copy the vertex colors from source to destination.
            dst_colors[vertexIndex + 0] = src_colors[vertexIndex + 0];
            dst_colors[vertexIndex + 1] = src_colors[vertexIndex + 1];
            dst_colors[vertexIndex + 2] = src_colors[vertexIndex + 2];
            dst_colors[vertexIndex + 3] = src_colors[vertexIndex + 3];

            // Restore UV0S
            // UVS0
            Vector2[] src_uv0s = m_cachedMeshInfoVertexData[materialIndex].uvs0;
            Vector2[] dst_uv0s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs0;
            dst_uv0s[vertexIndex + 0] = src_uv0s[vertexIndex + 0];
            dst_uv0s[vertexIndex + 1] = src_uv0s[vertexIndex + 1];
            dst_uv0s[vertexIndex + 2] = src_uv0s[vertexIndex + 2];
            dst_uv0s[vertexIndex + 3] = src_uv0s[vertexIndex + 3];

            // UVS2
            Vector2[] src_uv2s = m_cachedMeshInfoVertexData[materialIndex].uvs2;
            Vector2[] dst_uv2s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs2;
            dst_uv2s[vertexIndex + 0] = src_uv2s[vertexIndex + 0];
            dst_uv2s[vertexIndex + 1] = src_uv2s[vertexIndex + 1];
            dst_uv2s[vertexIndex + 2] = src_uv2s[vertexIndex + 2];
            dst_uv2s[vertexIndex + 3] = src_uv2s[vertexIndex + 3];


            // Restore last vertex attribute as we swapped it as well
            int lastIndex = (src_vertices.Length / 4 - 1) * 4;

            // Vertices
            dst_vertices[lastIndex + 0] = src_vertices[lastIndex + 0];
            dst_vertices[lastIndex + 1] = src_vertices[lastIndex + 1];
            dst_vertices[lastIndex + 2] = src_vertices[lastIndex + 2];
            dst_vertices[lastIndex + 3] = src_vertices[lastIndex + 3];

            // Vertex Colors
            src_colors = m_cachedMeshInfoVertexData[materialIndex].colors32;
            dst_colors = m_TextMeshPro.textInfo.meshInfo[materialIndex].colors32;
            dst_colors[lastIndex + 0] = src_colors[lastIndex + 0];
            dst_colors[lastIndex + 1] = src_colors[lastIndex + 1];
            dst_colors[lastIndex + 2] = src_colors[lastIndex + 2];
            dst_colors[lastIndex + 3] = src_colors[lastIndex + 3];

            // UVS0
            src_uv0s = m_cachedMeshInfoVertexData[materialIndex].uvs0;
            dst_uv0s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs0;
            dst_uv0s[lastIndex + 0] = src_uv0s[lastIndex + 0];
            dst_uv0s[lastIndex + 1] = src_uv0s[lastIndex + 1];
            dst_uv0s[lastIndex + 2] = src_uv0s[lastIndex + 2];
            dst_uv0s[lastIndex + 3] = src_uv0s[lastIndex + 3];

            // UVS2
            src_uv2s = m_cachedMeshInfoVertexData[materialIndex].uvs2;
            dst_uv2s = m_TextMeshPro.textInfo.meshInfo[materialIndex].uvs2;
            dst_uv2s[lastIndex + 0] = src_uv2s[lastIndex + 0];
            dst_uv2s[lastIndex + 1] = src_uv2s[lastIndex + 1];
            dst_uv2s[lastIndex + 2] = src_uv2s[lastIndex + 2];
            dst_uv2s[lastIndex + 3] = src_uv2s[lastIndex + 3];

            // Need to update the appropriate 
            m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }
    }
}
