// See https://aka.ms/new-console-template for more information
using System.Linq;

public class Student
{
    public string First { get; set; }
    public string Last { get; set; }
    public int ID { get; set; }
    public List<int> Scores;
    

}
public class Program
{
    public static  List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="John", Last="Snoe", ID=113, Scores= new List<int> {91, 66, 55, 66}},
            new Student {First="Anton", Last="Veselov", ID=114, Scores= new List<int> {54, 99, 91, 95}},
            new Student {First="Jerry", Last="Smith", ID=115, Scores= new List<int> {77, 44, 31, 50}},
            new Student {First="Mattew", Last="O’Donnell", ID=116, Scores= new List<int> {11, 66, 69, 99}},
            new Student {First="Alex", Last="Arcan", ID=117, Scores= new List<int> {86, 74, 66, 54}},
            new Student {First="Mendoza", Last="Garcia", ID=118, Scores= new List<int> {77, 66, 55, 33}},
            new Student {First="Tom", Last="Garcia", ID=119, Scores= new List<int> {66, 55, 55, 53}},
        };
    static void Main()
    {

        Query1();
        Query2();
        Query3();
        Query4();
        Query5();
        double score = Query6();
        Query7();
        Query8(score);
    }
    public static void Query1()
    {
        Console.WriteLine("Query 1");
        IEnumerable<Student> studentQuery =
            from student in students
            //where student.Scores[0] > 90
            where student.Scores[0] > 90 && student.Scores[3] < 80
        //orderby student.Last ascending
            orderby student.Scores[0] descending
            select student;
        foreach (Student student in studentQuery)
        {
            //Console.WriteLine("{0}, {1}", student.Last, student.First);
            Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
        }
    }
    public static void Query2()
    {
        Console.WriteLine("Query 2");
        var studentQuery2 =
            from student in students
            group student by student.Last[0];
        foreach (var studentGroup in studentQuery2)
        {
            Console.WriteLine(studentGroup.Key);
            foreach (Student student in studentGroup)
            {
                Console.WriteLine("   {0}, {1}",student.Last, student.First);
            }
        }

    }
    public static void Query3()
    {
        Console.WriteLine("Query 3");
        var studentQuery3 =
            from student in students
            group student by student.Last[0];

        foreach (var groupOfStudents in studentQuery3)
        {
            Console.WriteLine(groupOfStudents.Key);
            foreach (var student in groupOfStudents)
            {
                Console.WriteLine("   {0}, {1}", student.Last, student.First);
            }
        }

    }
    public static void Query4()
    {
        Console.WriteLine("Query 4");
        var studentQuery4 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

        foreach (var groupOfStudents in studentQuery4)
        {
            Console.WriteLine(groupOfStudents.Key);
            foreach (var student in groupOfStudents)
            {
                Console.WriteLine("   {0}, {1}",
                    student.Last, student.First);
            }
        }

    }
    public static void Query5()
    {
        Console.WriteLine("Query 5");
        var studentQuery5 =
            from student in students
            let totalScore = student.Scores[0] + student.Scores[1] +
                student.Scores[2] + student.Scores[3]
            where totalScore / 4 < student.Scores[0]
            select student.Last + " " + student.First;

        foreach (string s in studentQuery5)
        {
            Console.WriteLine(s);
        }

    }
    public static double Query6()
    {
        Console.WriteLine("Query 6");
        var studentQuery6 = 
            from student in students
            let totalScore = student.Scores [0] + student.Scores [1] +
                student.Scores [2] + student.Scores [3]
            select totalScore;

        double averageScore = studentQuery6.Average();
        Console.WriteLine("Class average score = {0}", averageScore);
        return averageScore;

    }
    public static void Query7()
    {
        Console.WriteLine("Query 7");
        IEnumerable<string> studentQuery7 =
                from student in students
                where student.Last == "Garcia"
                select student.First;
        Console.WriteLine("The Garcias in the class are:");
        foreach (string s in studentQuery7)
        {
            Console.WriteLine(s);
        }


    }
    public static void Query8(double averageScore)
    {
        Console.WriteLine("Query 8");
        var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };

        foreach (var item in studentQuery8)
        {
            Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
        }



    }
}



