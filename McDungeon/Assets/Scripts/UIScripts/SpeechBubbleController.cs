using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubbleController : MonoBehaviour
{
    public GameObject textObject;

    private TMP_Text textComponent;

    private float duration = 10.0f;
    private float timeElapsed = 0.0f;

    void Start()
    {   
    }

    public void Init(string text, Vector3 dimensions, Vector3 offset, float fontSize, float duration)
    {
        textComponent = textObject.GetComponent<TMP_Text>();
        this.duration = duration;
        textComponent.text = text;
        textComponent.fontSize = fontSize;
        gameObject.transform.localScale = dimensions;
        gameObject.transform.localPosition = offset;
        textObject.transform.localScale = new Vector3(1.0f / dimensions.x, 1.0f / dimensions.y, 1);
        textObject.GetComponent<RectTransform>().sizeDelta = new Vector2(dimensions.x - 0.5f, dimensions.y - 0.5f);
        textObject.transform.localScale = new Vector3(1.0f / dimensions.x, 1.0f / dimensions.y, 1);
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > duration)
        {
            Destroy(gameObject);
        }
    }
}
