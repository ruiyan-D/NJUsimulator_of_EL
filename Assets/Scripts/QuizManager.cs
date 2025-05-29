using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public static class QuizResultData
{
    public static int score;
    public static List<Question> questions;
    public static int[] userAnswers;
}

public class QuizManager : MonoBehaviour
{
    [Header("UI 引用")]
    public TextMeshProUGUI questionText;
    public Button[] optionButtons;
    public TextMeshProUGUI[] optionButtonTexts;
    public Button nextButton;
    public Button prevButton;

    private int lastSelectedIndex = -1;

    private List<Question> questions;
    private int current = 0, score = 0;
    private int[] userAnswers;

    void Start()
    {
        // ① 构造题库（替换为你自己的题目）
        questions = new List<Question>
        {
            new Question("关于学业预警，以下哪种情况会进入三级预警：\n 1.完成总学分 小于等于 累计学期数*14；\n2.完成必修课程学分数 小于等于 累计学期数*专业教学计划规定的必修学分/10；\n3.学期内未通过的必修课程学分 大于等于 10学分；\n4.有必修课重修2次后仍未通过。"
                        , new[]{"A.1234","B.134","C.234","D.123"}, 0),
            new Question("学生每学期申请“免修不免考”的课程原则上不超过_____门。不得申请“免修不免考”的课程有_____。\n1.思政类课程；2.军事课程；3.体育课程；4.实践类课程（含实习）。"
                        ,new[]{"A、一，1234","B、一，234","C、两，234","D、两，1234"},3),
            new Question("各学科大类完成学科分流时间原则上在_____结束时，专业准入完成时间分别在_____结束时。"
                        ,new[]{"A、第二学期，第二、三学期","B、第二、三学期，第三、四学期","C、第二学期，第二、三、四学期","D、第二、三学期，第二、三、四学期"},2),
            new Question("下列情况中，不属于严重违反考试纪律、应给予严重警告处分的情形有："
                        ,new[]{"A、在发放试卷时领取超过一份试卷、答卷（含答题纸、答题卡）且未将多余试卷返还监考教师者","B、传递和接收纸条、答卷时，被及时发现制止而未实现者","C、企图为他人偷看提供方便或企图偷看他人试卷、答卷，被及时制止而未实现者","D、考试期间交头接耳初犯者"},0),
            new Question("关于补考说法正确的有：1.学生首次修读课程考核不合格，可以申请一次补考\n2.凡无故未参加课程考核或考核中有违纪行为者，原则上不予补考\n3.因缺课或缺交作业严重，课程成绩以零分记载的，不予补考\n4.补考通过的按照按60分记载在成绩单"
                        ,new[]{"A、123","B、1234","C、124","D、134"},1),
            new Question("学生选课不当，可在规定时间内退选课程。在课程开课_____内退选的，该课程不记载在成绩单；在课程开课_____内退选的，该课程记载在成绩单，无成绩，注明“退选”字样；课程开课_____不得退选"
                        ,new[]{"A、一周，二到八周，八周后","B、二周，三到六周，六周后","C、一周，二到六周，六周后","D、二周，三到八周，八周后"},3),
            new Question("在设置专业意向的情况下，如果跨专业（大类）课程和自己的必修课有冲突，可_____缓修。如果是其他原因（课业偏重、实习等）需要缓修某门必修课的，可_____缓修，经所在院系审核同意后备案并删除课程。"
                        ,new[]{"A、提交书面申请，在教务系统里自行申请","B、提交书面申请，提交书面申请","C、在教务系统里自行申请，在教务系统里自行申请","D、在教务系统里自行申请，提交书面申请"},3),
            new Question("学生如果在学习主修专业课程的同时，对其他某个专业课程感兴趣，则需设置该专业为“______”，专业意向用于计算跨专业选课的优先级，设置时间一般为新生入学后______。"
                        ,new[]{"A、跨专业选课专业意向，第二周","B、辅修意向，第二周","C、辅修意向，第一周","D、跨专业选课专业意向，第一周"},3),
            new Question("学生应在需重修课程开课的学期______内在“教服平台”提交相应课程重修申请，由院系教务员审核。学生重修申请审批通过后，须在重修申请学期开学______规定的时间内缴纳重修课程学分学费，逾期未缴费的，视为放弃重修。"
                        ,new[]{"A、第一周，第二周","B、第二周，第四周","C、第一周，第三周","D、第二周，第三周"},2),
            new Question("学生未申请缓考或申请未获准，未按时参加课程期末考试者，视为_____，课程成绩以_____记录。"
                        ,new[]{"A、旷考，零分","B、旷考，无效","C、缓考，无效","D、缓考，零分"},0)
            // … 请补全至 10 题
        };

        userAnswers = new int[questions.Count];
        for(int i=0;i<userAnswers.Length;i++) userAnswers[i] = -1;

        // ② 绑定选项回调
        for(int i=0;i<4;i++)
        {
            int idx=i;
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(idx));
        }
        nextButton.onClick.AddListener(OnNext);
        prevButton.onClick.AddListener(OnPrevious);
        // 确保一开始没有选中任何选项
        lastSelectedIndex = -1;

