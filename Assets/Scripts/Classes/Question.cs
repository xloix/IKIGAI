using UnityEngine;

public class Question {
    public string id;
    public string activityId;
    public string question, answer;
    public Sprite sprite;

    public Question (string id, string q, string a) {
        activityId = id;
        question = q;
        answer = a;
        sprite = null;
    }
    public Question (string id, string q, string a, Sprite spr) {
        activityId = id;
        question = q;
        answer = a;
        sprite = spr;
    }
}