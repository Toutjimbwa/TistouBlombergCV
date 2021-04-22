using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Topic : MonoBehaviour
{
    void turnOn()
    {
        //Show title
        //activate open-button
    }
    void turnOff()
    {
        //hide title
        //deactivate open-button
    }
    void open()
    {
        //turn off
        //turn on subtopics+description
        //activate cam
        //create back button
    }
    void close()
    {
        //turn off subtopics+description
        //deactivate cam
        //turn on
    }
    void createBackButton()
    {

    }

    public GameObject Title;
    public CinemachineVirtualCameraBase CM;
    public List<Topic> Subtopics;
    public Topic ParentTopic;
}
