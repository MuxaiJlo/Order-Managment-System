namespace Order_Managment_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new OrderDbContext())
            {
                context.Database.EnsureCreated();
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}