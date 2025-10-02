using System;
using System.Linq;
using System.IO;

namespace M2M.Siemens.Library
{
	public class SiemensFileWatcher
	{
		FileSystemWatcher watcher = null;

		public void Start()
		{
			watcher = new FileSystemWatcher();
			watcher.Path = @"C:\APT\";
			watcher.Filter = "*.*";
			watcher.NotifyFilter = NotifyFilters.FileName;
			watcher.Renamed += new RenamedEventHandler(watcher_Changed);
			watcher.EnableRaisingEvents = true;
		}

		void watcher_Changed(object sender, RenamedEventArgs e)
		{
			Console.WriteLine(e.OldName + " -> " + e.Name);
		}

		public void Stop()
		{
			watcher.EnableRaisingEvents = false;
			watcher.Dispose();
			watcher = null;
		}

	}
}
