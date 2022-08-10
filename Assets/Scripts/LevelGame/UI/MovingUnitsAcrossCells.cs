using UnityEngine;

namespace LevelGame.UI
{
    public class MovingUnitsAcrossCells : MonoBehaviour
    {
        public static bool HaveObject;
        [SerializeField] private LayerMask _objectSelectionMask;
        [SerializeField] private Camera _camera;
        private const float MAXDistance = 100;
        private Transform _object;
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
                _object.position = new Vector3(_object.position.x, _object.position.y + 2,
                    _object.position.z);
                HaveObject = true;
            }
        }

        private void MoveObject()
        {
            if (Physics.Raycast(_ray, out var hit, MAXDistance, _objectSelectionMask))
            {
                _worldPosition = hit.point;
                var nextPosition = new Vector3(_worldPosition.x, _object.position.y, _worldPosition.z);
                _object.position = Vector3.Lerp(_object.position, nextPosition, 0.1f);
            }
        }

        private void LoseObject()
        {
            if (Physics.Raycast(_ray, out var hit) && hit.transform.gameObject.CompareTag("Cell") &&
                hit.transform.GetComponent<CellControl>().Available)
            {
                _object.position = new Vector3(hit.transform.position.x, _object.transform.position.y - 2,
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