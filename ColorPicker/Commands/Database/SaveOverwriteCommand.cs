using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public class SaveOverwriteCommand : DatabaseBaseCommand
    {
        public SaveOverwriteCommand(ObservableCollection<RGBCode> colors) : base(colors)
        { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(ColorDbContext context, object parameter)
        {
            // So all items gets new ID assigned
            foreach (RGBCode rgbCode in _colors)
            {
                rgbCode.Id = 0;
            }

            context.Colors.RemoveRange(context.Colors);
            context.Colors.AddRange(_colors);

            await context.SaveChangesAsync();
        }
    }
}