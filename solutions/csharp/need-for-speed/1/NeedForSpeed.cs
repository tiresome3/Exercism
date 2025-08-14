class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int distanceDriven;
    private int battery;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this.distanceDriven = 0;
        this.battery = 100;
    }

    public bool BatteryDrained()
    {
        if (battery < batteryDrain)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            this.distanceDriven += speed;
            this.battery -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distance; 

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while(car.DistanceDriven() < this.distance)
        {
            if (car.BatteryDrained())
            {
                return false;
            }
            car.Drive();
        }
        return true;

    }
}
