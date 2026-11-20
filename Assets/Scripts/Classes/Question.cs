using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Question", fileName = "New Question")]
public class Question : ScriptableObject{
    public string question, answer;
    public Sprite sprite;
}