using UnityEngine;
public class Lesson {
    public string id;
    public string subjectId;
    public string topic, lesson;
    public Sprite image;

    public Lesson (string id, string t, string l) {
        subjectId = id;
        topic = t;
        lesson = l;
        image = null;
    }
    public Lesson (string id, string t, string l, Sprite spr) {
        subjectId = id;
        topic = t;
        lesson = l;
        image = spr;
    }
}