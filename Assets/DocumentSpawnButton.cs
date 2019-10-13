using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentSpawnButton : MonoBehaviour
{
    DocumentSpawner documentSpawner;
    PaletteManager paletteManager;
    public string mediaPath = null;
    public string docLabel = null;
    public int docPaletteIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        documentSpawner = GameObject.Find("PaletteMenu").GetComponent<DocumentSpawner>();
        paletteManager = GameObject.Find("PaletteMenu").GetComponent<PaletteManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        if (docPaletteIndex != -1)
        {
            int i = docPaletteIndex;
            documentSpawner.SpawnDocument(mediaPath, docLabel);
            paletteManager.DeleteDocument(i);

        }
    }
}
