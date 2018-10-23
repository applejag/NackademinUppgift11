using System.Collections.ObjectModel;
using ColorPicker.Commands.Database;
using ColorPicker.Models;

namespace ColorPicker.Commands
{
    public class DatabaseCommands
    {
        public SaveAppendCommand SaveAppend { get; }
        public SaveAddOrUpdateCommand SaveAddOrUpdate { get; }
        public SaveOverwriteCommand SaveOverwrite { get; }
        public LoadAppendCommand LoadAppend { get; }
        public LoadAddOrUpdateCommand LoadAddOrUpdate { get; }
        public LoadOverwriteCommand LoadOverwrite { get; }
        public ClearCommand Clear { get; }

        public DatabaseCommands(ObservableCollection<RGBCode> colors)
        {
            SaveAppend = new SaveAppendCommand(colors);
            SaveAddOrUpdate = new SaveAddOrUpdateCommand(colors);
            SaveOverwrite = new SaveOverwriteCommand(colors);
            LoadAppend = new LoadAppendCommand(colors);
            LoadAddOrUpdate = new LoadAddOrUpdateCommand(colors);
            LoadOverwrite = new LoadOverwriteCommand(colors);
            Clear = new ClearCommand(colors);
        }
    }
}