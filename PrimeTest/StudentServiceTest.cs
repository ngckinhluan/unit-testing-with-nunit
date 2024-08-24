using NUnit.Framework;
using StudentService;
using StudentService.Entities;
using System.Collections.Generic;

[TestFixture]
public class StudentServiceTests
{
    private StudentService.StudentService _studentService;

    [SetUp]
    public void Setup()
    {
        _studentService = new StudentService.StudentService();
    }

    [Test]
    public void AddStudent_ShouldAddStudentToList()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };

        // Act
        _studentService.AddStudent(student);

        // Assert
        var students = _studentService.GetStudents();
        Assert.AreEqual(1, students.Count);
        Assert.AreEqual(student, students[0]);
    }

    [Test]
    public void RemoveStudent_ShouldRemoveStudentById()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };
        _studentService.AddStudent(student);

        // Act
        _studentService.RemoveStudent(1);

        // Assert
        Assert.AreEqual(0, _studentService.GetStudentCount());
    }

    [Test]
    public void GetStudents_ShouldReturnAllStudents()
    {
        // Arrange
        var student1 = new Student { Id = 1, Name = "John Doe", Age = 20 };
        var student2 = new Student { Id = 2, Name = "Jane Smith", Age = 22 };
        _studentService.AddStudent(student1);
        _studentService.AddStudent(student2);

        // Act
        var students = _studentService.GetStudents();

        // Assert
        Assert.AreEqual(2, students.Count);
        Assert.Contains(student1, students);
        Assert.Contains(student2, students);
    }

    [Test]
    public void GetStudent_ShouldReturnStudentById()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };
        _studentService.AddStudent(student);

        // Act
        var retrievedStudent = _studentService.GetStudent(1);

        // Assert
        Assert.IsNotNull(retrievedStudent);
        Assert.AreEqual(student, retrievedStudent);
    }

    [Test]
    public void UpdateStudent_ShouldUpdateStudentDetails()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };
        _studentService.AddStudent(student);
        var updatedStudent = new Student { Id = 1, Name = "John Smith", Age = 21 };

        // Act
        _studentService.UpdateStudent(updatedStudent);
        var retrievedStudent = _studentService.GetStudent(1);

        // Assert
        Assert.IsNotNull(retrievedStudent);
        Assert.AreEqual("John Smith", retrievedStudent.Name);
        Assert.AreEqual(21, retrievedStudent.Age);
    }

    [Test]
    public void ClearStudents_ShouldRemoveAllStudents()
    {
        // Arrange
        var student1 = new Student { Id = 1, Name = "John Doe", Age = 20 };
        var student2 = new Student { Id = 2, Name = "Jane Smith", Age = 22 };
        _studentService.AddStudent(student1);
        _studentService.AddStudent(student2);

        // Act
        _studentService.ClearStudents();

        // Assert
        Assert.AreEqual(0, _studentService.GetStudentCount());
    }

    [Test]
    public void GetStudentCount_ShouldReturnCorrectCount()
    {
        // Arrange
        var student1 = new Student { Id = 1, Name = "John Doe", Age = 20 };
        var student2 = new Student { Id = 2, Name = "Jane Smith", Age = 22 };
        _studentService.AddStudent(student1);
        _studentService.AddStudent(student2);

        // Act
        int count = _studentService.GetStudentCount();

        // Assert
        Assert.AreEqual(2, count);
    }

    [Test]
    public void IsStudentExists_ShouldReturnTrueIfStudentExists()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };
        _studentService.AddStudent(student);

        // Act
        bool exists = _studentService.IsStudentExists(1);

        // Assert
        Assert.IsTrue(exists);
    }

    [Test]
    public void IsStudentExists_ShouldReturnFalseIfStudentDoesNotExist()
    {
        // Act
        bool exists = _studentService.IsStudentExists(1);

        // Assert
        Assert.IsFalse(exists);
    }
}
