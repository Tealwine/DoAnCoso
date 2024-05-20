using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace LTrinhWebNhom3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var projects = await _projectRepository.GetAllAsync();
            return View(projects);
        }

        // Hiển thị form thêm sản phẩm mới
        public async Task<IActionResult> Add()
        {
         
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Add(Project project, IFormFile

        imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    // Lưu hình ảnh đại diện tham khảo bài 02 hàm SaveImage
                    project.ProjectImageUrl = await SaveImage(imageUrl);
                }
                await _projectRepository.AddAsync(project);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            
            return View(project);

        }

        // Viết thêm hàm SaveImage (tham khảo bài 02)
        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName); //Thay đổi đường dẫn theo cấu hình của bạn

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName; // Trả về đường dẫn tương đối
        }

        // Hiển thị thông tin chi tiết sản phẩm
        public async Task<IActionResult> Display(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        // Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Update(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
          

            return View(project);
        }

        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, Project project, IFormFile imageUrl)
        {
            ModelState.Remove("ImageUrl"); // Loại bỏ xác thực ModelState cho ImageUrl
            if (id != project.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {


                var existingPorject = await _projectRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync


                // Giữ nguyên thông tin hình ảnh nếu không có hình mới được tải lên
                if (imageUrl == null)
                {
                    project.ProjectImageUrl = existingPorject.ProjectImageUrl;
                }
                else
                {
                    // Lưu hình ảnh mới
                    project.ProjectImageUrl = await SaveImage(imageUrl);
                }
                // Cập nhật các thông tin khác của sản phẩm
                existingPorject.Name = project.Name;
                existingPorject.Description = project.Description;
                existingPorject.ProjectUrl = project.ProjectUrl;
                existingPorject.Images = project.Images;



                await _projectRepository.UpdateAsync(existingPorject);

                return RedirectToAction(nameof(Index));
            }
          
            return View(project);
        }

        // Hiển thị form xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}