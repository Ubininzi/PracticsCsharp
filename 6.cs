Student std = new Student("имя", "фамилия", "пол");
Student bns = new Student("яи", "ыфыфы", "паркет");
std.Print();
bns.Print();
Lecturer lct = new Lecturer("имя", "фамилия");
lct.courses.Add("git");
lct.Print();
std.addMarkToLecturer(lct, "git", 10);
std.addMarkToLecturer(lct, "git", 5);
lct.Print();
//---------------------------------------------------------------------------
double AvgMarkForCourseOfAllStudents(List<Student> ListOfStudents, string Course){
	double AvgMark = 0; int amount = 0;
	foreach (Student student in ListOfStudents){
		AvgMark += student.avgMarkForCourse[Course];
		amount++;
	}
	return AvgMark /= amount;
}
double AvgMarkForCourseOfAllLectors(List<Lecturer> ListOfLectors, string Course){
	double AvgMark = 0; int amount = 0;
	foreach (Lecturer lecturer in ListOfLectors){
		foreach (double mark in lecturer.marksForCourse[Course])
			AvgMark += mark;
			amount++;
	}
	return AvgMark /= amount;
}
//----------------------------------------------------------------------------
class Student{
	public string name, surname, floor;
	public List<string> completeCourses = new List<string>();
	public Dictionary<string, List<double>> marksForCourse = new Dictionary<string, List<double>>();
	public List<string> coursesOnStudy = new List<string>();
	public Student(string name, string surname, string floor){
		this.name = name; this.surname = surname; this.floor = floor;
	}
	public Dictionary<string, double> avgMarkForCourse;
	public void setAvgMarkForCourse(){
		foreach (string course in marksForCourse.Keys){
			int marksAmount = 0;
			double avgMark = 0;
			foreach (double mark in marksForCourse[course]){
				avgMark += mark;
				marksAmount++;
			}
			avgMark /= marksAmount;
			avgMarkForCourse.Add(course, avgMark);
		}
	}
	public double avgMark;
	public void setAvgMark(){
		int amount = 0;
		foreach (double mark in avgMarkForCourse.Values){
			avgMark += mark;
			amount++;
		}
		avgMark /= amount;
	}
	public void addCourseInComplete(string courseName){
		if (!coursesOnStudy.Contains(courseName)){
			Console.WriteLine("курс не изучается в данный момент");
		}else if (completeCourses.Contains(courseName)){
			Console.WriteLine("курс уже изучен");
		}
		else { completeCourses.Add(courseName); coursesOnStudy.Remove(courseName); }
	}
	public void Print(){
		Console.WriteLine($"Имя: {name}");
		Console.WriteLine($"Фамилия: {surname}");
		Console.WriteLine($"средняя оценка: {avgMark}");
		Console.Write($"Курсы в процессе изучения: ");
		if (coursesOnStudy.Count == 0) { Console.Write("нет курсов"); }
		else if (coursesOnStudy.Count == 1) { Console.Write($"{coursesOnStudy[0]}"); }
		else{
			Console.Write($"{coursesOnStudy[0]}");
			for (int i = 1; i < coursesOnStudy.Count; i++){
				Console.Write($", {coursesOnStudy[i]}");
			}
		}
		Console.Write($"\nЗавершенные курсы: ");
		if (completeCourses.Count == 0) { Console.Write("нет курсов"); }
		else if (completeCourses.Count == 1) { Console.Write($"{completeCourses[0]}"); }
		else{
			Console.Write($"{completeCourses[0]}");
			for (int i = 1; i < completeCourses.Count; i++){
				Console.Write($", {completeCourses[i]}");
			}
		}
		Console.Write("\n");
	}
	public void addMarkToLecturer(Lecturer lecturer, string course, double mark){
		if (!lecturer.marksForCourse.ContainsKey(course)){
			Console.WriteLine("нет курса");
		}else{
			marksForCourse[course].Add(mark);
			lecturer.setAvgMark();
		}
	}
}
class Mentor
{
	public string name, surname;
	public List<string> courses;
	public Mentor(string name, string surname){
		this.name = name;
		this.surname = surname;
	}
}
class Lecturer : Mentor
{
	public Lecturer(string name, string surname) : base(name, surname) { }
	public Dictionary<string, List<double>> marksForCourse = new Dictionary<string, List<double>>();
	public void Print(){
		Console.WriteLine($"Имя: {name}");
		Console.WriteLine($"Фамилия: {surname}");
		Console.WriteLine($"Средняя оценка за лекции: {avgMark}");
	}
	private double avgMark;
	public void setAvgMark(){
		if (marksForCourse.Count != 0){
			int marksAmount = 0;
			foreach (string course in marksForCourse.Keys)
			{
				foreach (double mark in marksForCourse[course])
				{
					avgMark += mark;
					marksAmount++;
				}
			}
			avgMark /= marksAmount;
		}else{
			avgMark = 0;
		}
	}
}
class Reviewer : Mentor{
	public Reviewer(string name, string surname) : base(name, surname) { }
	public void putMarks(Student student, string courseName, double mark){
		if (!student.marksForCourse.ContainsKey(courseName)) { Console.WriteLine("студент не изучает данный курс"); }
		else { student.marksForCourse[courseName].Add(mark); student.setAvgMarkForCourse(); }
	}
}
