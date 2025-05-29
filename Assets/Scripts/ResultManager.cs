using UnityEngine;
using System.Text;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI detailText;

//     void Start()
//     {
//         var qm = FindObjectOfType<QuizManager>();
//         int score = qm.GetScore();
//         var qs = qm.GetQuestions();
//         var ua = qm.GetUserAnswers();
//
//         scoreText.text = $"得分：{score}/{qs.Count}";
//
//         var sb = new StringBuilder();
//         for(int i=0;i<qs.Count;i++)
//         {
//             bool ok = ua[i]==qs[i].correctIndex;
//             sb.AppendLine($"Q{i+1}. {qs[i].questionText}");
//             sb.AppendLine($"  你的答案：{(ua[i]>=0?qs[i].options[ua[i]]:"未选")} [{(ok?"✔":"✖")}]");
//             sb.AppendLine($"  正确答案：{qs[i].options[qs[i].correctIndex]}");
//             sb.AppendLine();
//         }
//         detailText.text = sb.ToString();
//     }
    void Start()
    {

        int score = QuizResultData.score;
        var qs    = QuizResultData.questions;
        var ua    = QuizResultData.userAnswers;

        // 如果静态数据没被正确赋值，提前报错
        if (qs == null || ua == null)
        {
            Debug.LogError("ResultManager: QuizResultData 内没有数据！");
            return;
        }

        // 显示分数
        scoreText.text = $"得分：{score}/{qs.Count}";


        var sb = new StringBuilder();
        for (int i = 0; i < qs.Count; i++)
        {
            bool ok = ua[i] == qs[i].correctIndex;
            sb.AppendLine($"Q{i + 1}. {qs[i].questionText}");
            sb.AppendLine($"  你的答案：{(ua[i] >= 0 ? qs[i].options[ua[i]] : "未选")} [{(ok ? "正确" : "错误")}]");
            sb.AppendLine($"  正确答案：{qs[i].options[qs[i].correctIndex]}");
            sb.AppendLine();
        }

        detailText.text = sb.ToString();
    }
}
