using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGestureReceiver : MonoBehaviour
{
    public string Name;
    public float threshold;

    public RecognitionManager recognitionManager;
    // Start is called before the first frame update
    void Start()
    {
        recognitionManager.ResultEvent+=TranslatePattern;
    }

    private void TranslatePattern(string arg1, float arg2)
    {
        // if(arg1==Name && arg2>threshold)
            gameObject.GetComponent<ComboCharacter>().SetNextState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
