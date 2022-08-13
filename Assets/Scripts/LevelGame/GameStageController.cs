using ForUnit;
using ForUnit.OnUnit;
using LevelGame.Unit;
using Unit.ForUnit;
using UnityEngine;

namespace LevelGame
{
    public class GameStageController : MonoBehaviour
    {
        [SerializeField] private MoveCamera _moveCamera;
        [SerializeField] private GameObject _beforeFight;
        [SerializeField] private GameObject _duringFight;
        [SerializeField] private GameObject _afterFight;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _winPanel;
        public static bool StartFight;
        private UnitsContainer _unitsContainer;

        private void OnDisable()
        {
            _unitsContainer.OnWin -= IfWin;
            _unitsContainer.OnLose -= IfLose;
            _unitsContainer.OnWin -= EndFight;
            _unitsContainer.OnLose -= EndFight;
        }

        private void Start()
        {
            _unitsContainer = UnitsContainer.Instance;
            _unitsContainer.OnWin += IfWin;
            _unitsContainer.OnLose += IfLose;
            _unitsContainer.OnWin += EndFight;
            _unitsContainer.OnLose += EndFight;
            StartFight = false;
            _beforeFight.SetActive(true);
            _duringFight.SetActive(false);
            _afterFight.SetActive(false);
        }

        public void StartFightButton()
        {
            StartFight = true;
            _beforeFight.SetActive(false);
            _duringFight.SetActive(true);
            _afterFight.SetActive(false);
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

        private void IfLose()
        {
            Time.timeScale = 0;
            print("lose!");
            _losePanel.SetActive(true);
        }

        private void IfWin()
        {
            Time.timeScale = 0;
            print("win!");
            _winPanel.SetActive(true);
        }
    }
}