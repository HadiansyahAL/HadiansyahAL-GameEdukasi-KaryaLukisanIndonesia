using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionAnswer
{
    [TextArea(3, 10)]
    public string Question;
    
    public string[] Answers;

    public int CorrectAnswer;
}
