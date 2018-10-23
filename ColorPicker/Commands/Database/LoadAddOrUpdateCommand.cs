using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public class LoadAddOrUpdateCommand : DatabaseBaseCommand
    {
        public LoadAddOrUpdateCommand(ObservableCollection<RGBCode> colors) : base(colors)
        { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(ColorDbContext context, object parameter)
        {
            await context.Colors.ForEachAsync(color => SendToUIThread(() =>
            {
                // Count how many are updated
                int count = _colors
                    .Where(c => c.Id == color.Id)
                    .Select((c, i) => _colors[i] = c)
                    .Count();

                // Add new one if none
                if (count == 0)
                    _colors.Add(color);
            }));
        }
    }
}