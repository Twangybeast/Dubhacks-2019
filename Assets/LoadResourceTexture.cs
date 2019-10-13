using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadResourceTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PrepareTexture(string imagePath)
    {
        StartCoroutine(LoadTexture(imagePath));
    }

    IEnumerator LoadTexture(string imagePath)
    {
        Texture2D texture = new Texture2D(4, 4, TextureFormat.DXT1, false); ;
        if (imagePath == null || imagePath == "")
        {
            imagePath = System.Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Pictures\\" + "BaseImage.png"); 
        }
        using (WWW www = new WWW(imagePath))
        {
            yield return www;
            www.LoadImageIntoTexture(texture);
        }
        gameObject.GetComponent<RawImage>().texture = texture;
        float ratio = (float)texture.width / texture.height;
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(ratio, 1.0f);
        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, (float)((ratio - 0.5) * -35 - 2)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
