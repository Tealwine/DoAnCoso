using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace LTrinhWebNhom3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

        }

        public async Task<IActionResult> Index()
        {
            var project = await _projectRepository.GetAllAsync();
            return View(project);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Project project, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    await _projectRepository.AddAsync(project);
                    return RedirectToAction(nameof(Index));
                }

            }


            return View(project);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }


        public async Task<IActionResult> Display(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        public async Task<IActionResult> Update(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Project project, IFormFile imageUrl)
        {
            ModelState.Remove("ImageUrl");
            if (id != project.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {


                var existingPorject = await _projectRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync
                if (imageUrl == null)
                {
                    project.ProjectImageUrl = existingPorject.ProjectImageUrl;
                }
                else
                {

                    project.ProjectImageUrl = await SaveImage(imageUrl);
                }
                existingPorject.Name = project.Name;
                existingPorject.Description = project.Description;
                existingPorject.ProjectUrl = project.ProjectUrl;
                existingPorject.CreatedDate = project.CreatedDate;
                existingPorject.UpdatedDate = project.UpdatedDate;
                existingPorject.Images = project.Images;
             
          

                await _projectRepository.UpdateAsync(existingPorject);

                return RedirectToAction(nameof(Index));
            }
            var tags = await _projectRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(tags, "Id", "Name");
            return View(project);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}