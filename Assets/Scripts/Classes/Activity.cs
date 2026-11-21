public class Activity {
    public string id;
    public string name, subjectId;
    public int rounds;

    public Activity (string id, string n, int r) {
        subjectId = id;
        name = n;
        rounds = r;
    }
}