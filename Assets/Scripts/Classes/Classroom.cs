// this is the data structure of the classroom that a user holds
public class Classroom {
    public string id;
    public string userId;
    public string className;
    public Classroom(string id, string n) {
        userId = id;
        className = n;
    }
}