using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Topic : MonoBehaviour
{
    public void Open()
    {
        TurnOff();
        TurnOnSubtopics();
        TurnOnDescription();
        CM.gameObject.SetActive(true);
        CreateBackButton();
    }

    void Close()
    {
        TurnOffSubtopics();
        TurnOffDescription();
        CM.gameObject.SetActive(false);
        TurnOn();
    }
    void TurnOnSubtopics()
    {
        foreach (Topic topic in Subtopics)
        {
            topic.gameObject.SetActive(true);
        }
    }
    void TurnOffSubtopics()
    {
        foreach (Topic topic in Subtopics)
        {
            topic.gameObject.SetActive(false);
        }
    }
    void TurnOnDescription()
    {
        Description.gameObject.SetActive(true);
    }
    void TurnOffDescription()
    {
        Description.gameObject.SetActive(false);
    }
    void TurnOn()
    {
        OpenButton.gameObject.SetActive(true);
    }
    void TurnOff()
    {
        OpenButton.gameObject.SetActive(false);
    }
    void CreateBackButton()
    {
        GameObject backButton = Instantiate(BackButtonPrefab, RootCanvas.transform);
        backButton.GetComponent<Button>().onClick.AddListener(
            () => OnClickBackButton(backButton)
            );
    }
    void OnClickBackButton(GameObject backButton)
    {
        Close();
        Destroy(backButton);
    }
    private void Awake()
    {
        ParentTopic = GetComponentInParent<Topic>();
        foreach (Transform child in transform)
        {
            var topic = child.GetComponent<Topic>();
            if(topic != null)
            {
                Subtopics.Add(topic);
            }
        }
    }

    public Button OpenButton;
    public GameObject BackButtonPrefab;
    public CinemachineVirtualCameraBase CM;
    public GameObject Description;
    public GameObject RootCanvas;
    public Topic ParentTopic;
    public List<Topic> Subtopics;
    
}
