
using UnityEngine;
using UnityEngine.UI;

public class CourseItem : MonoBehaviour
{
    public string sectionKey;  // Major, Cross, PE, Read, Gen, Sci, Art
    bool selected = false;
    Text lbl;
    CourseSectionManager mgr;
    Color defaultColor;
    Color purple = new Color(75, 0, 130);


 void Awake()
 {
     lbl = GetComponentInChildren<Text>();
     if (lbl == null)
         Debug.LogError("CourseItem: 找不到子物体上的 Text 组件！", this);

    defaultColor = lbl.color;

     mgr = FindObjectOfType<CourseSectionManager>();
     if (mgr == null)
         Debug.LogError("找不到 CourseSectionManager，请确保挂载在场景中！");

     GetComponent<Button>().onClick.AddListener(OnClick);
 }

    public void Initialize(string name, string key)
    {
        lbl.text = name;
        sectionKey = key;
    }

    void OnClick()
    {
        if (!selected)
        {
            if (mgr.CanSelect(sectionKey))
            {
                selected = true;
                lbl.color = purple;
                mgr.Register(sectionKey, this);
            }
            else
            {
                mgr.ShowWarning("选课数目已达上限");
            }
        }
        else
        {
            selected = false;
            lbl.color = defaultColor;;
            mgr.Unregister(sectionKey, this);
        }
    }
}
