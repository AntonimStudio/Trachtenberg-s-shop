using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButtonSmoothMovement : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private bool _isRight;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private List<Transform> _screens;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _wall;
    [SerializeField] private ButtonSmoothMovement BSM;
    private bool _isRightClicked;
    private bool _isLeftClicked;
    private int _numberMenu;
 

    private void Start()
    {
        _numberMenu = 0;
        _isRightClicked = false;
        _isLeftClicked = false;
        _wall.SetActive(false);
    }

    private void Update()
    {
        if (_isRightClicked && _numberMenu < _screens.Count - 1)
        {
            _wall.SetActive(true);
            _screens[_numberMenu].transform.position = Vector3.MoveTowards(_screens[_numberMenu].transform.position, _points[0].position, Time.deltaTime * _speed);

            _screens[_numberMenu + 1].transform.position = Vector3.MoveTowards(_screens[_numberMenu + 1].transform.position, _points[1].position, Time.deltaTime * _speed);
            if (_screens[_numberMenu].transform.position == _points[0].position)
            {
                _isRightClicked = false;
                _isLeftClicked = false;
                _numberMenu += 1;
                _wall.SetActive(false);
                BSM.ChangeNumberMenu(_numberMenu);
            }
        } 
        else { _isRightClicked = false; }

        if (_isLeftClicked && _numberMenu > 0)
        {
            
            _screens[_numberMenu].transform.position = Vector3.MoveTowards(_screens[_numberMenu].transform.position, _points[2].position, Time.deltaTime * _speed);
            _wall.SetActive(true);
            _screens[_numberMenu - 1].transform.position = Vector3.MoveTowards(_screens[_numberMenu - 1].transform.position, _points[1].position, Time.deltaTime * _speed);
            if (_screens[_numberMenu].transform.position == _points[2].position)
            {
                _isLeftClicked = false;
                _isRightClicked = false;
                _numberMenu -= 1;
                _wall.SetActive(false);
                BSM.ChangeNumberMenu(_numberMenu);
            }
        }
        else { _isLeftClicked = false; }

    }

    public void ChangeNumberMenu(int num)
    {
        _numberMenu = num;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (_isRight)
        {
            _isRightClicked = true;

        }
        else
        {
            _isLeftClicked = true;
        }

    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }
}
