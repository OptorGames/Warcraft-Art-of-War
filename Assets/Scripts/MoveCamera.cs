using DG.Tweening;
using LevelGame;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public Camera Camera => _camera;

    private readonly Vector3 _positionWhenStartGame = new Vector3(16.5f, 15, -11.5f);
    private readonly Vector3 _positionWhenOpenBarrack = new Vector3(0f, 17f, -15f);
    private readonly Vector3 _positionWhenCloseBarrack = new Vector3(2f, 18, -25f);
    
    private readonly Vector3 _rotateWhenStartGame = new Vector3(45, -73, 0);
    private readonly Vector3 _rotateWhenOpenBarrack = new Vector3(90, 0, 0);
    private readonly Vector3 _rotateWhenCloseBarrack = new Vector3(50, -10, 0);


    public void SetCameraPosition(CameraPoints cameraPoint)
    {
        switch (cameraPoint)
        {
            case CameraPoints.StartPoint:
                Move(_positionWhenCloseBarrack, _rotateWhenCloseBarrack);
                break;
            case CameraPoints.OpenBarrack:
                Move(_positionWhenOpenBarrack, _rotateWhenOpenBarrack);
                break;
            case CameraPoints.StartGame:
                Move(_positionWhenStartGame, _rotateWhenStartGame);
                break;
        }
    }

    private void Move(Vector3 position, Vector3 rotate)
    {
        _camera.transform.DOMove(position, 1);
        _camera.transform.DORotate(rotate, 1);
    }
}