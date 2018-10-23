using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public class SaveAddOrUpdateCommand : DatabaseBaseCommand
    {
        public SaveAddOrUpdateCommand(ObservableCollection<RGBCode> colors) : base(colors)
        {
            ((INotifyCollectionChanged) colors).CollectionChanged += (o, args) => OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return _colors.Count > 0;
        }

        public override async Task ExecuteAsync(ColorDbContext context, object parameter)
        {
            foreach (RGBCode color in _colors)
            {
                context.Colors.AddOrUpdate(color);
            }

            await context.SaveChangesAsync();
        }
    }
}