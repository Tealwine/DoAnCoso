using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Repositories;
namespace LTrinhWebNhom3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly ITagRepository _tagRepository;
        public ProductController(IPortfolioRepository portfolioRepository, ITagRepository tagRepository)
        {
            _portfolioRepository = portfolioRepository;
            _tagRepository = tagRepository;
        }

        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var portfolio = await _portfolioRepository.GetAllAsync();
            return View(portfolio);
        }

        // Hiển thị form thêm sản phẩm mới
        public async Task<IActionResult> Add()
        {
            var tags = await _tagRepository.GetAllAsync();
            ViewBag.Tag = new SelectList(tags, "Id", "Name");
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Add(Portfolio portfolio, IFormFile

        imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    // Lưu hình ảnh đại diện tham khảo bài 02 hàm SaveImage
                    portfolio.ImageUrl = await SaveImage(imageUrl);
                }
                await _portfolioRepository.AddAsync(portfolio);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var tags = await _tagRepository.GetAllAsync();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");
            return View(portfolio);
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
            var portfolio = await _portfolioRepository.GetByIdAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }
        // Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Update(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            var tags = await _portfolioRepository.GetAllAsync();
            ViewBag.Tags = new SelectList(tags, "Id", "Name", portfolio);

            return View(portfolio);
        }

        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, Portfolio portfolio, IFormFile imageUrl)
        {
            ModelState.Remove("ImageUrl"); // Loại bỏ xác thực ModelState cho ImageUrl
            if (id != portfolio.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {


                var existingPortfolio = await _portfolioRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync


                // Giữ nguyên thông tin hình ảnh nếu không có hình mới được tải lên
                if (imageUrl == null)
                {
                    portfolio.ImageUrl = existingPortfolio.ImageUrl;
                }
                else
                {
                    // Lưu hình ảnh mới
                    portfolio.ImageUrl = await SaveImage(imageUrl);
                }
                // Cập nhật các thông tin khác của sản phẩm
                existingPortfolio.Name = portfolio.Name;
                existingPortfolio.Description = portfolio.Description;
                existingPortfolio.Description = portfolio.Description;
                existingPortfolio.TagID = portfolio.TagID;
                existingPortfolio.ImageUrl = portfolio.ImageUrl;
                existingPortfolio.projects = portfolio.projects;


        await _portfolioRepository.UpdateAsync(existingPortfolio);

                return RedirectToAction(nameof(Index));
            }
            var tags = await _tagRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(tags, "Id", "Name");
            return View(portfolio);
        }

        // Hiển thị form xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }

        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _portfolioRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
