using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolManager : MonoBehaviour
{
    public GameObject currentDoc = null;
    public GameObject docLabel;
    private TouchScreenKeyboard keyboard = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard != null && currentDoc != null)
        {
            SetText(keyboard.text);
            currentDoc.GetComponent<DocumentComponent>().docLabel = keyboard.text;
            currentDoc.GetComponent<DocumentComponent>().RefreshText();
        }
    }

    public void SetDocument(GameObject doc)
    {
        currentDoc = doc;
        SetText(doc.GetComponent<DocumentComponent>().docLabel);
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
            doc.labelText = currentDoc.GetComponent<DocumentComponent>().docLabel;
            doc.mediaPath = currentDoc.GetComponent<DocumentComponent>().mediaPath;
            GameObject.Find("PaletteMenu").GetComponent<PaletteManager>().AddDocument(doc);
        }
    }

    public void DeleteDocument()
    {
        if (currentDoc != null)
        {
            Destroy(currentDoc);
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
