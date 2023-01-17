Student std = new Student("имя", "фамилия", "пол");
std.printInfo();

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
	public void setAvgmark(){
		if (marksForCourse.Count != 0){
			int marksAmount = 0;
			foreach (string course in marksForCourse.Keys){
				foreach (double mark in marksForCourse[course]){
					avgMark += mark;
					marksAmount++;
				}
			}
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
	public void printInfo(){
		Console.WriteLine($"Имя: {name}");
		Console.WriteLine($"Фамилия: {surname}");
		Console.WriteLine($"средняя оценка: {avgMark}");
		Console.Write($"Курсы в процессе изучения: ");
		if (coursesOnStudy.Count == 0) { Console.Write("нет курсов"); }
		else if (coursesOnStudy.Count == 1) { Console.Write($"{coursesOnStudy[0]}");  }
		else {
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
	}
	//public void addMarkToLecturer(Lecturer lecturer,) { }
	public static bool operator > (Student std1, Student std2) {
		return (std1.avgMark > std2.avgMark);
	}
    public static bool operator < (Student std1, Student std2){
        return (std1.avgMark < std2.avgMark);
    }
    public static bool operator != (Student std1, Student std2){
        return (std1.avgMark != std2.avgMark);
    }
    public static bool operator == (Student std1, Student std2){
        return (std1.avgMark == std2.avgMark);
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
	public void printInfo(){
		Console.WriteLine($"Имя: {name}");
		Console.WriteLine($"Фамилия: {surname}");
	}
	private double avgMark;
    public void setAvgmark(){
        if (marksForCourse.Count != 0){
            int marksAmount = 0;
            foreach (string course in marksForCourse.Keys){
                foreach (double mark in marksForCourse[course]){
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
		if (!student.marksForCourse.ContainsKey(courseName)) { throw new Exception("студент не изучает данный курс"); }
		else { student.marksForCourse[courseName].Add(mark);student.setAvgmark(); }
	}
}
