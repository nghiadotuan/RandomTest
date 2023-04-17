using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ValueView : MonoBehaviour, IComparable<ValueView>
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _textValue;
    
    public int value { get; set; }

    public void SetFillAmount(int maxValueFillAmount)
    {
        var fill = (float)(value) / maxValueFillAmount;
        _image.fillAmount = fill;
        _textValue.SetText(value.ToString());
    }

    public int CompareTo(ValueView other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return value.CompareTo(other.value);
    }
}