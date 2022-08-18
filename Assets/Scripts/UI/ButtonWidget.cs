using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWidget : CustomUI
{
    [SerializeField]
    private TMP_Text _buttonText;
    [SerializeField]
    private Button _button;
    public bool Interactable
    {
        get => _button.interactable;
        set => _button.interactable = value;
    }

    public void SetData(string text = "", Color color = default, Action onClick = null)
    {
        _button.onClick.RemoveAllListeners();
        _button.image.color = color;

        if (onClick != null)
        {
            _button.onClick.AddListener(() => onClick.Invoke());
        }

        if (_buttonText != null)
        {
            _buttonText.text = text;
        }
    }

    public override void Uninit()
    {
        _button.onClick.RemoveAllListeners();
        base.Uninit();
    }
}