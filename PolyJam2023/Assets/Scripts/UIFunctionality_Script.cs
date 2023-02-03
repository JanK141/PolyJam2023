using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIFunctionality_Script : MonoBehaviour
{
    private void Awake ()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("Start").clicked += () => Debug.Log("Start buttonClicked");
        root.Q<Button>("Credits").clicked += () => Debug.Log("Credits buttonClicked");
        root.Q<Button>("Quit").clicked += () => Debug.Log("Quit buttonClicked");
    }
}
