using MyWebProject.Core.Models.Top10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Services.IServices
{
    public interface IMysteryPlace
    {
        Task<IEnumerable<MisteryModelView>> MysteryPlaces();
    }
}
