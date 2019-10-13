using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolManager : MonoBehaviour
{
    public GameObject currentDoc = null;
    public GameObject docLabel;
    private DocumentManager documentManager;
    private TouchScreenKeyboard keyboard = null;

    void Awake()
    {
        documentManager = GameObject.Find("Documents").GetComponent<DocumentManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard != null && currentDoc != null)
        {
            if (keyboard.done)
            {
                SetText(keyboard.text);
                currentDoc.GetComponent<DocumentComponent>().UpdateText(keyboard.text);
                keyboard = null;
            }
        }
    }

    public void SetDocument(GameObject doc)
    {
        currentDoc = doc;
        SetText(doc.GetComponent<DocumentComponent>().GetText());
    }

    void SetText(string text)
    {
        docLabel.GetComponent<TextMeshPro>().text = text;
    }

    public void RenameDocument()
    {
        if (keyboard == null)
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
        }
        
    }

    public void DuplicateDocument()
    {
        if (currentDoc != null)
        {
            Document doc = new Document();
            doc.labelText = currentDoc.GetComponent<DocumentComponent>().GetText();
            doc.mediaPath = currentDoc.GetComponent<DocumentComponent>().GetMedia();
            GameObject.Find("PaletteMenu").GetComponent<PaletteManager>().AddDocument(doc);
        }
    }

    public void DeleteDocument()
    {
        if (currentDoc != null)
        {
            documentManager.DestroyDocument(currentDoc);
            currentDoc = null;
            SetText("");
        }
    }

    public void ShowDoc()
    {
        if (currentDoc != null)
        {
            currentDoc.GetComponent<DocumentComponent>().ShowMedia();
        }
    }

    public void HideDoc()
    {
        if (currentDoc != null)
        {
            currentDoc.GetComponent<DocumentComponent>().HideMedia();
        }
    }
}
