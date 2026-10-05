using Microsoft.EntityFrameworkCore;
using TennisBooking.Data;
using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public sealed class CoachService(ApplicationDbContext context) : ICoachService
{
    public async Task<IReadOnlyCollection<CoachViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Coaches
            .AsNoTracking()
            .OrderBy(coach => coach.Name)
            .Select(coach => new CoachViewModel
            {
                Name = coach.Name,
                ImageUrl = coach.ImageUrl,
                Experience = coach.Experience,
                Certificates = coach.Certificates,
                Achievements = coach.Achievements,
                IntroductionHtml = coach.IntroductionHtml
            })
            .ToListAsync(cancellationToken);
    }
}
