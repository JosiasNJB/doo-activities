namespace State;

// Crie uma interface IState com o método Handle().
public interface IState
{
    void Handle(VendingMachine machine);
}

// Implemente classes como NoCoinState, HasCoinState e SoldState.
public class NoCoinState : IState
{
    public void Handle(VendingMachine machine)
    {
        Console.WriteLine("Coin inserted.");
        machine.SetState(new HasCoinState());
    }
}

public class HasCoinState : IState
{
    public void Handle(VendingMachine machine)
    {
        Console.WriteLine("Product selected.");
        machine.SetState(new SoldState());
    }
}

public class SoldState : IState
{
    public void Handle(VendingMachine machine)
    {
        Console.WriteLine("Product dispensed.");
        machine.SetState(new NoCoinState());
    }
}

public class VendingMachine
{
    private IState _state;

    public VendingMachine()
    {
        _state = new NoCoinState();
    }

    public void SetState(IState state)
    {
        _state = state;
    }

    public void InsertCoin()
    {
        if (_state is NoCoinState)
            _state.Handle(this);
        else
            Console.WriteLine("Coin already inserted.");
    }

    public void SelectProduct()
    {
        if (_state is HasCoinState)
            _state.Handle(this);
        else if (_state is NoCoinState)
            Console.WriteLine("Insert coin first.");
        else
            Console.WriteLine("Product already selected.");
    }

    public void DispenseProduct()
    {
        if (_state is SoldState)
            _state.Handle(this);
        else
            Console.WriteLine("Select product first.");
    }
}

class Program
{
    static void Main()
    {
        var vendingMachine = new VendingMachine();

        vendingMachine.InsertCoin();
        vendingMachine.SelectProduct();
        vendingMachine.DispenseProduct();
    }
}
