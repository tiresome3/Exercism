class RemoteControlCar
{
    private int _distanceDriven = 0;
    private int _batteryLeft = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {this._distanceDriven} meters";
    }

    public string BatteryDisplay()
    {
        if (this._batteryLeft != 0)
        {
            return $"Battery at {this._batteryLeft}%";
        } else
        {
            return "Battery empty";
        };
    }

    public void Drive()
    {
        if (_batteryLeft != 0)
        {
            this._distanceDriven += 20;
            this._batteryLeft -= 1;
        }
    }
}
