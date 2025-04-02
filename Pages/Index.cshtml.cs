using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class IndexModel : PageModel
{
    public List<ClassInformationModel> ClassList { get; set; } = ClassInformationModel.GetAllClasses();

    [BindProperty]
    public ClassInformationModel ClassData { get; set; } = new ClassInformationModel();

    public bool IsEditing { get; set; } = false;

    public void OnGet()
    {
        ClassList = ClassInformationModel.GetAllClasses();
        // Reset editing state and class data when navigating to the page
        IsEditing = false;
        ClassData = new ClassInformationModel();
    }

    public IActionResult OnPostAdd()
    {
        if (!ModelState.IsValid)
        {
            ClassList = ClassInformationModel.GetAllClasses();
            return Page();
        }

        ClassInformationModel.AddClass(ClassData.ClassName, ClassData.StudentCount, ClassData.Description);
        return RedirectToPage();
    }

    public IActionResult OnPostEdit(int id)
    {
        var classToEdit = ClassInformationModel.GetAllClasses().FirstOrDefault(c => c.Id == id);
        if (classToEdit != null)
        {
            ClassData = classToEdit;
            IsEditing = true;
            ClassList = ClassInformationModel.GetAllClasses();
        }
        return Page();
    }

    public IActionResult OnPostUpdateClass()
    {
        if (!ModelState.IsValid)
        {
            ClassList = ClassInformationModel.GetAllClasses();
            IsEditing = true;
            return Page();
        }

        ClassInformationModel.EditClass(ClassData.Id, ClassData.ClassName, ClassData.StudentCount, ClassData.Description);
        return RedirectToPage();
    }

    public IActionResult OnPostDelete(int id)
    {
        ClassInformationModel.DeleteClass(id);
        return RedirectToPage();
    }
}