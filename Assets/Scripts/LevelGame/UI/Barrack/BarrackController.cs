using System.Collections.Generic;
using ForUnit;
using ForUnit.OnUnit;
using Unit;
using Unit.ForUnit;
using UnityEngine;
using UnityEngine.UI;

namespace LevelGame.UI.Barrack
{
    public class BarrackController : MonoBehaviour
    {
        [SerializeField] private MovingUnitsAcrossCells _movingUnitsAcrossCells;
        [SerializeField] private MoveCamera _moveCamera;
        [SerializeField] private List<GameObject> _offOnObjects;
        [SerializeField] private GameObject _barrack;
        [SerializeField] private Transform _cardsTransform;
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private List<UnitType> _unitTypes;
        [SerializeField] private List<Sprite> _sprites;
        private List<GameObject> _cardsContainer;
        private UnitsContainer _unitsContainer;
        public bool BarrackOn { get; private set; }

        private void Start()
        {
            _unitsContainer = UnitsContainer.Instance;
            _cardsContainer = new List<GameObject>();
        }


        public void OnUnit(UnitType type)
        {
            foreach (var ourUnit in _unitsContainer.OurUnits)
            {
                if (ourUnit.GetComponent<UnitControl>().UnitName == type && !ourUnit.activeSelf)
                {
                    var position = ourUnit.transform.position;
                    position = new Vector3(position.x, position.y, -17);
                    ourUnit.transform.position = position;
                    ourUnit.SetActive(true);
                    _movingUnitsAcrossCells.SetUnit(ourUnit.GetComponent<UnitControl>());
                    return;
                }
            }
        }

        public void NewCardInBarrack(UnitType type)
        {
            if (_cardsContainer.Count != 0)
            {
                for (int i = 0; i < _cardsContainer.Count; i++)
                {
                    if (!_cardsContainer[i].activeSelf)
                    {
                        InitializeCard(type, i);
                        _cardsContainer[i].SetActive(true);
                        return;
                    }
                }

                _cardsContainer.Add(Instantiate(_cardPrefab, _cardsTransform));
                InitializeCard(type, _cardsContainer.Count - 1);
            }
            else
            {
                _cardsContainer.Add(Instantiate(_cardPrefab, _cardsTransform));
                InitializeCard(type, _cardsContainer.Count - 1);
            }
        }

        private void InitializeCard(UnitType type, int cardIndex)
        {
            _cardsContainer[cardIndex].GetComponent<CardControl>().BarrackController = this;
            _cardsContainer[cardIndex].GetComponent<CardControl>().UnitType = type;
            var cardImage = _cardsContainer[cardIndex].GetComponent<Image>();
            for (int i = 0; i < _unitTypes.Count; i++)
            {
                if (_unitTypes[i] == type)
                {
                    cardImage.sprite = _sprites[i];
                }
            }
        }

        public void OpenedBarack()
        {
            _moveCamera.SetCameraPosition(CameraPoints.OpenBarrack);
            foreach (var offObject in _offOnObjects)
            {
                offObject.SetActive(false);
            }

            _barrack.SetActive(true);
            BarrackOn = true;
        }

        public void CloseBarrack()
        {
            _moveCamera.SetCameraPosition(CameraPoints.StartPoint);
            foreach (var offObject in _offOnObjects)
            {
                offObject.SetActive(true);
            }

            _barrack.SetActive(false);
            BarrackOn = false;
        }
    }
}