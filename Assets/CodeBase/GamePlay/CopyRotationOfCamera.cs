using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

public class CopyRotationOfCamera : MonoBehaviour
{
    private IGameFactory gameFactory;

    [Inject]
    public void Construct(IGameFactory gameFactory)
    {
        this.gameFactory = gameFactory;
    }

    private void Update()
    {
        if (!gameFactory.FollowCamera) return;

        transform.LookAt(transform.position + gameFactory.FollowCamera.transform.rotation * Vector3.forward, gameFactory.FollowCamera.transform.rotation * Vector3.up);
    }
}
