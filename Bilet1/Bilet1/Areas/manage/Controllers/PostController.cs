using AutoMapper;
using Bilet1.DAL;
using Bilet1.Extensions.FileManagmentExtensions;
using Bilet1.Models;
using Bilet1.ViewModels.RecentPostViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Bilet1.Areas.manage.Controllers
{
    [Area("manage")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public PostController(AppDbContext context, IWebHostEnvironment env, IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<RecentPost> posts = _context.recentPosts.ToList();
            List<RecentPostGetVM> postsGetVM = _mapper.Map<List<RecentPostGetVM>>(posts);
            return View(postsGetVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RecentPostPostVM postVM)
        {
            if (!ModelState.IsValid)
            {
                return View(postVM);
            }
            RecentPost post = new RecentPost();
            if (postVM.FormFile is not null)
            {
                if (!postVM.FormFile.IsTrueContent())
                {
                    ModelState.AddModelError("FormFile", "Invalid Formaat!");
                    return View();
                }
                if (!postVM.FormFile.IsValidLength())
                {
                    ModelState.AddModelError("FormFile", "File must be less than 2mb");
                    return View();
                }
                post.ImageUrl = postVM.FormFile.SaveUrl(_env.WebRootPath, "assets/images");
            }
            post.Title = postVM.Title;
            post.Description=postVM.Description;
            
           await  _context.recentPosts.AddAsync(post);
           await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        /*public IActionResult Update(int id)
        {
            RecentPost recentPost = _context.recentPosts.Find(id);
            if (recentPost is null)
            {
                return NotFound();
            }
            RecentPostUpdateVM postUpdateVM = new RecentPostUpdateVM()
            {
                recentPostVm
            }
            return View
        }*/
    }
}
