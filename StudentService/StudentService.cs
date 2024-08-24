using StudentService.Entities;

namespace StudentService;

public class StudentService
{
    private readonly List<Student> _students = new List<Student>();

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
    
    public void RemoveStudent(int id)
    {
        _students.RemoveAll(s => s.Id == id);
    }
    
    public List<Student> GetStudents()
    {
        return _students;
    }
    
    public Student GetStudent(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }
    
    public void UpdateStudent(Student student)
    {
        var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
        if (existingStudent != null)
        {
            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
        }
    }
    
    public void ClearStudents()
    {
        _students.Clear();
    }
    
    public int GetStudentCount()
    {
        return _students.Count;
    }
    
    public bool IsStudentExists(int id)
    {
        return _students.Any(s => s.Id == id);
    }
    
    
}