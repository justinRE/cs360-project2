namespace cs360
{
    //Value object that holds data
    public class Instruction{

        private int _arrivalTime = 0;
        private int _trackRequest = 0;
        private int _sectorRequest = 0;

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
         //default constructor
         public Instruction (){
            this._arrivalTime = 0;
            this._trackRequest = 0;
            this._sectorRequest = 0;
        }
        //constructor to create an instruction
        public Instruction (int arrivalTime, int trackRequest, int sectorRequest){
            this._arrivalTime = arrivalTime;
            this._trackRequest = trackRequest;
            this._sectorRequest = sectorRequest;
        }

        //to string method to "see" the data in the value object
        public override string ToString()
        {
            return "ReadDiskRequest[" + 
                " _arrivalTime: " + _arrivalTime +
                ", _trackRequest: " + _trackRequest + 
                ", _sectorRequest: " + _sectorRequest + 
                "]";
        }

    }
}