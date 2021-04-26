﻿using System.Collections;
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
        CreateOpenButton();
    }
    void TurnOff()
    {
        Destroy(OpenButton);
    }
    void CreateOpenButton()
    {
        OpenButton = Instantiate(OpenButtonPrefab, Canvas.transform);
        OpenButton.GetComponent<OpenButton>().SetTarget(transform);
        OpenButton.GetComponent<Button>().onClick.AddListener(
            () => OnClickOpenButton(OpenButton)
            );
        OpenButton.GetComponentInChildren<Text>().text = name;
    }
    void OnClickOpenButton(GameObject openButton)
    {
        Open();
        Destroy(openButton);
    }
    void CreateBackButton()
    {
        GameObject backButton = Instantiate(BackButtonPrefab, Canvas.transform);
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
        Canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        ParentTopic = transform.parent.GetComponent<Topic>();
        if (ParentTopic == null)
        {
            TurnOn();
        }
        foreach (Transform child in transform)
        {
            var topic = child.GetComponent<Topic>();
            if(topic != null)
            {
                Subtopics.Add(topic);
            }
        }
    }

    
    public GameObject BackButtonPrefab;
    public GameObject OpenButtonPrefab;
    public CinemachineVirtualCameraBase CM;
    public GameObject Description;
    public Topic ParentTopic;
    public List<Topic> Subtopics;

    GameObject OpenButton;
    GameObject Canvas;

}
