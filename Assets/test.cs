using System.Diagnostics;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform targetTransform;
    public Transform parent1;
    public Transform parent2;

    private void Start()
    {
        var sw = new Stopwatch();
        TestTransformSetParentCost(1, sw, "[Transform.SetParent]");
        TestTransformSetParentCost(10, sw, "[Transform.SetParent]");
        TestTransformSetParentCost(100, sw, "[Transform.SetParent]");
        TestTransformSetParentCost(1000, sw, "[Transform.SetParent]");
        
        TestTransformSetParentCost(1, sw, "[RectTransform.SetParent]");
        TestTransformSetParentCost(10, sw, "[RectTransform.SetParent]");
        TestTransformSetParentCost(100, sw, "[RectTransform.SetParent]");
        TestTransformSetParentCost(1000, sw, "[RectTransform.SetParent]");
        
        TestTransformSetParentCost(1, sw, "[Transform.Parent]", true);
        TestTransformSetParentCost(10, sw, "[Transform.Parent]", true);
        TestTransformSetParentCost(100, sw, "[Transform.Parent]", true);
        TestTransformSetParentCost(1000, sw, "[Transform.Parent]", true);

        // TestGameObjectSetActive(1, sw, "[GameObject.Setactive]");
        // TestGameObjectSetActive(10, sw, "[GameObject.Setactive]");
        // TestGameObjectSetActive(100, sw, "[GameObject.Setactive]");
        // TestGameObjectSetActive(1000, sw, "[GameObject.Setactive]");
    }

    private void TestTransformSetParentCost(int exeTimes, Stopwatch sw, string exStr, bool isField = false)
    {
        sw.Reset();
        sw.Start();
        for (int i = 0; i < exeTimes; i++)
        {
            targetTransform.SetParent(parent1);
            targetTransform.SetParent(parent2);
            if (isField)
            {
                targetTransform.parent = parent1;
                targetTransform.parent = parent2;
            }
        }

        sw.Stop();
        UnityEngine.Debug.LogFormat($"{exStr} times={exeTimes}    cost={sw.ElapsedMilliseconds}ms");
    }

    private void TestGameObjectSetActive(int exeTimes, Stopwatch sw, string exStr)
    {
        sw.Reset();
        sw.Start();
        for (int i = 0; i < exeTimes; i++)
        {
            targetTransform.gameObject.SetActive(false);
            targetTransform.gameObject.SetActive(true);
        }

        sw.Stop();
        UnityEngine.Debug.LogFormat($"{exStr} times={exeTimes}    cost={sw.ElapsedMilliseconds}ms");
    }
}