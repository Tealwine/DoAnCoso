using Microsoft.AspNetCore.Mvc;
using LTrinhWebNhom3.Repositories; 
using System.Threading.Tasks;
using LTrinhWebNhom3.Models;
using Microsoft.AspNetCore.Authorization;
namespace LTrinhWebNhom3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PortfolioImageController : Controller
    {
        private readonly IPortfolioImageRepository _portfolioImageRepository;

        public PortfolioImageController(IPortfolioImageRepository portfolioImageRepository)
        {
            _portfolioImageRepository = portfolioImageRepository;
        }

        // Hiển thị danh sách PortfolioImage
        public async Task<IActionResult> Index()
        {
            var portfolioImages = await _portfolioImageRepository.GetAllAsync();
            return View(portfolioImages);
        }

        // Hiển thị form thêm PortfolioImage mới
        public IActionResult Add()
        {
            return View();
        }

        // Xử lý thêm PortfolioImage mới
        [HttpPost]
        public async Task<IActionResult> Add(PortfolioImage portfolioImage)
        {
            if (ModelState.IsValid)
            {
                await _portfolioImageRepository.AddAsync(portfolioImage);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            return View(portfolioImage);
        }

        // Hiển thị thông tin chi tiết PortfolioImage
        public async Task<IActionResult> Display(int id)
        {
            var portfolioImage = await _portfolioImageRepository.GetByIdAsync(id);
            if (portfolioImage == null)
            {
                return NotFound();
            }
            return View(portfolioImage);
        }

        // Hiển thị form cập nhật PortfolioImage
        public async Task<IActionResult> Update(int id)
        {
            var portfolioImage = await _portfolioImageRepository.GetByIdAsync(id);
            if (portfolioImage == null)
            {
                return NotFound();
            }
            return View(portfolioImage);
        }

        // Xử lý cập nhật PortfolioImage
        [HttpPost]
        public async Task<IActionResult> Update(int id, PortfolioImage portfolioImage)
        {
            if (id != portfolioImage.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _portfolioImageRepository.UpdateAsync(portfolioImage);
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioImage);
        }

        // Hiển thị form xác nhận xóa PortfolioImage
        public async Task<IActionResult> Delete(int id)
        {
            var portfolioImage = await _portfolioImageRepository.GetByIdAsync(id);
            if (portfolioImage == null)
            {
                return NotFound();
            }
            return View(portfolioImage);
        }

        // Xử lý xóa PortfolioImage
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _portfolioImageRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}