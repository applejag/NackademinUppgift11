using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public class ClearCommand : DatabaseBaseCommand
    {
        public ClearCommand(ObservableCollection<RGBCode> colors) : base(colors)
        { }

        public override bool CanExecute(object parameter)
        {
            Target target = ParseParameter(parameter);

            return target != Target.Local || _colors.Count > 0;
        }

        private static Target ParseParameter(object parameter)
        {
            if (!Enum.TryParse(parameter as string, true, out Target target))
                throw new ArgumentException($"Invalid clear target: <{parameter?.ToString() ?? "null"}>. Possible values: {string.Join(",", Enum.GetNames(typeof(Target)))}", nameof(parameter));
            return target;
        }

        public override async Task ExecuteAsync(ColorDbContext context, object parameter)
        {
            Target target = ParseParameter(parameter);

            if (target != Target.Local)
            {
                context.Colors.RemoveRange(context.Colors);
                await context.SaveChangesAsync();
            }

            if (target != Target.Database)
                _colors.Clear();
            
        }

        public enum Target
        {
            Database,
            Local,
            Both
        }
    }
}