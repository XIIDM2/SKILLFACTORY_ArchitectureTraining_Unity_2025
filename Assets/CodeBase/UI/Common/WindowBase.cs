using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class WindowBase : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Button closeButton;

    public event UnityAction CleanUp;

    private void Awake()
    {
        OnAwake();
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(OnClose);
        }
    }

    private void OnDestroy()
    {
        if (closeButton != null)
        {
            closeButton.onClick.RemoveListener(OnClose);
        }

        OnCleanUp();
        CleanUp?.Invoke();
    }

    public void Close()
    {
        OnClose();
    }

    public void SetTitleText(string text)
    {
        if (titleText == null) return;

        titleText.text = text;
    }

    protected virtual void OnAwake() { }

    protected virtual void OnClose() { }

    protected virtual void OnCleanUp() { }
}
