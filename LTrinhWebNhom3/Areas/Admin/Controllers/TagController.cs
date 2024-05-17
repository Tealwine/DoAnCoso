using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;
using Model.Repositories;

namespace LTrinhWebNhom3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

        // GET: Admin/Tag
        public async Task<IActionResult> Index()
        {
            var tags = await _tagRepository.GetAllAsync();
            return View(tags);
        }

        // GET: Admin/Tag/Add
        public async Task<IActionResult> Add()
        {
            var tags = await _tagRepository.GetAllAsync();
            ViewBag.Tags = new SelectList(tags, "Id", "TagName", "Description");
            return View();
        }

        // POST: Admin/Tag/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }

            await _tagRepository.AddAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Tag/Display/{id}
        public async Task<IActionResult> Display(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        // GET: Admin/Tag/Update/{id}
        public async Task<IActionResult> Update(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Admin/Tag/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(tag);
            }

            var existingTag = await _tagRepository.GetByIdAsync(id);
            if (existingTag == null)
            {
                return NotFound();
            }

            existingTag.TagName = tag.TagName;
            existingTag.Description = tag.Description;
            await _tagRepository.UpdateAsync(existingTag);

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Tag/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        // POST: Admin/Tag/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            await _tagRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}