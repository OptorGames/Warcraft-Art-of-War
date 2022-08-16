using System;
using ForUnit;
using ForUnit.OnUnit;
using LevelGame.UI.Barrack;
using UnityEngine;

namespace LevelGame.UI
{
    public class MovingUnitsAcrossCells : MonoBehaviour
    {
        [SerializeField] private LayerMask _objectSelectionMask;
        [SerializeField] private LayerMask _objectSelectionCell;
        [SerializeField] private Camera _camera;
        [SerializeField] private BarrackController _barrackController;
        [SerializeField] private InterfaceController _interfaceController;
        private const float MAXDistance = 100;
        private UnitControl _object;
        private Transform _cellTransform;
        private CellControl _cellControl;
        private Vector3 _startObjectPosition;
        private Vector3 _worldPosition;
        private Ray _ray;
        
        private void Update()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                GetObject();
            }

            if (_object != null)
            {
                if (Input.GetMouseButton(0))
                {
                    MoveObject();
                    ChangeCellColor();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    LoseObject();
                }
            }
        }

        private void GetObject()
        {
            if (Physics.Raycast(_ray, out var hit) && hit.transform.gameObject.CompareTag("OurUnit"))
            {
                _object = hit.transform.GetComponent<UnitControl>();
                _startObjectPosition = _object.transform.position;
                _object.transform.position = new Vector3(_object.transform.position.x, _object.transform.position.y + 2,
                    _object.transform.position.z);
            }
        }

        private void MoveObject()
        {
            if (Physics.Raycast(_ray, out var hit, MAXDistance, _objectSelectionMask))
            {
                _worldPosition = hit.point;
                var nextPosition = new Vector3(_worldPosition.x, _object.transform.position.y, _worldPosition.z);
                _object.gameObject.transform.position = Vector3.Lerp(_object.transform.position, nextPosition, 0.1f);
                TryPutInBarrack();
            }
        }

        private void ChangeCellColor()
        {
            if (Physics.Raycast(_ray, out var hit, MAXDistance, _objectSelectionCell))
            {
                if (_cellTransform == null)
                {
                    _cellTransform = hit.transform;
                    _cellControl = _cellTransform.GetComponent<CellControl>();
                    _cellControl.MouseEnter();
                }
                else if (!_cellTransform.Equals(hit.transform))
                {
                    _cellControl.MouseExit();
                    _cellTransform = hit.transform;
                    _cellControl = _cellTransform.GetComponent<CellControl>();
                    _cellControl.MouseEnter();
                }
            }
            else if (_cellTransform != null)
            {
                _cellControl.MouseExit();
                _cellTransform = null;
                _cellControl = null;
            }
        }


        private void LoseObject()
        {
            if (Physics.Raycast(_ray, out var hit, MAXDistance, _objectSelectionMask) &&
                hit.transform.gameObject.CompareTag("Cell") && _cellControl.Available)
            {
                _object.transform.position = new Vector3(hit.transform.position.x, _object.transform.position.y - 2,
                    hit.transform.position.z);
            }
            else
            {
                _object.transform.position = _startObjectPosition;
            }

            _object = null;
            if (_cellControl != null)
            {
                _cellControl.MouseExit();
            }

            _cellTransform = null;
        }


        private void TryPutInBarrack()
        {
            if (_object.transform.position.z < -19 && _barrackController.BarrackOn && _object.gameObject.activeSelf)
            {
                _barrackController.NewCardInBarrack(_object.UnitName);
                _object.gameObject.SetActive(false);
                _object = null;
            }
        }

        public void SetUnit(UnitControl unit)
        {
            _object = unit;
            for (int i = _interfaceController._cellsContainer.Count - 1; i > 0; i--)
            {
                if (_interfaceController._cellsContainer[i].Available)
                {
                    _startObjectPosition = _interfaceController._cellsContainer[i].transform.position;
                }
            }
        }
    }
}