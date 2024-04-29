internal class RemoteControlCar
{
    private int _battery = 100;
    private readonly int _batteryDrain;
    private int _distanceDriven;
    private bool _IsbatteryDrained;
    private readonly int _speed;

    /// Initializes a new instance of the RemoteControlCar class with default values.
    /// Initializes a new instance of the RemoteControlCar class with the specified speed and battery drain.
    /// "speed" The speed of the remote control car.
    /// batteryDrain The battery drain of the remote control car.
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    /// Checks if the battery is drained.
    public bool BatteryDrained()
    {
        return _battery <= 0 || _battery < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    /// Drives the vehicle by reducing the battery level and increasing the distance driven based on speed.
    public void Drive()
    {
        if (!BatteryDrained() && _battery >= _batteryDrain)
        {
            _battery -= _batteryDrain;
            _distanceDriven += _speed;
        }
        else
        {
            _IsbatteryDrained = true;
        }
    }

    public static RemoteControlCar Nitro()
    {
        var speed = 50;
        var batteryDrain = 4;
        return new RemoteControlCar(speed, batteryDrain);
    }
}

internal class RaceTrack
{
    private readonly int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    /// Tries to finish the track with the provided remote control car.
    public bool TryFinishTrack(RemoteControlCar car)
    {
        // Keep driving the car until either the distance is covered or the battery is drained
        while (car.DistanceDriven() < _distance && !car.BatteryDrained()) car.Drive();

        // Return true if the distance is covered, false otherwise
        return car.DistanceDriven() >= _distance;
    }
}