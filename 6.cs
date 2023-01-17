Student std = new Student("имя","фамилия","пол")

//------------------------------------------------------------------------------------------------
class Student{
    public string name, surname, floor;
    public List<string> completeCourses = new List<string>();
    public Dictionary<string, List<double>> marksForCourse = new Dictionary<string, List<double>>();
    public List<string> coursesOnStudy = new List<string>();
    public Student(string name, string surname, string floor){
        this.name = name; this.surname = surname; this.floor = floor;
    }
    private double avgMark;
    private void setAvgmark(){
        if (marksForCourse.Count != 0){
            int marksAmount = 0;
            ICollection<string> courseName = marksForCourse.Keys;
            //foreach (string course in marksForCourse.Keys){
                foreach (double mark in marksForCourse[course]){
                    avgMark += mark;
                    marksAmount++;
                }
            //}
            avgMark /= marksAmount;
        }else{
            avgMark = 0;
        }
    }
    public void addCourseInComplete(string courseName){
        if (!coursesOnStudy.Contains(courseName)){
            throw new Exception("курс не изучается в данный момент");
        }else if (completeCourses.Contains(courseName)){
            throw new Exception("курс уже изучен");
        }
        else { completeCourses.Add(courseName); coursesOnStudy.Remove(courseName); }
    }
    public void consoleWrite(){
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Фамилия: {surname}");
        Console.WriteLine($"Имя:{name}");
        Console.WriteLine($"Имя:{name}");
    }
}

class Mentor{
    public string name, surname;
    public List<string> courses;
    public Mentor(string name, string surname){
        this.name = name;
        this.surname = surname;
    }
}
class Lecturer : Mentor{
    public Lecturer(string name, string surname) : base(name, surname) { }
    Dictionary<string, List<double>> marksForCourse = new Dictionary<string, List<double>>();


}
class Reviewer : Mentor{
    public Reviewer(string name, string surname) : base(name, surname) { }
    public void putMarks(Student student, string courseName, double mark){
        if (!student.marksForCourse.ContainsKey(courseName)) { throw new Exception("студент не изучает данный курс"); }
        else { student.marksForCourse[courseName].Add(mark); }
    }
}
