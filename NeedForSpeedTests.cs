using Exercism.Tests;
using Xunit;

public class NeedForSpeedTests
{
    [Fact]
    [Task(3)]
    public void New_remote_control_car_has_not_driven_any_distance()
    {
        var speed = 10;
        var batteryDrain = 2;
        var car = new RemoteControlCar(speed, batteryDrain);

        Assert.Equal(0, car.DistanceDriven());
    }

    [Fact]
    [Task(3)]
    public void Drive_increases_distance_driven_with_speed()
    {
        var speed = 5;
        var batteryDrain = 1;
        var car = new RemoteControlCar(speed, batteryDrain);

        car.Drive();

        Assert.Equal(5, car.DistanceDriven());
    }

    [Fact]
    [Task(4)]
    public void Drive_does_not_increase_distance_driven_when_battery_drained()
    {
        var speed = 9;
        var batteryDrain = 50;
        var car = new RemoteControlCar(speed, batteryDrain);

        // Drain the battery
        car.Drive();
        car.Drive();

        // One extra drive attempt (should not succeed)
        car.Drive();

        Assert.Equal(18, car.DistanceDriven());
    }

    [Fact]
    [Task(4)]
    public void New_remote_control_car_battery_is_not_drained()
    {
        var speed = 15;
        var batteryDrain = 3;
        var car = new RemoteControlCar(speed, batteryDrain);

        Assert.False(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Drive_to_almost_drain_battery()
    {
        var speed = 2;
        var batteryDrain = 1;
        var car = new RemoteControlCar(speed, batteryDrain);

        // Almost drain the battery
        for (var i = 0; i < 99; i++) car.Drive();

        Assert.False(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Drive_until_battery_is_drained()
    {
        var speed = 2;
        var batteryDrain = 1;
        var car = new RemoteControlCar(speed, batteryDrain);

        // Drain the battery
        for (var i = 0; i < 100; i++) car.Drive();

        Assert.True(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Super_hungry_car_after_one_drive_is_drained()
    {
        var speed = 100;
        var batteryDrain = 60;
        var car = new RemoteControlCar(speed, batteryDrain);
        car.Drive();
        Assert.True(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Super_hungry_car_can_try_driving_but_is_drained()
    {
        var speed = 100;
        var batteryDrain = 60;
        var car = new RemoteControlCar(speed, batteryDrain);
        car.Drive();
        car.Drive();
        Assert.True(car.BatteryDrained());
        Assert.Equal(100, car.DistanceDriven());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_not_driven_any_distance()
    {
        var car = RemoteControlCar.Nitro();
        Assert.Equal(0, car.DistanceDriven());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_battery_not_drained()
    {
        var car = RemoteControlCar.Nitro();
        Assert.False(car.BatteryDrained());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_correct_speed()
    {
        var car = RemoteControlCar.Nitro();
        car.Drive();
        Assert.Equal(50, car.DistanceDriven());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_correct_battery_drain()
    {
        var car = RemoteControlCar.Nitro();

        // The battery is almost drained
        for (var i = 0; i < 24; i++) car.Drive();

        Assert.False(car.BatteryDrained());

        // Drain the battery
        car.Drive();

        Assert.True(car.BatteryDrained());
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_can_easily_finish()
    {
        var speed = 10;
        var batteryDrain = 2;
        var car = new RemoteControlCar(speed, batteryDrain);

        var distance = 100;
        var race = new RaceTrack(distance);

        Assert.True(race.TryFinishTrack(car));
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_can_just_finish()
    {
        var speed = 2;
        var batteryDrain = 10;
        var car = new RemoteControlCar(speed, batteryDrain);

        var distance = 20;
        var race = new RaceTrack(distance);

        Assert.True(race.TryFinishTrack(car));
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_just_cannot_finish()
    {
        var speed = 3;
        var batteryDrain = 20;
        var car = new RemoteControlCar(speed, batteryDrain);

        var distance = 16;
        var race = new RaceTrack(distance);

        Assert.False(race.TryFinishTrack(car));
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_cannot_finish()
    {
        var speed = 1;
        var batteryDrain = 20;
        var car = new RemoteControlCar(speed, batteryDrain);

        var distance = 678;
        var race = new RaceTrack(distance);

        Assert.False(race.TryFinishTrack(car));
    }
}