namespace cs360
{
    public class Instruction{
        private static int MOVEMENT_TIME_CONSTANT = 12;
        private int _arrivalTime = 0;
        private int _trackRequest = 0;
        private int _sectorRequest = 0;
        private double _seekTime = 0;

        public int ArrivalTime
        {
            get { return _arrivalTime; }
            set { _arrivalTime = value; }
        }
        public int TrackRequest
        {
            get { return _trackRequest; }
            set { _trackRequest = value; }
        }
        public int SectorRequest
        {
            get { return _sectorRequest; }
            set { _sectorRequest = value; }
        }
        public double SeekTime
        {
            get { return _seekTime; }
        }

        public double calculateSeekTime(int originalHeadLocation){
            //calculate _seekTime
            _seekTime = MOVEMENT_TIME_CONSTANT + (0.1 * Math.Abs(originalHeadLocation-_trackRequest));
            return _seekTime;
        }

        public Instruction (int arrivalTime, int trackRequest, int sectorRequest){
            this._arrivalTime = arrivalTime;
            this._trackRequest = trackRequest;
            this._sectorRequest = sectorRequest;
        }

    

        public override string ToString()
        {
            return "ReadDiskRequest[" + 
                " _arrivalTime: " + _arrivalTime +
                ", _trackRequest: " + _trackRequest + 
                ", _sectorRequest: " + _sectorRequest + 
                " _seekTime: " + _seekTime +
                "]";
        }

    }
}