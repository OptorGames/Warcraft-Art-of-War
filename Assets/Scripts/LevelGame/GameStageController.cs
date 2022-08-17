using ForUnit;
using ForUnit.OnUnit;
using UnityEngine;

namespace LevelGame
{
    public class GameStageController : MonoBehaviour
    {
        [SerializeField] private MoveCamera _moveCamera;
        [SerializeField] private GameObject _beforeFight;
        [SerializeField] private GameObject _duringFight;
        [SerializeField] private GameObject _afterFight;
        [SerializeField] private MeshRenderer _spawnOurPoint;
        public static bool StartFight;
        private UnitsContainer _unitsContainer;

        private void OnDisable()
        {
            _unitsContainer.OnWin -= EndFight;
            _unitsContainer.OnLose -= EndFight;
        }

        private void Start()
        {
            _unitsContainer = UnitsContainer.Instance;
            _unitsContainer.OnWin += EndFight;
            _unitsContainer.OnLose += EndFight;
            StartFight = false;
            _beforeFight.SetActive(true);
            _duringFight.SetActive(false);
            _afterFight.SetActive(false);
            _spawnOurPoint.enabled = false;
        }

        public void StartFightButton()
        {
            StartFight = true;
            _beforeFight.SetActive(false);
            _duringFight.SetActive(true);
            _afterFight.SetActive(false);
            _spawnOurPoint.transform.position = new Vector3(6, _spawnOurPoint.transform.position.y, -6);
            _spawnOurPoint.enabled = true;

            foreach (var enemyUnit in _unitsContainer.EnemyUnits)
            {
                enemyUnit.GetComponent<UnitControl>().NavMeshAgent.enabled = true;
            }

            foreach (var ourUnit in _unitsContainer.OurUnits)
            {
                if (!ourUnit.activeSelf)
                {
                    _unitsContainer.OurUnits.Remove(ourUnit);
                }

                ourUnit.GetComponent<UnitControl>().NavMeshAgent.enabled = true;
            }

            _moveCamera.SetCameraPosition(CameraPoints.StartGame);
        }

        private void EndFight()
        {
            StartFight = false;
            _beforeFight.SetActive(false);
            _duringFight.SetActive(false);
            _afterFight.SetActive(true);
        }
    }
}