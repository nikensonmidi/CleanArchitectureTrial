using BenchmarkDotNet.Attributes;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchMarks.Application
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
    }

    public interface IGuestRepository
    {
        IEnumerable<Guest> GetAll();
    }

    [MemoryDiagnoser]
    public class GuestQuery
    {
        private readonly Mock<IGuestRepository> _guestRepo;
        public GuestQuery()
        {
            _guestRepo = new Mock<IGuestRepository>();
            _guestRepo.Setup(e => e.GetAll()).Returns(GenerateGuests(100));
        }

        [Benchmark(Baseline = true)]
        public async Task GetGuestQueryStats()
        {
            var guests = _guestRepo.Object.GetAll();
        }

        [Benchmark]
        public async Task GetGuestsLambda()
        {
            var guests = _guestRepo.Object.GetAll();
            guests = guests.Where(e => e.GuestId > 1);
        }

        [Benchmark]
        public async Task GetGuestsQuery()
        {
            var guests = from g in _guestRepo.Object.GetAll()
                         where g.GuestId > 1
                         select g;
        }

        private IEnumerable<Guest> GenerateGuests(int iteration)
        {
            List<Guest> guests = new List<Guest>();
            for (int i = 0; i < iteration; i++)
            {
                guests.Add(new Guest
                {
                    GuestId = i,
                    Name = "guest " + i,
                    RoomNumber = "Room " + i
                });
            }
            return guests;
        }
    }
}
