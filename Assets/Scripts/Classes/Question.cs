using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Question", fileName = "New Question")]
public class Question : ScriptableObject {
    public string question, answer;
    public Sprite sprite;
    
    public Question (string q, string a, Sprite spr) {
        this.question = q;
        this.answer = a;
        this.sprite = spr;
    }
    public Question (string q, string a)
    {
        this.question = q;
        this.answer = a;
        this.sprite = null;
    }
}