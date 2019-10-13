using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DocumentSpawner : MonoBehaviour
{
    public GameObject documentPrototype;
    public Vector3 defaultDocumentLocation;
    public Quaternion defaultDocumentOrientation = Quaternion.identity;
    private GameObject documentRoot = null;

    void Awake()
    {
        if (documentRoot == null)
            documentRoot = GameObject.Find("Documents");
    }

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDocument(string mediaPath = null, string docLabel = null)
    {
        if (docLabel == null)
        {
            docLabel = "New Document";
        }
        GameObject documentObject = Instantiate(documentPrototype, defaultDocumentLocation, defaultDocumentOrientation, documentRoot.transform);
        DocumentComponent document = documentObject.GetComponent<DocumentComponent>();
        document.docLabel = docLabel;
        document.mediaPath = mediaPath;
    }
}
