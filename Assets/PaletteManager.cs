using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Net;
using TMPro;


public class PaletteManager : MonoBehaviour
{
    private List<Document> paletteDocuments = new List<Document>();
    public GameObject[] paletteButtons = new GameObject[6];
    private int currentIndex = 0;
    private bool refreshing = false;

    const string NEW_DOCS_URL = "BigEyeQueue.space/palettelist.json";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshPaletteClick()
    {
        if (!refreshing)
        {
            refreshing = true;
            StartCoroutine(RefreshPalette());
        }
    }

    public IEnumerator RefreshPalette()
    {
        WWW www = new WWW(NEW_DOCS_URL);
        yield return www;
        if (www.error == null)
        {
            string jsonString = www.text;
            var jsonObject = JSON.Parse(jsonString);
            for (int i = 0; i < jsonObject.Count; i++)
            {
                var item = jsonObject[i];
                Document document = new Document();
                document.labelText = item["name"];
                document.mediaPath = DownloadImage(item["url"]);
                paletteDocuments.Add(document);
            }
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
        RenderPalette();
        refreshing = false;
    }

    string DownloadImage(string url)
    {
        string filePath =  "%USERPROFILE%\\Pictures\\"+ System.Guid.NewGuid() + ".png";
        filePath = System.Environment.ExpandEnvironmentVariables(filePath);
        Debug.Log(filePath);
        using (WebClient webClient = new WebClient())
        {
            webClient.DownloadFile(url, filePath);
        }
        return filePath;
    }

    

    void RenderPalette()
    {
        int i = 0;
        for (; i < 6; i++)
        {
            int docIndex = i + (2 * currentIndex);
            if (docIndex >= paletteDocuments.Capacity)
            {
                break;
            }
            Document doc = paletteDocuments[docIndex];
            paletteButtons[i].SetActive(true);
            paletteButtons[i].transform.Find("IconAndText").Find("TextMeshPro").gameObject.GetComponent<TextMeshPro>().text = doc.labelText;
            paletteButtons[i].GetComponent<DocumentSpawnButton>().mediaPath = doc.mediaPath;
            paletteButtons[i].GetComponent<DocumentSpawnButton>().docLabel = doc.labelText;

        }
        for (; i < 6; i++)
        {
            paletteButtons[i].SetActive(false);
        }
    }

    public void ScrollUp()
    {
        currentIndex++;
        if (currentIndex > MaxIndex())
        {
            currentIndex = MaxIndex();
        }
    }
    public void ScrollDown()
    {
        if (currentIndex-- == 0)
        {
            currentIndex = 0;
        }
    }

    int MaxIndex()
    {
        return System.Math.Max((paletteDocuments.Capacity - 6) / 2, 0);
    }

    public void AddDocument(Document doc)
    {
        paletteDocuments.Add(doc);
        RenderPalette();
    }
}
public struct Document
{
    public string labelText;
    public string mediaPath;
}
