using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour
{
    private ScrollRect _scrollRect;
    [SerializeField] private ScrollButton leftButton;
    [SerializeField] private ScrollButton rightButton;
    [SerializeField] private float scrollSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftButton.isDown)
        {
            ScrollLeft();
        }

        if (rightButton.isDown)
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        if(_scrollRect.horizontalNormalizedPosition >= 0f)
        {
            _scrollRect.horizontalNormalizedPosition -= scrollSpeed;
        }
    }

    private void ScrollRight()
    {
        if (_scrollRect.horizontalNormalizedPosition <= 1f)
        {
            _scrollRect.horizontalNormalizedPosition += scrollSpeed;
        }
    }
}
