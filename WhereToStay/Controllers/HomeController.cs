
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;
using NuGet.ContentModel;
using PixabaySharp.Utility;
using PixabaySharp;
using System.Diagnostics;
using WhereToStay.Models;
using WhereToStay.ViewModel;
using NuGet.Protocol;
using System.Security.Claims;
using System.Reflection.Metadata;

namespace WhereToStay.Controllers
{
    public class HomeController : Controller
    {
        private readonly wtsDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, wtsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Destinations()
        {
           
                // Query all the cities in the hotel table
                var hotelCities = _context.Hotels.Select(h => h.city).Distinct().ToList();
            
                // Query all the cities in the destination table
                var destinationCities = _context.Destinations.Select(d => d.name).ToList();
            
                // Find the cities that are not in the destination table
                var newCities = hotelCities.Except(destinationCities).ToList();
            
                // Insert the new cities into the destination table
                _context.Destinations.AddRange(newCities.Select(c => new Destination { name = c }));
            
                // Save the changes to the database
                _context.SaveChanges();
            

            var destinationImg = new DestinationImages();
            destinationImg.destinations = await _context.Destinations.ToListAsync();
            
            
            
            return View(destinationImg);
        }
        public async Task<IActionResult> HotelSearch()
        {
            var hotelS = new SearchHotel();
            hotelS.Hotel = (await _context.HotelImage
                .Include(p => p.Hotel)
                .Include(p => p.Image)
               .ToListAsync())
               .GroupBy(x => x.Hotel.name)
               .Select(g => g.First());
            hotelS.Rooms = await _context.Rooms
                .ToListAsync();

            return View(hotelS);
        }
        public async Task<IActionResult> DestinationHotel(int id)
        {
            var destination = _context.Destinations.Where(d => d.destinaiton_id == id).SingleOrDefault();
            var hotelS = new SearchHotel();
            hotelS.Hotel = (await _context.HotelImage
                .Include(p => p.Hotel)
                .Include(p => p.Image)
                .Where(p => p.Hotel.city == destination.name)
               .ToListAsync())
               .GroupBy(x => x.Hotel.name)
               .Select(g => g.First());
            hotelS.Rooms = await _context.Rooms
                .ToListAsync();
            return View(hotelS);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact(contactMessages msg)
        {
            if (msg.message != null)
            {
                this._context.contactMessages.Add(msg);
                this._context.SaveChanges();
            }
            
            return View();

        }
        public async Task<IActionResult> nameFunction()
        {
            var users = await _context.UserProfiles.ToListAsync();
            return PartialView(users);
        }
        public IActionResult Hotel(int id)
        {
            
            var hotel = _context.Hotels.Where(h => h.hotel_id == id).SingleOrDefault();
            var hImages = _context.HotelImage.Where(i => i.HotelId == id).ToList();
            var roomList = _context.HotelRoom.Where(r => r.HotelId == id).ToList();
            List<Image> image = new List<Image>();
            List<Room> room = new List<Room>();
            List<Reservation> reservation = new List<Reservation>();
            foreach (var item in hImages)
            {
                var img = _context.Images.SingleOrDefault(i => i.image_id == item.ImageId);
                if (img != null)
                {
                    image.Add(img);
                }
            }
            foreach (var item in roomList)
            {
                var hotelRooms = _context.Rooms.SingleOrDefault(i => i.room_id == item.RoomId);
                if (hotelRooms != null)
                {
                    room.Add(hotelRooms);
                }
            }
            

            var feat = _context.Features.Where(f => f.features_id == hotel.FeaturesID).SingleOrDefault();
            var model = new HotelViewModel { Hotel = hotel, features = feat, Images = image, rooms = room};
            
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminPage()
        {
            messageViewModel msgModel = new messageViewModel();
            msgModel.msgList = await _context.contactMessages.ToListAsync();
            return View(msgModel);
        }
        [HttpPost]
        public IActionResult paymentPage(int roomId, DateTime checkin, DateTime checkout)
        {
            int hotelId = -1;
            var room = _context.Rooms.Include(r => r.HotelRooms).FirstOrDefault(r => r.room_id == roomId);
            if (room != null)
            {
                var hotelRoom = room.HotelRooms.FirstOrDefault();
                if (hotelRoom != null)
                {
                    hotelId = hotelRoom.HotelId;
                }
            }
            List<Image> images = new List<Image>();
            images = _context.HotelImage
            .Include(hi => hi.Image)
            .Where(hi => hi.HotelId == hotelId)
             .Select(hi => hi.Image)
             .ToList();
            double roomPrice = -1;
            string roomName = "";
            if (room != null)
            {
                roomPrice = room.price;
                roomName = room.room_name;

            }
            TimeSpan diff = checkin - checkout;
            int fullDays = (int)Math.Truncate(Math.Abs(diff.TotalDays));
            double roomPriceFromTo = roomPrice * fullDays;
            var model = new PaymentViewModel { checkin = checkin, checkout = checkout, images = images, roomId = hotelId, roomPrice = roomPriceFromTo, roomName = roomName };

            return View(model);
        }
        [HttpPost]
        public IActionResult CheckRoomAvailability(int roomId)
        {
            var reservations = _context.Reservations.Where(r => r.RoomId == roomId).ToList();
            var currentDate = DateTime.Now;
            var startDate = currentDate;
            var endDate = currentDate.AddDays(1);
            foreach (var reservation in reservations)
            {
                if ((startDate >= reservation.start_date && startDate <= reservation.end_date) || (endDate >= reservation.start_date && endDate <= reservation.end_date))
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
        public IActionResult paymentSuccess(int roomId, DateTime checkin, DateTime checkout, double money_spent)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservation = new Reservation
            {
                start_date = checkin,
                end_date = checkout,
                money_spent = money_spent,
                RoomId = roomId,
                UserId = userId
            };
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}