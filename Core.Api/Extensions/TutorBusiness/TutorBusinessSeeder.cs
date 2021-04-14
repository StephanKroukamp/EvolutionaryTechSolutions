using System.Collections.Generic;
using System.Linq;
using Core.Database.TutorBusiness;
using Core.Entity.TutorBusiness;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Api.Extensions.TutorBusiness
{
    public static class TutorBusinessSeeder
    {
        public static void SeedTutorBusiness(this IApplicationBuilder app)
        {
            IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            TutorBusinessDbContext tutorBusinessDbContext = serviceScope.ServiceProvider.GetService<TutorBusinessDbContext>();

            if (tutorBusinessDbContext.Parents.Any())
            {
                return;
            }

            List<Parent> parents = new List<Parent>
            {
                new Parent { Id = 1, FirstName = "Stephanus", LastName = "Kroukamp", Students = null }
            };

            tutorBusinessDbContext.Parents.AddRange(parents);

            tutorBusinessDbContext.SaveChanges();
        }
    }
}