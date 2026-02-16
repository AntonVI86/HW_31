using System.Collections.Generic;

public class ControllersUpdateService
{
    private List<Controller> _controlers = new();

    public void Add(Controller controller)
    {
        _controlers.Add(controller);
    }

    public void Update(float deltaTime)
    {
        foreach (Controller controller in _controlers)
            controller.Update(deltaTime);
    }
}
