using System;
using Unit;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LevelGame.UI.Barrack
{
    public class CardControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public BarrackController BarrackController { get; set; }
        public UnitType UnitType { get; set; }
        private Canvas _mainCanvas;
        private RectTransform _rectTransform;
        private Vector2 _startRectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _mainCanvas = GetComponentInParent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startRectTransform = _rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta/_mainCanvas.scaleFactor;
            if (_rectTransform.anchoredPosition.y > 13)
            {
                BarrackController.OnUnit(UnitType);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition = _startRectTransform;
        }
    }
}