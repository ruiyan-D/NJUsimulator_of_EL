using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CourseSectionManager : MonoBehaviour
{
    public GameObject warningPopup;
    public TextMeshProUGUI warningText;
    public Button submitButton;

    Dictionary<string, HashSet<CourseItem>> sel = new();

    public int majorLimit = 6, crossLimit = 3, peLimit = 2, readLimit = 2;
    public int genLimit = 3, sciLimit = 2, artLimit = 1;

    void Awake()
    {
        sel["Major"] = new();
        sel["Cross"] = new();
        sel["PE"] = new();
        sel["Read"] = new();
        sel["Gen"] = new();
        sel["Sci"] = new();
        sel["Art"] = new();
    }

    public bool CanSelect(string key)
        => sel[key].Count < GetLimit(key);

    public void Register(string key, CourseItem it)
        => sel[key].Add(it);

    public void Unregister(string key, CourseItem it)
        => sel[key].Remove(it);

    public void ShowWarning(string msg)
    {
        warningText.text = msg;
        warningPopup.SetActive(true);
    }

     public void HideWarning()
        {
            warningPopup.SetActive(false);
        }

    int GetLimit(string key) => key switch {
        "Major"=>majorLimit, "Cross"=>crossLimit, "PE"=>peLimit, "Read"=>readLimit,
        "Gen"=>genLimit, "Sci"=>sciLimit, "Art"=>artLimit, _=>0
    };

    void Start()
        {
            submitButton.onClick.AddListener(OnSubmit);
        }

    void OnSubmit()
        {
            // 切换到抽签等待界面
            SceneManager.LoadScene("DrawResultScene");
        }


}
