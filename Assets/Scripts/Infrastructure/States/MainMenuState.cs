public class MainMenuState : IState
{
    private SceneLoader _loader;

    public MainMenuState(SceneLoader loader)
    {
        _loader = loader;
    }
    public void Enter()
    {
        
        _loader.Load(ScenesList.MainMenuScene);
    }

    public void Exit()
    {
    }
}
