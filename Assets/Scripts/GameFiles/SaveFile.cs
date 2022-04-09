using UnityEngine;

public class SaveFile : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private const string SaveFiles = "PlayerData";

    private PlayerData _localPlayerData;
    
    private void Start()
    {
        Load();
    }

    private void Update()
    {
        Save();
    }
    
    [ContextMenu("Save")]
    public void Save()
    {
        var playerPos = player.transform.position;
        _localPlayerData = new PlayerData()
        {
            playerPositionX = playerPos.x,
            playerPositionY = playerPos.y
        };
        
        var data =JsonUtility.ToJson(_localPlayerData); 
        Debug.Log(data);
        PlayerPrefs.SetString(SaveFiles,data );
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        if (PlayerPrefs.HasKey(SaveFiles))
        {
            //Load the Data 
            var dataString = PlayerPrefs.GetString(SaveFiles);
            Debug.Log(dataString);
            var playerData = JsonUtility.FromJson<PlayerData>(dataString);
            _localPlayerData = playerData;
        }
        else
        {
            _localPlayerData = new PlayerData();
            Save();
        }

        Vector3 playerPos = new Vector2(_localPlayerData.playerPositionX, _localPlayerData.playerPositionY);
        player.transform.position = playerPos;

    }
}
