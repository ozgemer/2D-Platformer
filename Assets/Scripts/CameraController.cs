using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Update()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
