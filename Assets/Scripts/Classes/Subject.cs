// this is the data structure of the quizzes and activities of the subject
public class Subject {
    public string id;
    public string classId, name;
    public int progress;
    
    public Subject (string id, string n) {
        classId = id;
        name = n;
        progress = 0;
    }
}