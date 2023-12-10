using System.Collections.Generic;
using UnityEngine;

public interface IRecognizer
{
    public DollarPoint[] Normalize(DollarPoint[] points, int n,
        DollarOneRecognizer.Step step = DollarOneRecognizer.Step.TRANSLATED);

    public (string, float) DoRecognition(DollarPoint[] points, int n,
        List<RecognitionManager.GestureTemplate> gestureTemplates);

    public (string, float, string, float) DoRecognitionSecond(DollarPoint[] points, int n,
        List<RecognitionManager.GestureTemplate> gestureTemplates);    
}