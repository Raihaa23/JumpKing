using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private new GameObject camera;

    private void Update()
    {
        CameraTracking();
    }

    private void CameraTracking()
    {
        var yPos = player.transform.position.y;
        var cameraPos = camera.transform.position;
        if (yPos >= 0 && cameraPos.y >= -1.15 )
        {
            cameraPos = new Vector3(cameraPos.x, yPos, cameraPos.z);
        }
        else
        {
            cameraPos = new Vector3(cameraPos.x, 0, cameraPos.z);
        }
        camera.transform.position = cameraPos;
    }
}