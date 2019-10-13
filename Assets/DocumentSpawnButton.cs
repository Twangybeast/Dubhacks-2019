using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentSpawnButton : MonoBehaviour
{
    DocumentSpawner documentSpawner;
    public string mediaPath = null;
    public string docLabel = null;

    // Start is called before the first frame update
    void Start()
    {
        documentSpawner = GameObject.Find("PaletteMenu").GetComponent<DocumentSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        documentSpawner.SpawnDocument(mediaPath, docLabel);
    }
}
