using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenButton : MonoBehaviour
{
    public void SetTarget(Transform target)
    {
        TargetTransform = target;
        Show();
    }

    void Show()
    {
        GetComponent<Image>().enabled = true;
        GetComponent<Button>().enabled = true;
    }
    void Hide()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
    }
    void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(TargetTransform.position);
        rectTransform.position = screenPoint;
    }
    private void Awake()
    {
        Hide();
        rectTransform = GetComponent<RectTransform>();
    }

    Transform TargetTransform;
    RectTransform rectTransform;
}
