using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTest : MonoBehaviour
{
    [SerializeField] private Transform _contentRandomSystem;
    [SerializeField] private Transform _contentRandomUnity;
    [SerializeField] private GameObject _prefabValueView;
    [SerializeField] private int _quantityValueView;
    [SerializeField] private float _space;
    [SerializeField] private int _numberRandom;
    
    private System.Random _random;
    private List<ValueView> _listViewRandomSystem;
    private List<ValueView> _listViewRandomUnity;

    private void Awake()
    {
        _random = new System.Random();
    }

    private void Start()
    {
        _listViewRandomSystem = CreateValueViews(_contentRandomSystem);
        _listViewRandomUnity = CreateValueViews(_contentRandomUnity);
    }

    private List<ValueView> CreateValueViews(Transform parent)
    {
        var layoutGroup = parent.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.spacing = _space;
        var result = new List<ValueView>();
        for (var i = 0; i != _quantityValueView; i++)
        {
            result.Add(Instantiate(_prefabValueView, parent).GetComponent<ValueView>());
        }

        return result;
    }
    
    private int GetValueRandomSystem()
    {
        for (var i = 0; i <= _numberRandom; i++)
        {
            var rand = _random.Next(0, _quantityValueView);
            _listViewRandomSystem[rand].value++;
        }

        var list = new List<int>();
        for (var i = 0; i != _listViewRandomSystem.Count; i++)
        {
            list.Add(_listViewRandomSystem[i].value);
        }
        
        list.Sort();
        return list[^1];
    }
    
    private int GetValueRandomUnity()
    {
        for (var i = 0; i <= _numberRandom; i++)
        {
            var rand = Random.Range(0, _quantityValueView);
            _listViewRandomUnity[rand].value++;
        }
        
        var list = new List<int>();
        for (var i = 0; i != _listViewRandomUnity.Count; i++)
        {
            list.Add(_listViewRandomUnity[i].value);
        }
        
        list.Sort();
        return list[^1];
    }

    private void ClearValue()
    {
        foreach (var view in _listViewRandomSystem)
        {
            view.value = 0;
        }
        
        foreach (var view in _listViewRandomUnity)
        {
            view.value = 0;
        }
    }
    
    public void OnClickBtnViewResult()
    {
        ClearValue();
        var maxValueSystem = GetValueRandomSystem();
        foreach (var valueView in _listViewRandomSystem)
        {
            valueView.SetFillAmount(maxValueSystem);
        }
        
        var maxValueUnity = GetValueRandomUnity();
        
        foreach (var valueView in _listViewRandomUnity)
        {
            valueView.SetFillAmount(maxValueUnity);
        }
    }

    public void SortViewSystem()
    {
        _listViewRandomSystem.Sort();
        var index = 0;
        foreach (var view in _listViewRandomSystem)
        {
            view.transform.SetSiblingIndex(index);
            index++;
        }
    }
    
    public void SortViewUnity()
    {
        _listViewRandomUnity.Sort();
        var index = 0;
        foreach (var view in _listViewRandomUnity)
        {
            view.transform.SetSiblingIndex(index);
            index++;
        }
    }
}