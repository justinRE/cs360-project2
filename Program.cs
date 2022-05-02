namespace cs360
{
    class Project2 {         
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting Assignment 2");
            
            Project2 project2 = new Project2();

            //this is where I need to handle other comparators for different sort order
            IList<Instruction> instructions = project2.loadData();
            // project2.performFCFS(instructions);
            //project2.performSSTF(instructions);
            Console.Out.WriteLine("FCFS Stats");
            project2.performSearch(instructions, new ArrivalTimeComparer());
            Console.Out.WriteLine("SSTF Stats");
            project2.performSearch(instructions, new TrackRequestComparer());
        }

         private void performSearch( IList<Instruction> instructions, IComparer<Instruction> comparer ){
             List<Instruction> sortedListInstructions = instructions.ToList<Instruction>();
             sortedListInstructions.Sort(comparer);
             instructions = new List<Instruction>();
             instructions = sortedListInstructions;

             IList<Double> accessTimes = new List<Double>();

             Disk disk = new Disk();

             for (int i=0;i<instructions.Count; i++){
                Instruction currentInstruction = instructions[i];
                
                //check for outofbounds
                if (i <=0){
                    disk.calculateSeekTime(new Instruction(), currentInstruction);
                }else{
                    disk.calculateSeekTime(instructions[i-1],currentInstruction);
                }
                //Console.Out.WriteLine(instructions[i]); 
                accessTimes.Add(disk.AccessTime); 
             }
             Console.Out.WriteLine(disk.getStats());

             double average = disk.AverageAccessTime;
             double sum = accessTimes.Sum(d => Math.Pow(d - average, 2));
             Console.Out.WriteLine("Access Time Standard Deviation: " + Math.Sqrt((sum) / accessTimes.Count()));
             Console.Out.WriteLine("Access Time Variance: " + sum / (accessTimes.Count()-1));
         }

         private void performSSTF( IList<Instruction> instructions){
             List<Instruction> sortedListInstructions = instructions.ToList<Instruction>();
             IComparer<Instruction> comparer = new TrackRequestComparer();
             sortedListInstructions.Sort(comparer);
             instructions = new List<Instruction>();
             instructions = sortedListInstructions;

             IList<Double> accessTimes = new List<Double>();

             Disk disk = new Disk();

             for (int i=0;i<instructions.Count; i++){
                Instruction currentInstruction = instructions[i];
                
                //check for outofbounds
                if (i <=0){
                    disk.calculateSeekTime(new Instruction(), currentInstruction);
                }else{
                    disk.calculateSeekTime(instructions[i-1],currentInstruction);
                }
                Console.Out.WriteLine(instructions[i]); 
                accessTimes.Add(disk.AccessTime); 
             }
             Console.Out.WriteLine("SSTF Stats");
             Console.Out.WriteLine(disk.getStats());

             double average = disk.AverageAccessTime;
             double sum = accessTimes.Sum(d => Math.Pow(d - average, 2));
             Console.Out.WriteLine("Access Time Standard Deviation: " + Math.Sqrt((sum) / accessTimes.Count()));
             Console.Out.WriteLine("Access Time Variance: " + sum / (accessTimes.Count()-1));
         }

        private void performFCFS( IList<Instruction> instructions){
            IList<Double> accessTimes = new List<Double>();

            Disk disk = new Disk();

            for (int i=0;i<instructions.Count; i++){
                Instruction currentInstruction = instructions[i];
                
                //check for outofbounds
                if (i <=0){
                    disk.calculateSeekTime(new Instruction(), currentInstruction);
                }else{
                    disk.calculateSeekTime(instructions[i-1],currentInstruction);
                }
                //Console.Out.WriteLine(instructions[i]); 
                accessTimes.Add(disk.AccessTime); 
            }
            Console.Out.WriteLine("FCFS Stats");
            Console.Out.WriteLine(disk.getStats());

            double average = disk.AverageAccessTime;
            double sum = accessTimes.Sum(d => Math.Pow(d - average, 2));
            Console.Out.WriteLine("Access Time Standard Deviation: " + Math.Sqrt((sum) / accessTimes.Count()));
            Console.Out.WriteLine("Access Time Variance: " + sum / (accessTimes.Count()-1));
        }

        private IList<Instruction> loadData(){
            IList<Instruction> data = new List<Instruction>();
            data.Add(new Instruction(0, 50, 9));
            data.Add(new Instruction(23, 135, 6));
            data.Add(new Instruction(25, 20, 2));
            data.Add(new Instruction(29, 25, 1));
            data.Add(new Instruction(35, 200, 9));
            data.Add(new Instruction(45, 175, 5));
            data.Add(new Instruction(57, 180, 3));
            data.Add(new Instruction(83, 99, 4));
            data.Add(new Instruction(88, 73, 5));
            data.Add(new Instruction(95, 199, 6));
            return data;
        }
    }
}