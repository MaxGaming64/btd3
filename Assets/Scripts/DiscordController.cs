using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        discord = new Discord.Discord(970109734105542690, (ulong)CreateFlags.Default);

        var activityManager = discord.GetActivityManager();
        var activity = new Activity
        {
            Assets =
            {
                LargeImage = "icon"
            }
        };

        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Result.Ok)
            {
                Debug.Log("Success!");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    void Update()
    {
        discord.RunCallbacks();
    }
}
