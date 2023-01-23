
using AutoMapper;
using Bilet1.DAL;
using Bilet1.Models;
using Bilet1.ViewModels.RecentPostViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bilet1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int RecentPostGet { get; private set; }

        public IActionResult Index()
        {
            List<RecentPost> posts = _context.recentPosts.ToList();
            List<RecentPostGetVM> postsGet = _mapper.Map<List<RecentPostGetVM>>(posts);
            return View(postsGet);
        }


    }
}