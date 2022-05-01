namespace cs360
{
    class Project2 {         
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting Assignment 2");
            
            Project2 project2 = new Project2();
            List<ReadDiskRequest> data = project2.loadData();

            foreach (ReadDiskRequest item in data){
                 System.Console.WriteLine(item);
            }           
        }

        private List<ReadDiskRequest> loadData(){
            List<ReadDiskRequest> data = new List<ReadDiskRequest>();
            data.Add(new ReadDiskRequest(0, 50, 9));
            data.Add(new ReadDiskRequest(23, 135, 6));
            data.Add(new ReadDiskRequest(25, 20, 2));
            data.Add(new ReadDiskRequest(29, 25, 1));
            data.Add(new ReadDiskRequest(35, 200, 9));
            data.Add(new ReadDiskRequest(45, 175, 5));
            data.Add(new ReadDiskRequest(57, 180, 3));
            data.Add(new ReadDiskRequest(83, 99, 4));
            data.Add(new ReadDiskRequest(88, 73, 5));
            data.Add(new ReadDiskRequest(95, 199, 6));
            return data;
        }
    }
}