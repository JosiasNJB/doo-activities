namespace Adapter;

// Defina a interface ITemperatureSensor com o método ReadTemperature().
public interface ITemperatureSensor
{
    double ReadTemperature();
}

// Crie adaptadores para cada sensor (SensorAAdapter, SensorBAdapter, SensorCAdapter) que implementam ITemperatureSensor.
public class SensorA
{
    public double GetTemperatureInCelsius()
    {
        return 25.3; 
    }
}
public class SensorB
{
    public double ObtenerTemperaturaEnCentigrados()
    {
        return 26.7;
    }
}

public class SensorC
{
    public double FetchTempC()
    {
        return 24.8;
    }
}

public class SensorAAdapter : ITemperatureSensor
{
    private readonly SensorA _sensorA;

    public SensorAAdapter(SensorA sensorA)
    {
        _sensorA = sensorA;
    }

    public double ReadTemperature()
    {
        return _sensorA.GetTemperatureInCelsius();
    }
}

public class SensorBAdapter : ITemperatureSensor
{
    private readonly SensorB _sensorB;

    public SensorBAdapter(SensorB sensorB)
    {
        _sensorB = sensorB;
    }

    public double ReadTemperature()
    {
        return _sensorB.ObtenerTemperaturaEnCentigrados();
    }
}

public class SensorCAdapter : ITemperatureSensor
{
    private readonly SensorC _sensorC;

    public SensorCAdapter(SensorC sensorC)
    {
        _sensorC = sensorC;
    }

    public double ReadTemperature()
    {
        return _sensorC.FetchTempC();
    }
}
// Demonstre como seu sistema pode ler a temperatura de diferentes sensores de forma unificada.
class Program
{
    static void Main(string[] args)
    {
        SensorA sensorA = new SensorA();
        SensorB sensorB = new SensorB();
        SensorC sensorC = new SensorC();

        ITemperatureSensor sensor1 = new SensorAAdapter(sensorA);
        ITemperatureSensor sensor2 = new SensorBAdapter(sensorB);
        ITemperatureSensor sensor3 = new SensorCAdapter(sensorC);

        Console.WriteLine($"Sensor A: {sensor1.ReadTemperature()}°C");
        Console.WriteLine($"Sensor B: {sensor2.ReadTemperature()}°C");
        Console.WriteLine($"Sensor C: {sensor3.ReadTemperature()}°C");
    }
}



