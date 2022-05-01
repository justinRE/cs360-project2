public class ReadDiskRequest{
    private int _arrivalTime = 0;
    private int _trackRequest = 0;
    private int _sectorRequest = 0;

    public ReadDiskRequest (int arrivalTime, int trackRequest, int sectorRequest){
        this._arrivalTime = arrivalTime;
        this._trackRequest = trackRequest;
        this._sectorRequest = sectorRequest;
    }

     public override string ToString()
    {
        return "ReadDiskRequest[_arrivalTime: " + _arrivalTime+ ",_trackRequest: " + _trackRequest+ ",_sectorRequest: " + _sectorRequest+"]";
    }

}