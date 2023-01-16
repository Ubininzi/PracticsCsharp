Student std = new Student("имя","фамилия","пол");
class Student {
	public string name, surname, floor;
	public List<string> completeCourses = new List<string>();
	public Dictionary<string,double> marks = new Dictionary<string,double>();
	public List<string> coursesOnStudy= new List<string>();
	public Student(string name, string surname, string floor){
		this.name = name; this.surname = surname; this.floor = floor;
	}
	public void addCourseInComplete(string courseName){
		if (!coursesOnStudy.Contains(courseName)) {
			throw new Exception("курс не изучается в данный момент");
		}else if (completeCourses.Contains(courseName)){
			throw new Exception("курс уже изучен");
		}else { completeCourses.Add(courseName) ; coursesOnStudy.Remove(courseName); }
	}
}

//class Mentor {
//	public string name, surname;
//	public List<string> courses;
//}
//class Lecturer : Mentor{

//}
//class Reviewer : Mentor{
//	static void ;
//}
