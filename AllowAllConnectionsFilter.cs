using Hangfire.Dashboard;

namespace hangfire_example
{
    /// <summary>
    /// ref: https://medium.com/@alm.ozdmr/hangfire-docker-with-multiple-servers-82527167150b
    /// </summary>
    public class AllowAllConnectionsFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Allow outside. You need an authentication scenario for this part.
            // DON'T GO PRODUCTION WITH THIS LINES.
            return true;
        }
    }
}