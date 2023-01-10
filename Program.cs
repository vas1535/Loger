using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Loger
//{
//    internal class Program
//    {


//        static void Main(string[] args)
//        {

//            var logger = NLog.LogManager.GetCurrentClassLogger();
//            logger.Info("Старт программы Строитель дома в консольке! {UserName}", "Serjo");
//            List<Worker> workers = new List<Worker> { new Worker("Степан"), new Worker("Жека"), new Worker("Герасим"), new Worker("Митя") };
//            House house = new House();
//            Team team = new Team("Жорик", workers);

//            Console.WriteLine(team.Name);

//            Random r = new Random();
//            for (int i = 0; i < 6; i++)
//            {
//                team.w[r.Next(0, 3)].Build(house, team.t);
//            }
//            foreach (var a in team.t.report)
//            {
//                Console.WriteLine(a);
//            }

//            team.t.Report();
//            Console.WriteLine();
//            for (int i = 0; i < 5; i++)
//            {
//                team.w[r.Next(0, 3)].Build(house, team.t);
//            }

//            foreach (var a in team.t.report)
//            {
//                Console.WriteLine(a);
//            }
//            team.t.Report();

//            house.Paint(team.t);
//            NLog.LogManager.Shutdown();
//        }
//    }
//    interface IWorker
//    {
//        string Name { get; }
//    }
//    interface IPart
//    {
//        void Do(House house);
//    }

//    class Basement : IPart
//    {
//        public void Do(House house)
//        {
//            house.basement = new Basement();
//        }
//    }
//    class Walls : IPart
//    {
//        public void Do(House house)
//        {
//            house.walls.Add(new Walls());
//        }
//    }

//    class Door : IPart
//    {
//        public void Do(House house)
//        {
//            house.door = new Door();
//        }
//    }

//    class Window : IPart
//    {
//        public void Do(House house)
//        {
//            house.window.Add(new Window());
//        }
//    }

//    class Roof : IPart
//    {
//        public void Do(House house)
//        {
//            house.roof = new Roof();
//        }
//    }

//    class House
//    {
//        public Basement basement;
//        public List<Walls> walls;
//        public List<Window> window;
//        public Door door;
//        public Roof roof;


//        public void Paint(TeamLeader t)
//        {
//            if (t.report.Count == 11)
//            {
//                string house = @"
//                            (_)            
//                    ________[_]________    
//                   /\        ______    \   
//                  //_\       \    /\    \  
//                 //___\       \__/  \    \
//                //_____\       \ |[]|     \
//               //_______\       \|__|      \
//              /XXXXXXXXXX\                  \
//             /_I_II  I__I_\__________________\
//               I_I|  I__I_____[]_|_[]_____I
//               I_II  I__I_____[]_|_[]_____I
//               I II__I  I     XXXXXXX     I
//            ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~";
//                Console.WriteLine(house);
//                var logger = NLog.LogManager.GetCurrentClassLogger();
//                logger.Info("Дом построен в консольке! {UserName}{Date}", "Serjo", DateTime.Now);
//            }
//            //else Console.WriteLine("Дом еще не построен!");
//        }
//    }
//    class Team : IWorker
//    {
//        public TeamLeader t;
//        public List<Worker> w;
//        public string Name { get; set; }

//        public Team(string name, List<Worker> workers)
//        {
//            t = new TeamLeader(name);
//            w = workers;
//        }


//    }

//    class Worker : IWorker
//    {
//        string Name { get; set; }

//        string IWorker.Name => Name;

//        public Worker(string name)
//        { Name = name; }

//        public void Build(House house, TeamLeader t)
//        {
//            if (house.basement == null)
//            {
//                Basement basement = new Basement();
//                basement.Do(house);
//                //t.report.Add($"Работник {Name} Построил фундамент!");
//                var logger = NLog.LogManager.GetCurrentClassLogger();
//                logger.Info("Работник { } Построил фундамент в {время завершения работ:}", Name, DateTime.Now);
//            }
//            else if (house.walls == null || house.walls.Count < 4)
//            {
//                if (house.walls == null) house.walls = new List<Walls>();
//                Walls wall = new Walls();
//                wall.Do(house);
//                //t.report.Add($"Работник {Name} построил стену {house.walls.Count}!");
//                var logger = NLog.LogManager.GetCurrentClassLogger();
//                logger.Info("Работник { } Построил стену в {время завершения работ:}", Name, DateTime.Now);
//            }
//            else if (house.door == null)
//            {
//                Door door = new Door();
//                door.Do(house);
//                //t.report.Add($"Работник {Name} установил дверь!");
//                var logger = NLog.LogManager.GetCurrentClassLogger();
//                logger.Info("Работник { } установил дверь в {время завершения работ:}", Name, DateTime.Now);
//            }

//            else if (house.window == null || house.window.Count < 4)
//            {
//                if (house.window == null) house.window = new List<Window>();
//                Window window = new Window();
//                window.Do(house);
//                //t.report.Add($"Работник {Name} установил оконный стеклопакет {house.window.Count}!");
//                var logger = NLog.LogManager.GetCurrentClassLogger();
//                logger.Info("Работник { } установил { } окно {время завершения работ:}", Name, house.window.Count, DateTime.Now);
//            }

//            else if (house.roof == null)
//            {
//                Roof roof = new Roof();
//                roof.Do(house);
//                //t.report.Add($"Работник {Name} построил крышу!");
//                var logger = NLog.LogManager.GetCurrentClassLogger();
//                logger.Info("Работник { } Построил крышу {время завершения работ:}", Name, DateTime.Now);
//            }

//        }
//    }
//    class TeamLeader : IWorker
//    {
//        string Name { get; set; }
//        public List<string> report = new List<string>();
//        string IWorker.Name => Name;
//        public TeamLeader(string name)
//        { Name = name; }
//        public void Report()
//        {
//            double d = (report.Count / 11.0) * 100;
//            //Console.WriteLine($"Прораб {Name} докладывает, что {(int)d} % работ завершен!");
//            var logger = NLog.LogManager.GetLogger("Logger");
//            logger.Info("Прораб { Имя } докладывает, что во время { Время } { % работ }% работ завершен", Name, DateTime.Now, d);
//        }
//    }
//}

