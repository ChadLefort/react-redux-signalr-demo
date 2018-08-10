using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Controllers
{
    public class R6StatsSignalR : Hub
    {
        private readonly R6StatsContext _context;
        private static Timer timer;

        public R6StatsSignalR(R6StatsContext context)
        {
            _context = context;
        }

        public Task GetLiveStats(int userId)
        {
            var stats = _context.Stats.Find(userId);

            if (stats != null)
            {

            }

            return Clients.All.SendAsync("GetLiveStats");
        }

        private void SimulateMatch(int userId)
        {
            timer = new Timer(TimerTask, null, 0, 10000);
        }

        private static void TimerTask(object timerState)
        {

        }

        //public Task DecrementCounter()
        //{
        //    return Clients.All.SendAsync("DecrementCounter", UpdateCount(false));
        //}

        //private Counter UpdateCount(bool increment)
        //{
        //    var counter = _context.Counter.FirstOrDefault(x => x.Id == 1);

        //    if (counter != null)
        //    {
        //        counter.Count = increment ? counter.Count + 1 : counter.Count - 1;
        //        _context.Counter.Update(counter);
        //        _context.SaveChanges();
        //    }

        //    return counter;
        //}
    }
}