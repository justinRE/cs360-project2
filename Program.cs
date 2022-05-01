namespace cs360
{
    class Project2 {         
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting Assignment 2");
            
            Project2 project2 = new Project2();
            IList<Instruction> instructions = project2.loadData();

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
                Console.Out.WriteLine(" - Seek Time: " + disk.SeekTime);  
                Console.Out.WriteLine(" - Access Time: " + disk.AccessTime);  
            }
            Console.Out.WriteLine(disk.getStats());
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