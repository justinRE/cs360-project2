namespace cs360{
    public class Disk{
        private static int MOVEMENT_TIME_CONSTANT = 12;
        private static double TRANSFER_TIME_BASE = 1.2;
        private static int ROTATION_DELAY = 5;
        private int rotationCounter = 0;
        private int totalInstructionsProcessed = 0;

        private double totalSeekTime = 0;

        public int SearchTime
        {
            get { return rotationCounter * ROTATION_DELAY; }
        }

        public double TransferTime
        {
            get { return totalInstructionsProcessed * TRANSFER_TIME_BASE; }
        }

        public double TotalAccessTime
        {
            get { return TransferTime+SearchTime+totalSeekTime; }
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
        double AccessTime = 0;
        bool rotation_made= true;
        // If I make a boolean and use it after the loop, then it won't have the data for each instruction

        public double calculateSeekTime(Instruction previousInstruction,Instruction currentInstruction){
            totalInstructionsProcessed++;
            double seekTimeTmp = 0;
            
            if(previousInstruction.TrackRequest > currentInstruction.TrackRequest){
                rotationCounter++;
                seekTimeTmp = (256-previousInstruction.TrackRequest)+currentInstruction.TrackRequest;
                AccessTime= TRANSFER_TIME_BASE+seekTime+5;
            }else{
                seekTimeTmp = Math.Abs(previousInstruction.TrackRequest-currentInstruction.TrackRequest);
            }
            double seekTime = MOVEMENT_TIME_CONSTANT + (0.1 * seekTimeTmp);

            AccessTime= TRANSFER_TIME_BASE+seekTime;

            standarddeviationvariable = Math.Pow(AccessTime - TotalAccessTime, 2);    
            // m = standarddeviationvariable+m; 

            totalSeekTime= totalSeekTime+seekTime;
            AccessTime = AccessTime+TransferTime+SearchTime+seekTime;

            return seekTime;

        }

        public double Vairance
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
                  // "\nTotal seek time: " + this.totalSeekTime +
                   //"\nTotal Transfer time: " + this.TransferTime +
                   "\nTotal Access time: " + this.TotalAccessTime +
                   "\nAverage Access time for FCFS: " + AverageAccessTime + " ms" +
                   "\nStandard deviation for FCFS: " + StandardDeviation +
                    "\nAccess Time: " + AccessTime;

// vairance, standard deviation

                   
        }
    }
}