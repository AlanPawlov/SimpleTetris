using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LabelWidget : CustomUI
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Image _backGroundImage;
    public TMP_Text Text => _text;

    public void SetData(string text, Color textColor = default, Color backGroundColor = default)
    {
        _text.text = text;
        if (textColor != default)
        {
            _text.color = textColor;
        }

        if (backGroundColor != default && _backGroundImage != null)
        {
            _backGroundImage.color = backGroundColor;
        }
    }
}
