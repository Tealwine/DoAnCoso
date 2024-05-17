using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LTrinhWebNhom3.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // Hiển thị danh sách Comment
        public async Task<IActionResult> Index()
        {
            var comments = await _commentRepository.GetAllAsync();
            return View(comments);
        }

        // Hiển thị form thêm Comment mới
        public IActionResult Add()
        {
            return View();
        }

        // Xử lý thêm Comment mới
        [HttpPost]
        public async Task<IActionResult> Add(Comment comment)
        {
            if (ModelState.IsValid)
            {
                await _commentRepository.AddAsync(comment);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            return View(comment);
        }

        // Hiển thị thông tin chi tiết Comment
        public async Task<IActionResult> Display(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // Hiển thị form cập nhật Comment
        public async Task<IActionResult> Update(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // Xử lý cập nhật Comment
        [HttpPost]
        public async Task<IActionResult> Update(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _commentRepository.UpdateAsync(comment);
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        // Hiển thị form xác nhận xóa Comment
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // Xử lý xóa Comment
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _commentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
