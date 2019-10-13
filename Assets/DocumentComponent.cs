﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;

public class DocumentComponent : MonoBehaviour, IMixedRealityPointerHandler
{
    private GameObject mediaObject = null;
    private GameObject textObject = null;
    private string docLabel = "BaseImage";
    private string mediaPath = "";
    private GameObject toolMenu = null;

    void Awake()
    {
        if (mediaObject == null)
        {
            mediaObject = gameObject.transform.Find("DocumentImage").gameObject;
            textObject = gameObject.transform.Find("DocumentLabel").gameObject;
            toolMenu = GameObject.Find("ToolMenu").gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshText();
        mediaObject.GetComponent<LoadResourceTexture>().PrepareTexture(mediaPath);
    }



    public string GetText()
    {
        return docLabel;
    }

    public string GetMedia()
    {
        return mediaPath;
    }

    public void UpdateText(string docLabel)
    {
        this.docLabel = docLabel;
        RefreshText();
    }

    public void SetData(string docLabel, string mediaPath)
    {
        this.docLabel = docLabel;
        this.mediaPath = mediaPath;
    }

    public void RefreshText()
    {
        textObject.GetComponent<TextMeshPro>().text = docLabel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMedia()
    {
        mediaObject.SetActive(true);
    }

    public void HideMedia()
    {
        mediaObject.SetActive(false);
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        toolMenu.GetComponent<ToolManager>().SetDocument(gameObject);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {

    }
}
