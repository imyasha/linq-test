// Create a data source by using a collection initializer.
List<Student> students =
[
    new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= [97, 92, 81, 60]},
    new Student {First="Claire", Last="O'Donnell", ID=112, Scores= [75, 84, 91, 39]},
    new Student {First="Sven", Last="Mortensen", ID=113, Scores= [88, 94, 65, 91]},
    new Student {First="Cesar", Last="Garcia", ID=114, Scores= [97, 89, 85, 82]},
    new Student {First="Debra", Last="Garcia", ID=115, Scores= [35, 72, 91, 70]},
    new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= [99, 86, 90, 94]},
    new Student {First="Hanying", Last="Feng", ID=117, Scores= [93, 92, 80, 87]},
    new Student {First="Hugo", Last="Garcia", ID=118, Scores= [92, 90, 83, 78]},
    new Student {First="Lance", Last="Tucker", ID=119, Scores= [68, 79, 88, 92]},
    new Student {First="Terry", Last="Adams", ID=120, Scores= [99, 82, 81, 79]},
    new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= [96, 85, 91, 60]},
    new Student {First="Michael", Last="Tucker", ID=122, Scores= [94, 92, 91, 91]}
];

IEnumerable<Student> studentQuery =
    from student in students
    where student.Scores[0] > 90 && student.Scores[3] < 80
    orderby student.Last ascending
    select student;

IEnumerable<IGrouping<char, Student>> studentQuery2 =
    from student in students
    group student by student.Last[0];


foreach (Student student in studentQuery)
{
    Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
}

foreach (IGrouping<char, Student> studentGroup in studentQuery2)
{
    Console.WriteLine(studentGroup.Key);
    foreach (Student student in studentGroup)
    {
        Console.WriteLine("   {0}, {1}",
                    student.Last, student.First);
    }
}

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

var studentQuery6 =
    from student in students
    let totalScore = student.Scores[0] = student.Scores[1] + student.Scores[2] + student.Scores[3]
    select totalScore;

double averageScore = studentQuery6.Average();
Console.WriteLine("Class average score = {0}", averageScore);

IEnumerable<string> studentQuery7 =
    from student in students
    where student.Last == "Garcia"
    select student.First;

Console.WriteLine("The Garcias in the class are:");
foreach (string s in studentQuery7)
{
    Console.WriteLine(s);
}


public class Student
{
    public string First { get; set; }
    public string Last { get; set; }
    public int ID { get; set; }
    public List<int> Scores;
}


