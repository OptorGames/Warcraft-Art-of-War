using System.Collections.Generic;
using ForUnit;
using ForUnit.OnUnit;
using Unit;
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
        private List<GameObject> _cardsContainer;
        private UnitsContainer _unitsContainer;
        private InterfaceController _interfaceController;
        public bool BarrackOn { get; private set; }

        private void Start()
        {
            _unitsContainer = UnitsContainer.Instance;
            _interfaceController = InterfaceController.Instance;
            _cardsContainer = new List<GameObject>();
        }


        public void OnUnit(UnitTypes types)
        {
            foreach (var ourUnit in _unitsContainer.OurUnits)
            {
                if (ourUnit.GetComponent<UnitControl>().UnitName == types && !ourUnit.activeSelf)
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

        public void NewCardInBarrack(UnitTypes types)
        {
            if (_cardsContainer.Count != 0)
            {
                for (int i = 0; i < _cardsContainer.Count; i++)
                {
                    if (!_cardsContainer[i].activeSelf)
                    {
                        InitializeCard(types, i);
                        _cardsContainer[i].SetActive(true);
                        return;
                    }
                }

                _cardsContainer.Add(Instantiate(_cardPrefab, _cardsTransform));
                InitializeCard(types, _cardsContainer.Count - 1);
            }
            else
            {
                _cardsContainer.Add(Instantiate(_cardPrefab, _cardsTransform));
                InitializeCard(types, _cardsContainer.Count - 1);
            }
        }

        private void InitializeCard(UnitTypes types, int cardIndex)
        {
            _cardsContainer[cardIndex].GetComponent<CardControl>().BarrackController = this;
            _cardsContainer[cardIndex].GetComponent<CardControl>().UnitTypes = types;
            var cardImage = _cardsContainer[cardIndex].GetComponent<Image>();
            cardImage.sprite = _interfaceController.Sprites[(int) types - 1];
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