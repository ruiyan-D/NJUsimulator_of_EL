using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmPanel : MonoBehaviour
{
    public void OnConfirmSubmit()
    {
        SceneManager.LoadScene("QuizResultScene");
    }

//     public void OnBackToLastQuestion()
//     {
//         SceneManager.LoadScene("QuizScene");
//     }

    public void OnReturnToMainCampus()
    {
        SceneManager.LoadScene("MainCampus");
    }
}
