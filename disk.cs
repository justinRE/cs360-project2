namespace cs360{
    public class Disk{
        private const int MOVEMENT_TIME_CONSTANT = 12;
        private const double TRANSFER_TIME_BASE = 1.2;
        private const int ROTATION_DELAY = 5;
       
        private int totalRotationCounter = 0;
        private int totalInstructionsProcessed = 0;
        private double totalSeekTime = 0;
        
        private int individualRotationForInstruction = 0;
        private double individualSeekTime = 0;

        public int TotalSearchTime
        {
            get { return totalRotationCounter * ROTATION_DELAY; }
        }

        public double TotalTransferTime
        {
            get { return totalInstructionsProcessed * TRANSFER_TIME_BASE; }
        }

        public double TotalAccessTime
        {
            get { return TotalTransferTime+TotalSearchTime+totalSeekTime; }
        }

        public double AverageAccessTime
        {
            get { 
                if (totalInstructionsProcessed <= 0) 
                    return 0;
                else 
                    return TotalAccessTime/totalInstructionsProcessed; }
        }

        double standarddeviationvariable = 0;
        double m = 0;
    
        public void calculateSeekTime(Instruction previousInstruction,Instruction currentInstruction){
            totalInstructionsProcessed++;
            double seekTimeTmp = 0;
            individualRotationForInstruction = 0;
            individualSeekTime = 0;
            
            if(previousInstruction.TrackRequest > currentInstruction.TrackRequest){
                totalRotationCounter++;
                individualRotationForInstruction++;
                seekTimeTmp = (256-previousInstruction.TrackRequest)+currentInstruction.TrackRequest;
            }else{
                seekTimeTmp = Math.Abs(previousInstruction.TrackRequest-currentInstruction.TrackRequest);
            }
            double seekTime = MOVEMENT_TIME_CONSTANT + (0.1 * seekTimeTmp);

            standarddeviationvariable = Math.Pow(AccessTime - TotalAccessTime, 2);    

            individualSeekTime=seekTime;
            totalSeekTime= totalSeekTime+seekTime;
            //AccessTime = AccessTime+TotalTransferTime+TotalSearchTime+seekTime;

        }

        public double AccessTime{
            get { return (individualRotationForInstruction*ROTATION_DELAY)+TRANSFER_TIME_BASE+individualSeekTime;}
        }
        public double SeekTime{
            get {return individualSeekTime; }
        }
        public double Variance
        {
            get { return m/TotalAccessTime; }
        }
         public double StandardDeviation
        {
            get { return m/TotalAccessTime-1; }
        }

        public String getStats(){
            return "\n:::Disk Stats::: " + 
                   //"\nDisk Search Time: " + this.SearchTime + 
                   //"\nTotal Instructions: " + this.totalInstructionsProcessed +
                   //"\nTotal seek time: " + this.totalSeekTime +
                   //"\nTotal Transfer time: " + this.TransferTime +
                   "\nTotal Access time: " + this.TotalAccessTime +
                   "\nAverage Access time for FCFS: " + AverageAccessTime + " ms" +
                   "\nStandard deviation for FCFS: " + StandardDeviation +
                    "\nAccess Time: " + AccessTime;

// vairance, standard deviation

                   
        }
    }
}