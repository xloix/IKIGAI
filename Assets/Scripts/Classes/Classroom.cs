public class Classroom {
    public string className;
    public int langProgress, mathProgress, sciProgress, valProgress, pehProgress;
    public string userId;
    public Classroom(string cn, string un) {
        className = cn;
        userId = un;
        langProgress = 0;
        mathProgress = 0;
        sciProgress = 0;
        valProgress = 0;
        pehProgress = 0;
    }
}