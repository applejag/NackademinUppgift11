using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public class SaveAppendCommand : DatabaseBaseCommand
    {
        public SaveAppendCommand(ObservableCollection<RGBCode> colors) : base(colors)
        {
            ((INotifyCollectionChanged) colors).CollectionChanged += (o, args) => OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return _colors.Count > 0;
        }

        public override async Task ExecuteAsync(ColorDbContext context, object parameter)
        {
            // So all items gets new ID assigned
            foreach (RGBCode rgbCode in _colors)
            {
                rgbCode.Id = 0;
            }

            context.Colors.AddRange(_colors);

            await context.SaveChangesAsync();
        }
    }
}