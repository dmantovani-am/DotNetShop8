using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetShop.Pages
{
    public class ContactModel : PageModel
    {
        readonly IContactRepository _contactRepository;

        [BindProperty]
        public Contact? InputModel { get; set; }

        public ContactModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void OnGet()
        { }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid && InputModel != null)
            {
                await _contactRepository.AddContact(InputModel);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