        ShowQuestion();
    }

    void ShowQuestion()
    {
        prevButton.gameObject.SetActive(current > 0);
        if(current>=questions.Count)
        {
            SceneManager.LoadScene("QuizConfirmScene");
            return;
        }
        var q=questions[current];
        questionText.text = $"Q{current+1}. {q.questionText}";
        for(int i=0;i<4;i++)
        {
            optionButtonTexts[i].text = q.options[i];
            optionButtons[i].interactable = true;
            optionButtonTexts[i].color = Color.black;

            if (userAnswers[current] == i)
                {
                    bool ok = (i == q.correctIndex);
                    optionButtonTexts[i].color = ok ? Color.green : Color.red;
                    // 并且：让选项和下一题按钮可用
                    foreach (var b in optionButtons) b.interactable = false;
                    nextButton.interactable = true;

                }
        }
        if (userAnswers[current] < 0)
            nextButton.interactable = false;

        lastSelectedIndex = -1;
        nextButton.interactable = (userAnswers[current] >= 0);
    }

    void OnOptionSelected(int idx)
    {
        // 1) 如果上一次有高亮，就先还原它
                if (lastSelectedIndex >= 0)
                {
                    optionButtonTexts[lastSelectedIndex].color = Color.black;
                }

                // 2) 记录新的选择
                userAnswers[current] = idx;
                lastSelectedIndex = idx;

                // 3) 给这个按钮着色
                bool correct = idx == questions[current].correctIndex;
                optionButtonTexts[idx].color = Color.blue;

                // 4) 允许点击“下一题”
                nextButton.interactable = true;
    }

    void OnNext()
    {
        if(userAnswers[current]==questions[current].correctIndex) score++;

        if (current == questions.Count-1||current == questions.Count)
            {
                // 保存数据
                QuizResultData.score = score;
                QuizResultData.questions = questions;
                QuizResultData.userAnswers = userAnswers;
            }

        nextButton.interactable = false;
        prevButton.interactable = false;
        foreach (var b in optionButtons) b.interactable = false;

        StartCoroutine(DelayedNext());

    }

    void OnPrevious()
        {
            // 如果当前题目还没有来得及累分，则不做分数调整
            // 如果想精确管理 score，建议把累分逻辑放到提交时统一计算
            current--;
            ShowQuestion();
        }

    public int GetScore() => score;
    public List<Question> GetQuestions() => questions;
    public int[] GetUserAnswers() => userAnswers;


    private IEnumerator DelayedNext()
    {
        // ① 这里可以再做一次按钮颜色反馈，比如把正确答案高亮为绿色
        int correct = questions[current].correctIndex;
        int chosen = userAnswers[current];

        for (int i = 0; i < optionButtons.Length; i++)
            {
                if (i == correct)
                {
                    optionButtonTexts[i].color = Color.green;
                }
                else if (i == chosen)
                {
                    // 如果用户选的不是正确答案，则标红
                    optionButtonTexts[i].color = Color.red;
                }
                else
                {
                    // 其余保持默认或灰色
                    optionButtonTexts[i].color = Color.black;
                }
            }
        // ② 等待 1 秒
        yield return new WaitForSeconds(1f);

        // ③ 切换到下一题
        current++;
        ShowQuestion();

        // ④ 切题后，恢复按钮可交互
        prevButton.interactable = true;

    }

}


