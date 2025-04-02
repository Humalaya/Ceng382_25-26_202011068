using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

public class ClassInformationModel
{
    private static int _idCounter;
    private static readonly List<ClassInformationModel> _classList = new();

    public int Id { get; set; }

    [Required(ErrorMessage = "Class Name is required")]
    public string ClassName { get; set; }

    [Required(ErrorMessage = "Student Count is required")]
    [Range(1, 500, ErrorMessage = "Student Count must be between 1 and 500")]
    public int StudentCount { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    public ClassInformationModel() { }

    public ClassInformationModel(string className, int studentCount, string description)
    {
        Id = _idCounter++;
        ClassName = className;
        StudentCount = studentCount;
        Description = description;
        _classList.Add(this);
    }

    public static List<ClassInformationModel> GetAllClasses() => new(_classList);

    public static void AddClass(string className, int studentCount, string description)
    {
        new ClassInformationModel(className, studentCount, description);
    }

    public static void DeleteClass(int id)
    {
        var classToRemove = _classList.FirstOrDefault(c => c.Id == id);
        if (classToRemove != null)
        {
            _classList.Remove(classToRemove);
        }
    }

    public static void EditClass(int id, string className, int studentCount, string description)
    {
        var classToEdit = _classList.FirstOrDefault(c => c.Id == id);
        if (classToEdit != null)
        {
            classToEdit.ClassName = className;
            classToEdit.StudentCount = studentCount;
            classToEdit.Description = description;
        }
    }
}
