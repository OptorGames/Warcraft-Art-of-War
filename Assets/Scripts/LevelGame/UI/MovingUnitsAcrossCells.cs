using UnityEngine;

namespace LevelGame.UI
{
    public class MovingUnitsAcrossCells : MonoBehaviour
    {
        
        public static bool HaveObject;
        private Transform _object;
        private Vector3 _startObjectPosition;
        private Vector3 _worldPosition;
        private Ray _ray;

        private void Update()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                GetObject();
            }

            if (_object != null)
            {
                if (Input.GetMouseButton(0))
                {
                    MoveObject();
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
                _object = hit.transform;
                _startObjectPosition = _object.transform.position;
                _object.transform.position = new Vector3(_object.transform.position.x, _object.transform.position.y + 2,
                    _object.transform.position.z);
                HaveObject = true;
            }
        }

        private void MoveObject()
        {
            if (Physics.Raycast(_ray, out var hit))
            {
                _worldPosition = hit.point;
                _object.position = new Vector3(_worldPosition.x, _object.position.y, _worldPosition.z);
            }
        }

        private void LoseObject()
        {
            if (Physics.Raycast(_ray, out var hit) && hit.transform.gameObject.CompareTag("Cell") &&
                hit.transform.GetComponent<CellControl>().Available)
            {
                _object.transform.position = new Vector3(hit.transform.position.x, _object.transform.position.y - 2,
                    hit.transform.position.z);
                ;
            }
            else
            {
                _object.transform.position = _startObjectPosition;
            }
            _object = null;
            HaveObject = false;
        }
    }
}

