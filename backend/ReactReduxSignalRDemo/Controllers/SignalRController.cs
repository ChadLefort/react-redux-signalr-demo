using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Controllers
{
    public class SignalRCounter : Hub
    {
        //private readonly CounterContext _context;

        //public SignalRCounter(CounterContext context)
        //{
        //    _context = context;
        //}

        //public Task IncrementCounter()
        //{
        //    return Clients.All.SendAsync("IncrementCounter", UpdateCount(true));
        //}

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