using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IdentificationGame : MonoBehaviour {
    [SerializeField] private List<Question> questions = new List<Question>();
    [SerializeField] Question curAnswer;
    int questionInd;
    [SerializeField] GameObject AnswerItem;
    [SerializeField] GameObject correctAnswer, wrongAnswer;
    [SerializeField] Text questionText;
    public static bool canAnswer {get; private set;}
    

    void Start() {
        InitializeGame();
    }

    void OnEnable() {
        EventBus.Subscribe<InputAnswerEvent>(AttemptAnswer);
    }

    void OnDisable() {
        EventBus.Unsubscribe<InputAnswerEvent>(AttemptAnswer);
        
    }

    void InitializeGame() {
        //get dictionary database, convert to data
        questionInd = 0;
        // get right answer, place within the area
        // get random answer that's not the right answer and not repeating
        LoadQuestion(GetRandomQuestion());
    }

    void LoadQuestion (Question q) {
        foreach (Transform c in transform) {
            Destroy(c.gameObject);
        }
        correctAnswer.SetActive(false);
        wrongAnswer.SetActive(false);
        curAnswer = q;

        int place = UnityEngine.Random.Range(0, 5);
        for(int i = 0; i < 5; i++) {
            if (i == place) {
                ClickAnswer ca = Instantiate(AnswerItem, this.transform).GetComponent<ClickAnswer>();
                // resize the object based on sprite textures
                ca.answer = q.answer;
                questionText.text = q.question;
                if (curAnswer.sprite != null) ca.GetComponent<Image>().sprite = curAnswer.sprite;
            } else {
                ClickAnswer tempCA = Instantiate(AnswerItem, this.transform).GetComponent<ClickAnswer>();
                Question tempQ = GetRandomQuestion();
                while (tempQ != null && tempQ.answer == curAnswer.answer)
                    tempQ = GetRandomQuestion();
                // resize the object based on sprite textures
                Debug.Log("#" + i + ": " + tempQ.answer);
                tempCA.answer = tempQ.answer;
                if (tempQ.sprite != null) tempCA.GetComponent<Image>().sprite = tempQ.sprite;
            }
        }
        canAnswer = true;
    }

    void AttemptAnswer (InputAnswerEvent iae) {
        canAnswer = false;

        //check if iae is the correct answer of this round
        if (iae.answer != curAnswer.answer) {
            Debug.Log("blehhh wrong answer");
            correctAnswer.SetActive(false);
            wrongAnswer.SetActive(true);
            Invoke("HideUI", 2f);
            return;
        } else {
            ++questionInd;
            Debug.Log("yippieee right answer!!@!");
            if (questionInd < 5) StartCoroutine(StartLoadQuestion());
            correctAnswer.SetActive(true);
            wrongAnswer.SetActive(false);
        }

        if (questionInd >= 5) {
            // congrats! results. back to home
            StartCoroutine(BackToHome());
        }
        
    }

    void HideUI() {
        correctAnswer.SetActive(false);
        wrongAnswer.SetActive(false);
        canAnswer = true;
    }

    IEnumerator StartLoadQuestion() {
        yield return new WaitForSeconds(2f);
        LoadQuestion(GetRandomQuestion());
    }

    IEnumerator BackToHome() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }

    public Question GetRandomQuestion() {
        int ansInd = UnityEngine.Random.Range(0, questions.Count);
        if (ansInd < 0 || ansInd >= questions.Count) return null;
        Debug.Log(ansInd + " of " + questions.Count + " questions");
        return questions[ansInd];
    }
}
