using System.Collections;
using LevelGame.Unit;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelGame
{
    public class GameStageController : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
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
                ourUnit.GetComponent<UnitControl>().NavMeshAgent.enabled = true;
            }

            StartCoroutine(MoveCamera());
        }

        private IEnumerator MoveCamera()
        {
            while (_camera.position != new Vector3(16.5f, 15, -11.5f))
            {
                var nextPosition = new Vector3(16.5f, 15, -11.5f);
                _camera.position = Vector3.Lerp(_camera.position, nextPosition, 0.05f);
                var nextRotate = Quaternion.Euler(45, -73, 0);
                _camera.rotation = Quaternion.Lerp(_camera.rotation, nextRotate, 0.05f);
                yield return new WaitForEndOfFrame();
            }
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