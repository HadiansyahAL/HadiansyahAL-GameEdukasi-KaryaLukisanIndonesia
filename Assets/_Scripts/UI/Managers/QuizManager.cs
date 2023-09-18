using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Animator animator;

    public GameObject quizPanel;
    public GameObject scorePanel;
    public GameObject selesai;
    public GameObject cobalagi;
    public GameObject RewardKey;


    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    int score;

    private void Start()
    {
        quizPanel.SetActive(false);
        totalQuestions = QnA.Count;
        scorePanel.SetActive(false);
        generateQuestion();
    }

    public void Correct()
    {
        score += 20;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void Wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void Selesai()
    {
        selesai.SetActive(false);
        scorePanel.SetActive(false);
        RewardKey.SetActive(true);
        

    }

    public void CobaLagi()
    {
        cobalagi.SetActive(false);
        scorePanel.SetActive(false);
        RewardKey.SetActive(false);
    }


    void GameOver()
    {
        quizPanel.SetActive(false);
        scorePanel.SetActive(true);
        ScoreTxt.text = score + " / "+ totalQuestions;

        if (score == 100)
        {
            selesai.SetActive(true);
        }
        else
        {
            cobalagi.SetActive(true);
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
        
            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            GameOver();
        }
        
    }
}
