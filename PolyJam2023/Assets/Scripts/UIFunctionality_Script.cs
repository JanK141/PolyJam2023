using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIFunctionality_Script : MonoBehaviour
{
    public GameObject menuCamera;
    public GameObject playerCamera;

    private void Awake ()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("Start").clicked += OnStartGameClick; 
            /*menuCamera.SetActive(false);
            playerCamera.SetActive(true);*/
        root.Q<Button>("Credits").clicked += () => Debug.Log("Credits buttonClicked");
        root.Q<Button>("Quit").clicked += () => Debug.Log("Quit buttonClicked");
    }
    private void OnStartGameClick()
    {
            menuCamera.SetActive(false);
            playerCamera.SetActive(true);
            gameObject.SetActive(false);
    }
}