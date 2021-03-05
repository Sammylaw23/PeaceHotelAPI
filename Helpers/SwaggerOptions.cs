using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Helpers
{
    public class SwaggerOptions
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Route { get; set; }
        public string Endpoint { get; set; }

        public SwaggerOptions(IConfiguration configuration) => configuration.GetSection(nameof(SwaggerOptions)).Bind(this);
    }

}
