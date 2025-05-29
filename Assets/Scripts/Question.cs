// Assets/Scripts/Question.cs
public class Question
{
    public string questionText;
    public string[] options;    // 长度固定为 4
    public int correctIndex;    // 0–3

    public Question(string q, string[] opts, int ans)
    {
        questionText = q;
        options = opts;
        correctIndex = ans;
    }
}
