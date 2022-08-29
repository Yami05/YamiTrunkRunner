using System;

public class GameEvents : Singleton<GameEvents>
{
    public Action Start;
    public Action MouseUp;
    public Action SuckIn;
    public Action GameOver;
    public Action Restart;
    public Action NextLevel;
    public Action Win;
}
