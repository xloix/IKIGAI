using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Question", fileName = "New Question")]
public class Questions : ScriptableObject {
    public string question, answer;
    public Sprite sprite;
    
    public Questions (string q, string a, Sprite spr) {
        this.question = q;
        this.answer = a;
        this.sprite = spr;
    }
    public Questions (string q, string a)
    {
        this.question = q;
        this.answer = a;
        this.sprite = null;
    }
}

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